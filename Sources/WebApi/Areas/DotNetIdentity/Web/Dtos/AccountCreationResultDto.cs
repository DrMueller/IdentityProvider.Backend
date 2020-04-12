using System.Collections.Generic;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos
{
    public class AccountCreationResultDto
    {
        public IReadOnlyCollection<string> ErrorMessages { get; set; }
    }
}