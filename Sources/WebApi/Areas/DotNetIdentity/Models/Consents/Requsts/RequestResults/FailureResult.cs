using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts.RequestResults
{
    public class FailureResult : ConsentRequestResult
    {
        public string ErrorMessage { get; }

        public FailureResult(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);

            ErrorMessage = errorMessage;
        }
    }
}