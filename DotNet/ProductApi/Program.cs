using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ProductApi
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
                      
                        services.AddControllers();
                    });

                    webBuilder.Configure(app =>
                    {
                       
                        app.UseHttpsRedirection(); 
                        app.UseRouting();          
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers(); 
                        });
                    });
                });
    }
}
