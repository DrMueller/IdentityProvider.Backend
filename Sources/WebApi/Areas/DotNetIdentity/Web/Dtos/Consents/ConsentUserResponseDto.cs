using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents
{
    public class ConsentUserResponseDto
    {
        public List<string> ConsentedScopeNames { get; set; }
        public bool RememberConsent { get; set; }
        public string ReturnUrl { get; set; }
        public bool ConsentAccepted { get; set; }
    }
}
