using System.Threading.Tasks;
using IdentityServer4.Stores;

namespace Mmu.IdentityProvider.WebApi.Infrastructure.Extensions
{
    public static class ClientStoreExtensions
    {
        public static async Task<bool> IsPkceClientAsync(this IClientStore store, string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId))
            {
                return false;
            }

            var client = await store.FindEnabledClientByIdAsync(clientId);
            return client?.RequirePkce == true;
        }
    }
}