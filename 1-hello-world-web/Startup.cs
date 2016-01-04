using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;

namespace HelloWorldWeb 
{
    public class Startup 
    {
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async ctx => 
            {
                ctx.Response.StatusCode = 200;
                await ctx.Response.WriteAsync("Hello world!");
            });
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }    
}