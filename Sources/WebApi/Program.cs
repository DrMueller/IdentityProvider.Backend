using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mmu.IdentityProvider.WebApi
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseLamar()
                .ConfigureWebHostDefaults(
                    webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();

                        webBuilder.ConfigureServices(
                            services =>
                            {
                                // This is important, the call to AddControllers()
                                // cannot be made before the usage of ConfigureWebHostDefaults
                                services.AddControllers();
                            });
                    });
        }
    }
}