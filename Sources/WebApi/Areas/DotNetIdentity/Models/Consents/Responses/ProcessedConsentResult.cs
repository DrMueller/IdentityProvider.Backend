namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses
{
    public abstract class ProcessedConsentResult
    {
        public abstract bool WasSuccess { get; }
        public abstract string ErrorMessage { get; }
        public abstract string RedirectPath { get; }

        public static ProcessedConsentResult CreateFailure(string errorMessage)
        {
            return new FailureResult(errorMessage);
        }

        public static ProcessedConsentResult CreateSuccess(string redirectPath)
        {
            return new SuccessResult(redirectPath);
        }
    }
}