using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models.LogOut;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Services;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Dtos;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Dtos.LogOut;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public AuthenticationController(
            IMapper mapper,
            IAuthenticationService authenticationService)
        {
            _mapper = mapper;
            _authenticationService = authenticationService;
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

            var loginResult = await _authenticationService.LogInAsync(loginRequest);
            var resultDto = _mapper.Map<LoginResultDto>(loginResult);

            return Ok(resultDto);
        }

        [HttpPost("LogOut")]
        public async Task<ActionResult<LogOutResultDto>> LogOutAsync([FromBody] LogOutRequestDto dto)
        {
            var logOutRequest = new LogOutRequest(dto.LogOutId);
            var logOutResult = await _authenticationService.LogOutAsync(logOutRequest);
            var resultDto = _mapper.Map<LogOutResultDto>(logOutResult);
            
            return Ok(resultDto);
        }
    }
}