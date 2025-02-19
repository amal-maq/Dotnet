using EventApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EventApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        // Add controllers
                        services.AddControllers();
                        
                        // Register the EventService with Dependency Injection
                        services.AddSingleton<IEventService, EventService>();
                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseHttpsRedirection();
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers(); // Map controllers to endpoints
                        });
                    });
                });
    }
}
