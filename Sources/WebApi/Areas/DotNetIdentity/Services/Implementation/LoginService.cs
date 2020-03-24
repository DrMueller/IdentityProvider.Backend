using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.LogIn;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services.Implementation
{
    public class LoginService : ILoginService
    {
        private readonly IIdentityServerInteractionService _interaction;

        public LoginService(
            IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
        }

        public async Task Tra()
        {

        }

        public Task<LogInResult> LogInAsync(LogInRequest request)
        {
            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnPath);

            if (context == null)
            {
                return BadRequest("Invalid return URL");
            }

            var signInResult = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, dto.RememberLogin, true);

            var loginResultDto = new LoginResultDto
            {
                SuccessReturnUrl = dto.ReturnUrl,
                WasSuccess = signInResult.Succeeded
            };

            if (signInResult.IsLockedOut)
            {
                loginResultDto.ErrorMessage = "User is locked out.";
            }
            else if (signInResult.IsNotAllowed)
            {
                loginResultDto.ErrorMessage = "User is not allowed.";
            }
            else if (!signInResult.Succeeded)
            {
                loginResultDto.ErrorMessage = "Invalid credentials";
            }

            return Ok(loginResultDto);
        }
    }
}
