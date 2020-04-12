using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.Configurations
{
    public static class ClientsConfiguration
    {
        public static IEnumerable<Client> Config =>
            new List<Client>
            {
                new Client
                {
                    RequireConsent = false,
                    ClientId = "ConsoleClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api.write" }
                },
                new Client
                {
                    ClientId = "AngularClient",
                    ClientName = "Fun Angular Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowRememberConsent = true,
                    RequireConsent = true,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
                        "http://localhost:4201/account/info",
                        "http://localhost:4201/account/info"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4201"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api.write",
                        "api.read"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200",
                        "http://localhost:4201"
                    }
                },
                new Client
                {
                    ClientId = "IdentityApi",
                    AllowedGrantTypes = GrantTypes.CodeAndClientCredentials,
                    RequireConsent = false,
                    RequirePkce = false,
                    RedirectUris = { "https://localhost:44339/signin-oidc" },
                    PostLogoutRedirectUris = { "https://localhost:44339/signout-callback-oidc" },
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "api.write"
                    }
                }
            };
    }
}