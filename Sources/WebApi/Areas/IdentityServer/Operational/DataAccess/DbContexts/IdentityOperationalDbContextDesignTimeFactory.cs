using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mmu.IdentityProvider.WebApi.Areas.Common.DataAccess;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.DataAccess.DbContexts
{
    public class IdentityOperationalDbContextDesignTimeFactory : DesignTimeContextFactoryBase, IDesignTimeDbContextFactory<PersistedGrantDbContext>
    {
        public PersistedGrantDbContext CreateDbContext(string[] args)
        {
            var connectionString = ReadConnectionString();
            var dbContextOptions = new DbContextOptionsBuilder<PersistedGrantDbContext>()
                .UseSqlServer(connectionString)
                .ConfigureWarnings(f => f.Throw())
                .Options;

            var opt = new OperationalStoreOptions();
            OperationalStoreConfiguration.Configure(opt, connectionString);
            return new PersistedGrantDbContext(dbContextOptions, opt);
        }
    }
}