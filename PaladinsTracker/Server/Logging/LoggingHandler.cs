using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PaladinsTracker.Server.Middleware;

namespace PaladinsTracker.Server.Logging
{
    public class LoggingHandler<T> : DelegatingHandler
    {
        private readonly ILogger<T> _logger;
        private readonly IExternalServiceTimer _timer;

        public LoggingHandler(ILogger<T> logger, IExternalServiceTimer timer)
        {
            _logger = logger;
            _timer = timer;
        }

        private static bool NeedsToLog(string url)
        {
            return !url.Contains("/status/") && //generic status endpoint
                   !url.Contains("/attachments") &&
                   !url.Contains("/hangfire/");
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (NeedsToLog(request.RequestUri.OriginalString))
            {
                var logInfo = new LogInfo
                {
                    InnerCorrelationId = Guid.NewGuid(),
                    StartTime = DateTime.UtcNow,
                    HttpMethod = request.Method.ToString(),
                    RequestPath = request.RequestUri.OriginalString
                };
                await LogRequest(request, logInfo);
                try
                {
                    var response = await base.SendAsync(request, cancellationToken);
                    LogResponse(response, logInfo);
                    return response;
                }
                catch (TimeoutException ex)
                {
                    ex.Data.Add("extraInfo", $"Request to {request.Method} {request.RequestUri} with inner correlation id: {logInfo.InnerCorrelationId} timed out");
                    _logger.LogInformation($"Request with inner correlation id: {logInfo.InnerCorrelationId} timed out");
                    throw;
                }
                catch (Exception ex)
                {
                    var millisecondsSpent = DateTime.UtcNow.Subtract(logInfo.StartTime).TotalMilliseconds;
                    _logger.LogInformation(
                        "An error occurred from outgoing request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nElapsed time: {timeElapsed}\r\nException message: {responseStatusCode}",
                        new object[]
                        {
                            logInfo.InnerCorrelationId, logInfo.HttpMethod, logInfo.RequestPath, ex.Message, millisecondsSpent
                        });
                    throw;
                }
            }
            else
                return await base.SendAsync(request, cancellationToken);
        }

        private async Task LogRequest(HttpRequestMessage request, LogInfo logInfo)
        {
            var jsonData = request.Content != null ? await request.Content.ReadAsStringAsync() : string.Empty;
            var headers = string.Join(Environment.NewLine, request.Headers.Select(x => GetFormattedHeader(x)));
            var messageFormat =
                "Start sending outgoing request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nHeaders: {httpHeaders}\r\nBody: {body}";
            _logger.LogInformation(messageFormat,
                new object[]
                {
                    logInfo.InnerCorrelationId, logInfo.HttpMethod, logInfo.RequestPath, headers, jsonData
                });
        }

        private void LogResponse(HttpResponseMessage response, LogInfo info)
        {
            var statusCode = (int) response.StatusCode;
            var millisecondsSpent = DateTime.UtcNow.Subtract(info.StartTime).TotalMilliseconds;
            _timer.AddTimeSpan(TimeSpan.FromMilliseconds(millisecondsSpent));
            _logger.LogInformation(
                "Received answer from outgoing request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nStatus code: {responseStatusCode}\r\nElapsed time: {timeElapsed}",
                new object[]
                {
                    info.InnerCorrelationId, info.HttpMethod, info.RequestPath, statusCode, millisecondsSpent
                });
        }

        private static string GetFormattedHeader(KeyValuePair<string, IEnumerable<string>> rawHeader)
        {
            var valuesFormatted = string.Join(", ", rawHeader.Value.Select(y => y));
            return $"{rawHeader.Key}:{valuesFormatted}";
        }
    }
}