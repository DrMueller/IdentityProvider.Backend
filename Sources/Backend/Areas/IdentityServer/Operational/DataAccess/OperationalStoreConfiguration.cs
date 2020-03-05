using System;
using System.Reflection;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.DataAccess
{
    public static class OperationalStoreConfiguration
    {
        private static readonly Lazy<string> _lazyMigrationAssemblyName = new Lazy<string>(() => typeof(Startup).GetTypeInfo().Assembly.GetName().Name);

        public static void Configure(OperationalStoreOptions options, string connectionString)
        {
            options.ConfigureDbContext = builder =>
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(_lazyMigrationAssemblyName.Value));
            options.DefaultSchema = Constants.SchemaIdentityOperational;
        }
    }
}