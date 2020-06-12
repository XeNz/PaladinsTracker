using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using PaladinsTracker.Server.Logging;

namespace PaladinsTracker.Server.Middleware
{
    public class RequestLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLogMiddleware> _logger;
        private const int ThreeDotFiveMb = 3500000;

        public RequestLogMiddleware(ILogger<RequestLogMiddleware> logger, RequestDelegate next)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IExternalServiceTimer timer)
        {
            if (NeedsToLog(context.Request.GetEncodedUrl()))
            {
                if (!IsMultiPartRequest(context.Request))
                {
                    context.Request.EnableBuffering();
                }

                var logInfo = new LogInfo
                {
                    InnerCorrelationId = Guid.NewGuid(),
                    StartTime = DateTime.UtcNow,
                    HttpMethod = context.Request.Method,
                    RequestPath = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}"
                };

                await LogRequest(context.Request, logInfo);

                if (!IsMultiPartRequest(context.Request))
                {
                    context.Request.Body.Seek(0, SeekOrigin.Begin);
                }

                try
                {
                    await _next(context);
                    LogResponse(context, logInfo, timer);
                }
                catch (System.Exception ex)
                {
                    LogErrorResponse(context, logInfo, timer, ex);
                    throw;
                }
            }
            else
                await _next(context);
        }

        private static bool NeedsToLog(string url)
        {
            return !url.Contains("/status/") &&
                   !url.Contains("/attachments") &&
                   !url.Contains("/hangfire/");
        }

        private void LogErrorResponse(HttpContext context, LogInfo info, IExternalServiceTimer timer, System.Exception exception)
        {
            _logger.LogError(exception, "An error occurred");
            var statusCode = context.Response.StatusCode;
            var millisecondsSpent = DateTime.UtcNow.Subtract(info.StartTime).TotalMilliseconds;
            var timeSpentWaitingForRequests = timer.Calculate().TotalMilliseconds;
            _logger.LogInformation(
                "An error occurred while processing incoming request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nStatus code: {responseStatusCode}\r\nElapsed time: {timeElapsed}\r\nTime waiting for external requests:{timeSpentWaitingForRequests}",
                new object[]
                {
                    info.InnerCorrelationId, info.HttpMethod, info.RequestPath, statusCode, millisecondsSpent, timeSpentWaitingForRequests
                });
        }

        private void LogResponse(HttpContext context, LogInfo info, IExternalServiceTimer timer)
        {
            var statusCode = context.Response.StatusCode;
            var millisecondsSpent = DateTime.UtcNow.Subtract(info.StartTime).TotalMilliseconds;
            var timeSpentWaitingForRequests = timer.Calculate().TotalMilliseconds;
            _logger.LogInformation(
                "Finished processing incoming request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nStatus code: {responseStatusCode}\r\nElapsed time: {timeElapsed}\r\nTime waiting for external requests:{timeSpentWaitingForRequests}",
                new object[]
                {
                    info.InnerCorrelationId, info.HttpMethod, info.RequestPath, statusCode, millisecondsSpent, timeSpentWaitingForRequests
                });
        }

        private async Task LogRequest(HttpRequest request, LogInfo logInfo)
        {
            string jsonData;
            var contentLength = Convert.ToInt32(request.ContentLength);
            if (!IsMultiPartRequest(request))
            {
                if (contentLength < ThreeDotFiveMb)
                {
                    var buffer = new byte[contentLength];
                    await request.Body.ReadAsync(buffer, 0, buffer.Length);
                    jsonData = Encoding.UTF8.GetString(buffer);
                }
                else
                {
                    jsonData = $"{{\"message\": \"Body size too large to log (> 3.5mb)\", \"size\": \"{contentLength}\"}}";
                }
            }
            else
            {
                jsonData = "{\"message\": \"The content-type is multipart/form-data and will not be logged because it is an upload.\"}";
            }

            var headers = string.Join(Environment.NewLine, request.Headers.Select(x => GetFormattedHeader(x)));
            var messageFormat =
                "Start processing incoming request with inner correlation id: {innerCorrelationId}\r\nMethod: {httpMethod}\r\nPath: {requestPath}\r\nHeaders: {httpHeaders}\r\nBody: {body}";
            _logger.LogInformation(messageFormat,
                new object[]
                {
                    logInfo.InnerCorrelationId, logInfo.HttpMethod, logInfo.RequestPath, headers, jsonData
                });
        }

        private string GetFormattedHeader(KeyValuePair<string, StringValues> rawHeader)
        {
            var valuesFormatted = string.Join(", ", rawHeader.Value.Select(y => y));
            return $"{rawHeader.Key}:{valuesFormatted}";
        }

        private bool IsMultiPartRequest(HttpRequest httpRequest) => httpRequest.ContentType != null &&
                                                                    httpRequest.ContentType.Contains("multipart/form-data", StringComparison.OrdinalIgnoreCase);
    }
}