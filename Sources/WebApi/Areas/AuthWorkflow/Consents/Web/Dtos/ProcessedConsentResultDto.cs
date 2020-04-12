namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos
{
    public class ProcessedConsentResultDto
    {
        public string ErrorMessage { get; set; }
        public string RedirectPath { get; set; }
        public bool WasSuccess { get; set; }
    }
}