using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.UserResponses;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Services;
using Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Controllers
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ProcessedConsentResultDto>> AcceptConsentAsync(ConsentUserResponseDto dto)
        {
            var userConsent = new UserConsentAcceptance(
                dto.ReturnUrl,
                dto.ConsentAccepted,
                dto.RememberConsent,
                dto.ConsentedScopeNames);

            var processingResult = await _userConsentProcessor.ProcessUserConsentAsync(userConsent);
            var resultDto = _mapper.Map<ProcessedConsentResultDto>(processingResult);

            return Ok(resultDto);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ConsentRequestDto>> GetConsentRequestAsync([FromQuery] string returnUrl)
        {
            var consentRequestResult = await _consentRequestFactory.CreateRequestAsync(returnUrl);

            var dto = consentRequestResult
                .MapRight(req => _mapper.Map<ConsentRequestDto>(req))
                .Reduce(f => new ConsentRequestDto());

            return Ok(dto);
        }
    }
}