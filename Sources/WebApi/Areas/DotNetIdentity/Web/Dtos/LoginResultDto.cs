using System.Collections.Generic;
using System.Security.Claims;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos
{
    public class LoginResultDto
    {
        public string ReturnUrl { get; set; }
    }
}