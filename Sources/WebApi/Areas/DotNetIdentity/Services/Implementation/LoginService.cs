using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Common;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.LogIn;
using Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUrlAligner _urlAligner;

        public LoginService(
            IUrlAligner urlAligner,
            IIdentityServerInteractionService interaction,
            SignInManager<ApplicationUser> signInManager)
        {
            _urlAligner = urlAligner;
            _interaction = interaction;
            _signInManager = signInManager;
        }

        public async Task<Either<ServiceError, LogInSuccess>> LogInAsync(LogInRequest request)
        {
            var relativeReturnPath = _urlAligner.MakePathRelative(request.ReturnPath);
            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnPath);

            if (context == null)
            {
                return ServiceError.CreateInvalidReturnUrlError();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(
                request.UserName,
                request.Password,
                request.RememberLogin,
                true);

            if (signInResult.IsLockedOut)
            {
                return new ServiceError("User is locked out.");
            }

            if (signInResult.IsNotAllowed)
            {
                return new ServiceError("User is not allowed.");
            }

            if (!signInResult.Succeeded)
            {
                return new ServiceError("Invalid credentials.");
            }

            return new LogInSuccess(request.ReturnPath);
        }
    }
}