using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.Logging;

namespace HelloWorldWeb 
{
    public class Startup 
    {
        private readonly ILogger _logger;
        
        public Startup(ILoggerFactory loggerFactory) 
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole();
            
            _logger = loggerFactory.CreateLogger<Startup>();
        }
        
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async ctx => 
            {
                ctx.Response.StatusCode = 200;
                await ctx.Response.WriteAsync($"Hello world from {GetMachineName()}!");
            });
        }
        
        private static string GetMachineName() 
        {
#if DNX451
            var machineName = Environment.MachineName;
#else  
            var machineName = Environment.GetEnvironmentVariable("HOSTNAME");
            if(machineName == null) 
            {
                machineName = Environment.GetEnvironmentVariable("COMPUTERNAME");
            }
#endif
            
            return machineName;
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }    
}