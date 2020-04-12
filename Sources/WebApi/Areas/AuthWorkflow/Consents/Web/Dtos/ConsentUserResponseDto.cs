using System.Collections.Generic;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos
{
    public class ConsentUserResponseDto
    {
        public List<string> ConsentedScopeNames { get; set; }
        public bool ConsentAccepted { get; set; }
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; }
    }
}