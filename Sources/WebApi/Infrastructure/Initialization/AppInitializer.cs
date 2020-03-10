using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.DataAccess.DbContexts;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.DataAccess.DbContexts;

namespace Mmu.IdentityProvider.WebApi.Infrastructure.Initialization
{
    public static class AppInitializer
    {
        public static void Initialize(IApplicationBuilder app, IWebHostEnvironment env)
        {
            InitializeDatabases(app);
            app.UseCors("All");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();

            IdentityModelEventSource.ShowPII = true;

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllers();
                });
        }

        private static void InitializeDatabases(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            DataInitialization.Initialize(serviceScope);
            serviceScope.ServiceProvider.GetRequiredService<IdentityDbContext>().Database.Migrate();
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
        }
    }
}