namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.UserResponses
{
    public class ProcessedUserConsent
    {
        public string RedirectPath { get; }

        public ProcessedUserConsent(string redirectPath)
        {
            RedirectPath = redirectPath;
        }
    }
}