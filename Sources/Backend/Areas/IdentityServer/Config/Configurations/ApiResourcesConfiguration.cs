using System.Collections.Generic;
using IdentityServer4.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Config.Configurations
{
    public static class ApiResourcesConfiguration
    {
        public static IEnumerable<ApiResource> Config =>
            new List<ApiResource>
            {
                new ApiResource
                {
                    Name = "CoolWepApi",
                    Scopes =
                    {
                        new Scope
                        {
                            Name = "api.read",
                            DisplayName = "Read only access to the API"
                        },
                        new Scope
                        {
                            Name = "api.write",
                            DisplayName = "Full access to the API"
                        }
                    }
                }
            };
    }
}