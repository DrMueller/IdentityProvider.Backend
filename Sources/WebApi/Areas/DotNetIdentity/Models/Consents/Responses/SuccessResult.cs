namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses
{
    public class SuccessResult : ProcessedConsentResult
    {
        public override string ErrorMessage { get; } = string.Empty;
        public override string RedirectPath { get; }
        public override bool WasSuccess { get; } = true;

        public SuccessResult(string redirectPath)
        {
            RedirectPath = redirectPath;
        }
    }
}