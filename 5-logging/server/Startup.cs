using System;
using LoggingLibSample;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LoggingSample 
{
    public class Startup 
    {
        public Startup(ILoggerFactory loggerFactory)
        {
            var serilogLogger = new LoggerConfiguration()
                .WriteTo
                .TextWriter(Console.Out)
#if DNX451
                .WriteTo.Elasticsearch()
#endif
                .MinimumLevel.Verbose()
                .CreateLogger();

            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddSerilog(serilogLogger);
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<CarsContext, CarsContext>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<RequestIdMiddleware>();
            app.UseMiddleware<RequestUrlLoggerMiddleware>();
            app.UseMvc();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }    
}