using System.Collections.Generic;
using IdentityServer4.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.Configurations
{
    public static class IdentityResourcesConfiguration
    {
        public static IEnumerable<IdentityResource> Config =>
            new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address()
            };
    }
}