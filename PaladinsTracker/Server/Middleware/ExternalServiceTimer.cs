using System;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;
using PaladinsTracker.Server.Logging;

namespace PaladinsTracker.Server.Middleware
{
    public class ExternalServiceTimer : IExternalServiceTimer
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private const string ExternalServiceTimerKey = "ExternalServiceTimer";

        public ExternalServiceTimer(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void AddTimeSpan(TimeSpan timeSpent)
        {
            if (_contextAccessor.HttpContext == null)
                _contextAccessor.HttpContext = new DefaultHttpContext();

            if (!_contextAccessor.HttpContext.Items.TryGetValue(ExternalServiceTimerKey, out _))

                _contextAccessor.HttpContext.Items[ExternalServiceTimerKey] = new ConcurrentBag<TimeSpan>();

            (_contextAccessor.HttpContext.Items[ExternalServiceTimerKey] as ConcurrentBag<TimeSpan>)?.Add(timeSpent);
        }

        public TimeSpan Calculate()
        {
            if (_contextAccessor.HttpContext != null && _contextAccessor.HttpContext.Items.TryGetValue(ExternalServiceTimerKey, out _))
            {
                var result = new TimeSpan();
                if (_contextAccessor.HttpContext.Items["ExternalServiceTimer"] is ConcurrentBag<TimeSpan> bag)
                    foreach (var timing in bag)
                        result = result.Add(timing);

                return result;
            }

            return TimeSpan.Zero;
        }
    }
}