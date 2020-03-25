using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Common.ErrorImplementations;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Common
{
    public class ServiceError
    {
        public string ErrorMessage { get; }

        public ServiceError(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);
            ErrorMessage = errorMessage;
        }

        public static ServiceError CreateInvalidReturnUrlError()
        {
            return new InvalidReturnUrlError();
        }
    }
}