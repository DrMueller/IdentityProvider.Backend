using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mmu.IdentityProvider.WebApi.Areas.Common.DataAccess;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess.DbContexts
{
    public class IdentityConfigDbContextDesignTimeFactory : DesignTimeContextFactoryBase, IDesignTimeDbContextFactory<ConfigurationDbContext>
    {
        public ConfigurationDbContext CreateDbContext(string[] args)
        {
            var connectionString = ReadConnectionString();
            var dbContextOptions = new DbContextOptionsBuilder<ConfigurationDbContext>()
                .UseSqlServer(connectionString)
                .ConfigureWarnings(f => f.Throw())
                .Options;

            var opt = new ConfigurationStoreOptions();
            ConfigStoreConfiguration.Configure(opt, connectionString);
            return new ConfigurationDbContext(dbContextOptions, opt);
        }
    }
}