using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.Configurations;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess
{
    public static class DataInitialization
    {
        public static void Initialize(IServiceScope serviceScope)
        {
            serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
            var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            context.Database.Migrate();

            context.Clients.RemoveRange(context.Clients.ToList());
            context.ApiResources.RemoveRange(context.ApiResources.ToList());
            context.IdentityResources.RemoveRange(context.IdentityResources.ToList());
            context.SaveChanges();

            SeedClients(context);
            SeedApiResources(context);
            SeedIdentityResources(context);

            context.SaveChanges();
        }

        private static void SeedClients(ConfigurationDbContext context)
        {
            var existingClientIds = context.Clients.Select(f => f.ClientId).ToList();
            var clientsNotInDb = ClientsConfiguration.Config.Where(f => !existingClientIds.Contains(f.ClientId));
            foreach (var client in clientsNotInDb)
            {
                context.Clients.Add(client.ToEntity());
            }
        }

        private static void SeedIdentityResources(ConfigurationDbContext context)
        {
            var existingIdentityResouceNames = context.IdentityResources.Select(f => f.Name).ToList();
            var identityResourcesNotInDb = IdentityResourcesConfiguration.Config.Where(f => !existingIdentityResouceNames.Contains(f.Name));
            foreach (var res in identityResourcesNotInDb)
            {
                context.IdentityResources.Add(res.ToEntity());
            }
        }

        private static void SeedApiResources(ConfigurationDbContext context)
        {
            var existingApiResourceNames = context.ApiResources.Select(f => f.Name).ToList();
            var apiResourcesNotInDb = ApiResourcesConfiguration.Config.Where(f => !existingApiResourceNames.Contains(f.Name));
            foreach (var res in apiResourcesNotInDb)
            {
                context.ApiResources.Add(res.ToEntity());
            }
        }
    }
}