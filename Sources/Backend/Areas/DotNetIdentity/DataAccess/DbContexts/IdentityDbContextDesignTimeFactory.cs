using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Mmu.IdentityProvider.WebApi.Areas.Common.DataAccess;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.DataAccess.DbContexts
{
    public class IdentityDbContextDesignTimeFactory : DesignTimeContextFactoryBase, IDesignTimeDbContextFactory<IdentityDbContext>
    {
        public IdentityDbContext CreateDbContext(string[] args)
        {
            var connectionString = ReadConnectionString();
            var dbContextOptions = new DbContextOptionsBuilder<IdentityDbContext>()
                .UseSqlServer(connectionString)
                .ConfigureWarnings(f => f.Throw())
                .Options;

            return new IdentityDbContext(dbContextOptions);
        }
    }
}