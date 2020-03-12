using System.Threading.Tasks;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.Web.Dtos;

namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class IdentityErrorsController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IIdentityServerInteractionService _interaction;

        public IdentityErrorsController(IIdentityServerInteractionService interaction, IWebHostEnvironment environment)
        {
            _interaction = interaction;
            _environment = environment;
        }

        [HttpPost]
        public async Task<ActionResult<IdentityErrorDto>> GetErrorAsync([FromBody] IdentityErrorRequestDto errorRequest)
        {
            var message = await _interaction.GetErrorContextAsync(errorRequest.ErrorId);
            IdentityErrorDto dto;

            if (message != null)
            {
                dto = new IdentityErrorDto
                {
                    Message = message.Error,
                    MessageDescription = _environment.IsDevelopment() ? message.ErrorDescription : string.Empty
                };
            }
            else
            {
                dto = IdentityErrorDto.CreateEmpty();
            }

            return Ok(dto);
        }
    }
}