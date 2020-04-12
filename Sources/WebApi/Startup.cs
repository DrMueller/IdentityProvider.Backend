using JetBrains.Annotations;
using Lamar;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Mmu.IdentityProvider.WebApi.Infrastructure.Initialization;

namespace Mmu.IdentityProvider.WebApi
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppInitializer.Initialize(app);
        }

        [UsedImplicitly]
        public void ConfigureContainer(ServiceRegistry services)
        {
            ServiceInitializer.Initialize(services, Configuration);
        }
    }
}