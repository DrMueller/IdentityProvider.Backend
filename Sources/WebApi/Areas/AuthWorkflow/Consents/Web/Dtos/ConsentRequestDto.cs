using System.Collections.Generic;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos
{
    public class ConsentRequestDto
    {
        public bool AllowRememberConsent { get; set; }
        public string ClientName { get; set; }
        public string ClientUri { get; set; }
        public List<ScopeToConsentDto> IdentityScopes { get; set; }
        public List<ScopeToConsentDto> ResourceScopes { get; set; }
        public string ReturnUrl { get; set; }
    }
}