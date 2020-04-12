using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.DataAccess.DbContexts;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess;
using Mmu.Mlh.WebUtilities.Areas.ExceptionHandling.Initialization;

namespace Mmu.IdentityProvider.WebApi.Infrastructure.Initialization
{
    public static class AppInitializer
    {
        public static void Initialize(IApplicationBuilder app)
        {
            InitializeDatabases(app);

            app.UseGlobalExceptionHandler();
            app.UseCors("All");
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseIdentityServer();

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