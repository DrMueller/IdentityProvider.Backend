using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts.RequestResults;
using Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services.Implementation
{
    public class ConsentRequestFactory : IConsentRequestFactory
    {
        private readonly IClientStore _clientStore;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IResourceStore _resourceStore;
        private readonly IUrlAligner _urlAligner;

        public ConsentRequestFactory(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            IUrlAligner urlAligner)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
            _urlAligner = urlAligner;
        }

        public async Task<ConsentRequestResult> CreateRequestAsync(string absoluteReturnPath)
        {
            var relativeReturnPath = _urlAligner.MakePathRelative(absoluteReturnPath);
            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnPath);
            if (context == null)
            {
                return ConsentRequestResult.CreateFailure("Invalid return URL");
            }

            var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
            if (client == null)
            {
                return ConsentRequestResult.CreateFailure("Invalid client ID");
            }

            var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(context.ScopesRequested);
            if (resources == null || (!resources.IdentityResources.Any() && !resources.ApiResources.Any()))
            {
                return ConsentRequestResult.CreateFailure("No scope matching");
            }

            var identityScopes = MapIdentityResources(resources.IdentityResources);
            var resourceScopes = MapApiResources(resources.ApiResources);

            var clientUri = string.IsNullOrEmpty(client.ClientUri) ? Maybe.CreateSome(client.ClientUri) : Maybe.CreateNone<string>();

            var consentRequest = new Models.Consents.Requsts.ConsentRequest(
                absoluteReturnPath,
                client.ClientName,
                clientUri,
                client.AllowRememberConsent,
                identityScopes,
                resourceScopes);

            return ConsentRequestResult.CreateSuccess(consentRequest);
        }

        private static IReadOnlyCollection<ScopeToConsent> MapIdentityResources(IEnumerable<IdentityResource> resources)
        {
            return resources.Select(
                r => new ScopeToConsent(
                    r.Description,
                    r.DisplayName,
                    r.Name,
                    r.Emphasize,
                    r.Required)
            ).ToList();
        }

        private static IReadOnlyCollection<ScopeToConsent> MapApiResources(IEnumerable<ApiResource> apiResources)
        {
            return apiResources.SelectMany(f => f.Scopes).Select(
                    scope => new ScopeToConsent(
                        scope.Description,
                        scope.DisplayName,
                        scope.Name,
                        scope.Emphasize,
                        scope.Required))
                .ToList();
        }
    }
}