using System.IdentityModel.Tokens.Jwt;
using IdentityServer4.EntityFramework.DbContexts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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
            InitializeCors(services);

            var connectionString = config.GetConnectionString("DefaultConnection");

            InitializeAspNetIdentity(services, connectionString);
            InitializeIdentityServer(services, connectionString);
            InitializeIdentityClient(services);

            services.AddControllers();
        }

        private static void InitializeIdentityClient(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(
                    options =>
                    {
                        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                    })
                .AddCookie()
                .AddOpenIdConnect(
                    OpenIdConnectDefaults.AuthenticationScheme,
                    options =>
                    {
                        options.Authority = "https://localhost:44339";
                        options.RequireHttpsMetadata = false;
                        options.ClientId = "AngularClient";
                        options.ClientSecret = "secret";
                        options.ResponseType = "code";
                        options.SaveTokens = true;
                    })
                .AddIdentityServerAuthentication(
                    options =>
                    {
                        options.Authority = "https://localhost:44339";
                        options.RequireHttpsMetadata = false;
                        options.ApiName = "CoolWebApi";
                    });
        }

        private static void InitializeAspNetIdentity(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<IdentityDbContext>(
                options =>
                    options.UseSqlServer(connectionString));

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => false;
                });

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
                        options.UserInteraction.LoginUrl = "http://localhost:4200/account/login";
                        options.UserInteraction.ErrorUrl = "http://localhost:4200/identity-errors/error-display";
                        options.UserInteraction.ConsentUrl = "http://localhost:4200/account/consent";
                    })
                .AddConfigurationStore(opt => ConfigStoreConfiguration.Configure(opt, connectionString))
                .AddOperationalStore<PersistedGrantDbContext>(opt => OperationalStoreConfiguration.Configure(opt, connectionString))
                .AddAspNetIdentity<ApplicationUser>()
                .AddDeveloperSigningCredential();
        }

        private static void InitializeCors(IServiceCollection services)
        {
            services.AddCors(
                options =>
                {
                    options.AddPolicy(
                        "All",
                        builder =>
                            builder
                                .WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials());
                });
        }
    }
}