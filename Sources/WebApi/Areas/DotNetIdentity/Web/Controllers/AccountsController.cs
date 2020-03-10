using System;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos;
using Mmu.IdentityProvider.WebApi.Infrastructure.Extensions;
using System.Linq;
using IdentityServer4.Events;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4.Services;
using System.Linq;
using System;
using System.Net.Http;
using System.Security.Claims;
using IdentityServer4.Stores;
using IdentityServer4.Models;
using IdentityServer4.Events;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountsController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IEventService _events;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountsController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            //IIdentityServerInteractionService interaction,
            //IClientStore clientStore,
            //IEventService events
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_interaction = interaction;
            //_clientStore = clientStore;
            //_events = events;
        }
        
        [HttpGet("UserInfo")]
        [Authorize]
        public ActionResult GetUserInfo()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        [HttpPost]
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
        public async Task<ActionResult<LoginResultDto>> LoginAsync([FromBody] LoginRequestDto dto)
        {
            //var context = await _interaction.GetAuthorizationContextAsync(dto.ReturnUrl);

            var signInResult = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, dto.RememberLogin, lockoutOnFailure: true);
            if (signInResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.UserName);
                //await _events.RaiseAsync(new UserLoginSuccessEvent(user.UserName, user.Id, user.UserName, clientId: context?.ClientId));
                
                return Ok();
            }

            return Ok();
        }
    }
}