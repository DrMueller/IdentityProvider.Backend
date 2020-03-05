using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.DataAccess.DbContexts;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.DataAccess;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.DataAccess;

namespace Mmu.IdentityProvider.WebApi.Infrastructure.Initialization
{
    public static class ServiceInitializer
    {
        public static void Initialize(IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");

            InitializeAspNetIdentity(services, connectionString);
            InitializeIdentityServer(services, connectionString);
            InitializeIdentityClient(services);

            services.AddControllers();
        }

        // This method initializes the WebApi as it's own 'Client'
        // Therefore, if an access token is sent, we check if we can use it, even if we gave it to the client anyway =/
        private static void InitializeIdentityClient(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    JwtBearerDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = "http://localhost:5000";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "CoolWebApi";
                    });
        }

        private static void InitializeAspNetIdentity(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdentityDbContext>(
                options =>
                    options.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();
        }

        private static void InitializeIdentityServer(IServiceCollection services, string connectionString)
        {
            services.AddIdentityServer(
                    options =>
                    {
                        options.Events.RaiseErrorEvents = true;
                        options.Events.RaiseInformationEvents = true;
                        options.Events.RaiseFailureEvents = true;
                        options.Events.RaiseSuccessEvents = true;
                    })
                .AddConfigurationStore(opt => ConfigStoreConfiguration.Configure(opt, connectionString))
                .AddOperationalStore<PersistedGrantDbContext>(opt => OperationalStoreConfiguration.Configure(opt, connectionString))
                .AddAspNetIdentity<ApplicationUser>()
                .AddDeveloperSigningCredential();
        }
    }
}