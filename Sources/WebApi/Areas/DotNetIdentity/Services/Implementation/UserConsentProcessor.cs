using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses;
using Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services.Implementation
{
    public class UserConsentProcessor : IUserConsentProcessor
    {
        private readonly IClientStore _clientStore;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IUrlAligner _urlAligner;

        public UserConsentProcessor(
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IUrlAligner urlAligner)
        {
            _interaction = interaction;
            _clientStore = clientStore;
            _urlAligner = urlAligner;
        }

        public async Task<ProcessedConsentResult> ProcessUserConsentAsync(UserConsentAcceptance userAcceptance)
        {
            var relativeReturnPath = _urlAligner.MakePathRelative(userAcceptance.AbsoluteReturnPath);

            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnPath);
            if (context == null)
            {
                return ProcessedConsentResult.CreateFailure("Invalid return URL");
            }

            var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
            if (client == null)
            {
                return ProcessedConsentResult.CreateFailure("Invalid client ID");
            }

            // The allowRememberConsent check is not made in the template
            // But couldn't that quite easily be hacked?
            var consentResponse = MapToResponse(userAcceptance, client.AllowRememberConsent);
            await _interaction.GrantConsentAsync(context, consentResponse);

            return ProcessedConsentResult.CreateSuccess(userAcceptance.AbsoluteReturnPath);
        }

        private static ConsentResponse MapToResponse(UserConsentAcceptance userAcceptance, bool allowRememberConsent)
        {
            if (!userAcceptance.ConsentWasAccepted)
            {
                return ConsentResponse.Denied;
            }

            return new ConsentResponse
            {
                RememberConsent = allowRememberConsent && userAcceptance.RememberConsent,
                ScopesConsented = userAcceptance.ConsentedScopeNames
            };
        }
    }
}