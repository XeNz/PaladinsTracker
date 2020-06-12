using Microsoft.AspNetCore.Builder;
using PaladinsTracker.Server.Middleware;

namespace PaladinsTracker.Server.Logging
{
    public static class LogExtensions
    {
        public static IApplicationBuilder UseRequestLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestLogMiddleware>();
        }
    }
}