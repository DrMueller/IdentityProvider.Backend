using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Mmu.IdentityProvider.WebApi.Areas.Common.DataAccess
{
    public abstract class DesignTimeContextFactoryBase
    {
        protected static string ReadConnectionString()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var currentDir = Directory.GetCurrentDirectory();

            var configRoot = new ConfigurationBuilder()
                .SetBasePath(currentDir)
                .AddJsonFile("appsettings.json", false, false)
                .AddJsonFile($"appsettings.{environment}.json", true)
                .Build();

            var section = configRoot.GetSection("ConnectionStrings");
            var connectionString = section.GetValue<string>("DefaultConnection");

            return connectionString;
        }
    }
}