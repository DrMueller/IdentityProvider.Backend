using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Mmu.IdentityProvider.WebApi.Infrastructure.Initialization;

namespace Mmu.IdentityProvider.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppInitializer.Initialize(app, env);
        }

        public void ConfigureServices(ServiceRegistry services)
        {
            ServiceInitializer.Initialize(services, Configuration);
        }
    }
}