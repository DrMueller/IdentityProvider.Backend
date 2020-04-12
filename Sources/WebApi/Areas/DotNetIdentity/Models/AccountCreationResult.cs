using System.Collections.Generic;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models
{
    public class AccountCreationResult
    {
        public IReadOnlyCollection<string> ErrorMessages { get; }

        public AccountCreationResult(IReadOnlyCollection<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}