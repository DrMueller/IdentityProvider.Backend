using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models
{
    public class LogInResult
    {
        public string ErrorMessage { get; }
        public string ReturnUrl { get; }
        public bool WasSuccess { get; }

        public LogInResult(bool wasSuccess, string errorMessage, string returnUrl)
        {
            Guard.StringNotNullOrEmpty(() => errorMessage);
            Guard.StringNotNullOrEmpty(() => returnUrl);

            WasSuccess = wasSuccess;
            ErrorMessage = errorMessage;
            ReturnUrl = returnUrl;
        }

        public static LogInResult CreateFailure(string errorMessage)
        {
            return new LogInResult( rrorMessage);
        }

        public static LogInResult CreateSuccess(ConsentRequest consentRequest)
        {
            return new SuccessResult(consentRequest);
        }
    }
}