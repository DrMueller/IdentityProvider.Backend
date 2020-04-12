using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.ConsentRequests;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Services
{
    public interface IConsentRequestFactory
    {
        Task<Either<ServiceError, ConsentRequest>> CreateRequestAsync(string absoluteReturnPath);
    }
}