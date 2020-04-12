using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services
{
    public interface IAccountService
    {
        Task<AccountCreationResult> CreateAccountAsync(AccountToCreate accountToCreate);
    }
}