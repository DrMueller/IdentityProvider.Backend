using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses
{
    public class FailureResult : ProcessedConsentResult
    {
        public override string ErrorMessage { get; }
        public override string RedirectPath { get; } = string.Empty;
        public override bool WasSuccess { get; } = false;

        public FailureResult(string errorMessage)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);

            ErrorMessage = errorMessage;
        }
    }
}