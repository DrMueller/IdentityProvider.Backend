using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.DataAccess.DbContexts
{
    public class IdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(Constants.Schema);
            base.OnModelCreating(builder);
        }
    }
}