using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.UserResponses;
using Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Services.Implementation
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

        public async Task<Either<ServiceError, ProcessedUserConsent>> ProcessUserConsentAsync(UserConsentAcceptance userAcceptance)
        {
            var relativeReturnPath = _urlAligner.MakePathRelative(userAcceptance.AbsoluteReturnPath);

            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnPath);
            if (context == null)
            {
                return ServiceError.CreateInvalidReturnUrlError();
            }

            var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
            if (client == null)
            {
                return new ServiceError("Invalid client ID");
            }

            var consentResponse = MapToResponse(userAcceptance);
            await _interaction.GrantConsentAsync(context, consentResponse);

            return new ProcessedUserConsent(userAcceptance.AbsoluteReturnPath);
        }

        private static ConsentResponse MapToResponse(UserConsentAcceptance userAcceptance)
        {
            if (!userAcceptance.ConsentWasAccepted)
            {
                return ConsentResponse.Denied;
            }

            return new ConsentResponse
            {
                RememberConsent = userAcceptance.RememberConsent,
                ScopesConsented = userAcceptance.ConsentedScopeNames
            };
        }
    }
}