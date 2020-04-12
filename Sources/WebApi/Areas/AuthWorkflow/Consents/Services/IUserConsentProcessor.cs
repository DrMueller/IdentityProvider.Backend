using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.UserResponses;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Services
{
    public interface IUserConsentProcessor
    {
        Task<Either<ServiceError, ProcessedUserConsent>> ProcessUserConsentAsync(UserConsentAcceptance userAcceptance);
    }
}