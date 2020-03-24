using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConsentsController : ControllerBase
    {
        private readonly IConsentRequestFactory _consentRequestFactory;
        private readonly IMapper _mapper;
        private readonly IUserConsentProcessor _userConsentProcessor;

        public ConsentsController(
            IConsentRequestFactory consentRequestFactory,
            IUserConsentProcessor userConsentProcessor,
            IMapper mapper)
        {
            _consentRequestFactory = consentRequestFactory;
            _userConsentProcessor = userConsentProcessor;
            _mapper = mapper;
        }

        [HttpPost("Consent")]
        [Authorize]
        public async Task<ActionResult<ProcessedConsentResultDto>> AcceptConsentAsync(ConsentUserResponseDto dto)
        {
            var userConsent = new UserConsentAcceptance(
                dto.ReturnUrl,
                dto.ConsentWasAccepted,
                dto.RememberConsent,
                dto.ConsentedScopeNames);

            var processedResult = await _userConsentProcessor.ProcessUserConsentAsync(userConsent);
            var resultDto = _mapper.Map<ProcessedConsentResultDto>(processedResult);

            return Ok(resultDto);
        }

        [HttpGet("Consent")]
        [Authorize]
        public async Task<ActionResult<ConsentRequestDto>> GetConsentRequestAsync([FromQuery] string returnUrl)
        {
            var consentRequest = await _consentRequestFactory.CreateRequestAsync(returnUrl);
            var resultDto = _mapper.Map<ConsentRequestDto>(consentRequest);

            return Ok(resultDto);
        }
    }
}