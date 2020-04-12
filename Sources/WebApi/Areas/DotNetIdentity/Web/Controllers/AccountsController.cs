using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;

        public AccountsController(
            IMapper mapper,
            IAccountService accountService)
        {
            _mapper = mapper;
            _accountService = accountService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] AccountToCreateDto dto)
        {
            var accountToCreate = new AccountToCreate(dto.UserName, dto.Password);
            var accountCreateionResult = await _accountService.CreateAccountAsync(accountToCreate);
            var resultDto = _mapper.Map<AccountCreationResultDto>(accountCreateionResult);

            return Ok(resultDto);
        }
    }
}