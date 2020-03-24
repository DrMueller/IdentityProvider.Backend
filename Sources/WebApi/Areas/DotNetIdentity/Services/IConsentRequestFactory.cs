using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts.RequestResults;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services
{
    public interface IConsentRequestFactory
    {
        Task<ConsentRequestResult> CreateRequestAsync(string absoluteReturnPath);
    }
}