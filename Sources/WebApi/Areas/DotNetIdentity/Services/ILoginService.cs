using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services
{
    public interface ILoginService
    {
        Task<LogInResult> LogInAsync(LogInRequest request);
    }
}