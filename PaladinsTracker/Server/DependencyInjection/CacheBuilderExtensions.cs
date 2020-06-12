using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PaladinsTracker.Server.Caching;
using PaladinsTracker.Server.Configuration;
using StackExchange.Redis;

namespace PaladinsTracker.Server.DependencyInjection
{
    public static class CacheBuilderExtensions
    {
        public static void AddCacheServices(this IServiceCollection services, IConfiguration configuration)
        {
            var redisCacheSettings = new RedisCacheSettings();
            configuration.GetSection(nameof(RedisCacheSettings)).Bind(redisCacheSettings);
            services.AddSingleton(redisCacheSettings);

            if (!redisCacheSettings.Enabled)
            {
                return;
            }

            services.AddSingleton<IConnectionMultiplexer>(_ =>
                ConnectionMultiplexer.Connect(redisCacheSettings.ConnectionString));
            services.AddStackExchangeRedisCache(options => options.Configuration = redisCacheSettings.ConnectionString);
            services.AddSingleton<IResponseCacheService, ResponseCacheService>();
        }
    }
}