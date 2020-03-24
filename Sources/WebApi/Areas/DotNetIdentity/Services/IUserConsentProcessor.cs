using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services
{
    public interface IUserConsentProcessor
    {
        Task<ProcessedConsentResult> ProcessUserConsentAsync(UserConsentAcceptance userAcceptance);
    }
}