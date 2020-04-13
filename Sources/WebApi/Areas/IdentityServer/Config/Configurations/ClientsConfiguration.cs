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
                    ClientId = "AngularClient",
                    ClientName = "Fun Angular Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    AllowRememberConsent = true,
                    RequireConsent = true,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
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
                        "http://localhost:4201"
                    }
                }
            };
    }
}