using System;
using System.Reflection;
using AutoMapper;
using HiRezApi.Common;
using HiRezApi.Paladins;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Microsoft.Rest.TransientFaultHandling;
using PaladinsTracker.Server.Configuration;
using PaladinsTracker.Server.Data;
using PaladinsTracker.Server.DependencyInjection;
using PaladinsTracker.Server.Logging;
using PaladinsTracker.Server.Mappers;
using PaladinsTracker.Server.Middleware;

namespace PaladinsTracker.Server
{
    public class Startup
    {
        private readonly MapperConfiguration _mapperConfiguration;
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new DtoMapper()); });
            _mapperConfiguration.AssertConfigurationIsValid();
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDBContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<HiRezSettings>(Configuration.GetSection("HiRezSettings"));
            services.TryAddTransient(typeof(LoggingHandler<>));

            // todo refactor to a real fucking factory
            services.AddTransient<IPaladinsApiClient, PaladinsApiClient>(x => CreatePaladinsApiClient(x));
            services.AddTransient<IExternalServiceTimer, ExternalServiceTimer>();
            services.AddHttpContextAccessor();
            services.AddControllers().AddNewtonsoftJson();
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddSingleton(sp => _mapperConfiguration.CreateMapper());
            services.AddCacheServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRequestLogMiddleware();

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        private PaladinsApiClient CreatePaladinsApiClient(IServiceProvider p)
        {
            var clientSettings = p.GetRequiredService<IOptions<HiRezSettings>>().Value;
            var externalServiceTimer = p.GetRequiredService<IExternalServiceTimer>();
            var logger = p.GetRequiredService<ILogger<PaladinsApiClient>>();
            var retryPolicy = new RetryPolicy<HiRezApiRetryStrategy>(new ExponentialBackoffRetryStrategy());
            var timestampProvider = new DateTimeUtcTimeStampProvider();
            var fileSessionRepository = new JsonFileSessionRepository(Environment.CurrentDirectory, timestampProvider);
            var credentials = new HiRezApiCredentials(clientSettings.DevKey, clientSettings.AuthKey, timestampProvider,
                new DefaultSessionProvider(timestampProvider, fileSessionRepository));

            var client = new PaladinsApiClient(Platform.Pc, credentials, new LoggingHandler<PaladinsApiClient>(logger, externalServiceTimer));
            client.SetRetryPolicy(retryPolicy);
            return client;
        }
    }
}