using System.Collections.Generic;
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
                    ClientId = "CoolClient",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes = { "api.write" }
                }
            };
    }
}