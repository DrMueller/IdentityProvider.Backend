using System.Threading.Tasks;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Common;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.LogIn;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services
{
    public interface ILoginService
    {
        Task<Either<ServiceError, LogInSuccess>> LogInAsync(LogInRequest request);
    }
}