using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Accounts;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.LogIn;
using Mmu.IdentityProvider.WebApi.Infrastructure.UrlAlignment.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Eithers;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IClientStore _clientStore;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUrlAligner _urlAligner;
        private readonly ILoginService _logInService;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore,
            IUrlAligner urlAligner,
            ILoginService logInService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _urlAligner = urlAligner;
            _logInService = logInService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] AccountToCreateDto dto)
        {
            var appUser = new ApplicationUser
            {
                UserName = dto.UserName
            };

            var identityResult = await _userManager.CreateAsync(appUser, dto.Password);
            return Ok();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> LogInAsync([FromBody] LogInRequestDto dto)
        {
            var loginRequest = new LogInRequest(
                dto.UserName,
                dto.Password,
                dto.RememberLogin,
                dto.ReturnUrl);

            var loginResult = await _logInService.LogInAsync(loginRequest);

            var resultDto = loginResult
                .MapRight(f => LoginResultDto.CreateSuccess(f.ReturnPath))
                .Reduce(f => LoginResultDto.CreateFailure(f.ErrorMessage));

            return Ok(resultDto);
        }

        [HttpPost("LogOut")]
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}