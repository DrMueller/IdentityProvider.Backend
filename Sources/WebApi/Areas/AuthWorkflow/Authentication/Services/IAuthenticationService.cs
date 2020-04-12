using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models.LogOut;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Services
{
    public interface IAuthenticationService
    {
        Task<Either<ServiceError, LogInSuccess>> LogInAsync(LogInRequest request);

        Task<LogoutResult> LogOutAsync(LogOutRequest request);
    }
}