using Microsoft.AspNet.Hosting;

namespace HelloWorldWeb
{
    public static class Program 
    {
        public static void Main(string[] args) 
        {
            var configuration = WebApplicationConfiguration.GetDefault(args);            
            var application = new WebApplicationBuilder()
                .UseStartup<Startup>()
                .UseConfiguration(configuration)
                .Build();
                
            application.Run();
        }
    }
}