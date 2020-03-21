using System;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Accounts;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.LogIn;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IClientStore _clientStore;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IResourceStore _resourceStore;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IResourceStore resourceStore)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _resourceStore = resourceStore;
        }

        [HttpPost("Consent")]
        [Authorize]
        public async Task<ActionResult<ConsentResultDto>> AcceptConsentAsync(ConsentUserResponseDto dto)
        {
            var basePath = Request.Scheme + "://" + Request.Host;
            var relativeReturnUrl = dto.ReturnUrl.Replace(basePath, string.Empty, StringComparison.OrdinalIgnoreCase);

            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnUrl);
            if (context == null)
            {
                return BadRequest("Invalid return URL");
            }

            var consentResponse = dto.ConsentAccepted ? new ConsentResponse { ScopesConsented = dto.ConsentedScopeNames, RememberConsent = dto.RememberConsent } : ConsentResponse.Denied;

            await _interaction.GrantConsentAsync(context, consentResponse);
            return Ok(
                new ConsentResultDto
                {
                    RedirectUri = dto.ReturnUrl,
                    ClientId = context.ClientId
                });
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

        [HttpGet("Consent")]
        [Authorize]
        public async Task<ActionResult<ConsentRequestDto>> GetConsentRequestAsync([FromQuery] string returnUrl)
        {
            var basePath = Request.Scheme + "://" + Request.Host;
            var relativeReturnUrl = returnUrl.Replace(basePath, string.Empty, StringComparison.OrdinalIgnoreCase);

            // Context returning not null means, that:
            // It is a relative return url (Which we're faking)
            // The parameters are set
            // The client is known
            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnUrl);

            if (context == null)
            {
                return BadRequest("Invalid return URL");
            }

            var client = await _clientStore.FindEnabledClientByIdAsync(context.ClientId);
            if (client == null)
            {
                return BadRequest("Invalid client ID");
            }

            var resources = await _resourceStore.FindEnabledResourcesByScopeAsync(context.ScopesRequested);

            if (resources != null && (resources.IdentityResources.Any() || resources.ApiResources.Any()))
            {
                var requestDto = new ConsentRequestDto
                {
                    ReturnUrl = returnUrl,
                    IdentityScopes = resources.IdentityResources.Select(
                        f => new ScopeConsentDto
                        {
                            Description = f.Description,
                            DisplayName = f.DisplayName,
                            Emphasize = f.Emphasize,
                            IsRequired = f.Required,
                            Name = f.Name
                        }).ToList(),
                    ResourceScopes = resources.ApiResources.SelectMany(f => f.Scopes).Select(
                        f => new ScopeConsentDto
                        {
                            Description = f.Description,
                            DisplayName = f.DisplayName,
                            Emphasize = f.Emphasize,
                            IsRequired = f.Required,
                            Name = f.Name
                        }).ToList(),
                    ClientName = client.ClientName,
                    ClientUri = client.ClientUri,
                    AllowRememberConsent = client.AllowRememberConsent
                };

                return Ok(requestDto);
            }

            return BadRequest("No scope matching");
        }

        [HttpPost("LogOut")]
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResultDto>> LoginAsync([FromBody] LoginRequestDto dto)
        {
            var basePath = Request.Scheme + "://" + Request.Host;
            var relativeReturnUrl = dto.ReturnUrl.Replace(basePath, string.Empty, StringComparison.OrdinalIgnoreCase);

            // Context returning not null means, that:
            // It is a relative return url (Which we're faking)
            // The parameters are set
            // The client is known
            var context = await _interaction.GetAuthorizationContextAsync(relativeReturnUrl);

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