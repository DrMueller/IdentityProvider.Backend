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
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireConsent = false,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
                        "http://localhost:4200/account/info"
                    },
                    PostLogoutRedirectUris =
                    {
                        "http://localhost:4200/account/logout"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "api.write"
                    },
                    AllowedCorsOrigins = new List<string>
                    {
                        "http://localhost:4200"
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