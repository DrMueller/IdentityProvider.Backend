using System;
using System.Reflection;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess
{
    public static class ConfigStoreConfiguration
    {
        private static readonly Lazy<string> _lazyMigrationAssemblyName = new Lazy<string>(() => typeof(Startup).GetTypeInfo().Assembly.GetName().Name);

        public static void Configure(ConfigurationStoreOptions options, string connectionString)
        {
            options.ConfigureDbContext = builder =>
                builder.UseSqlServer(connectionString, b => b.MigrationsAssembly(_lazyMigrationAssemblyName.Value));
            options.DefaultSchema = Constants.SchemaIdentityConfiguration;
        }
    }
}