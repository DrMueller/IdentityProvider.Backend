namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents
{
    public class ProcessedConsentResultDto
    {
        public string ErrorMessage { get; set; }
        public string RedirectPath { get; set; }
        public bool WasSuccess { get; set; }
    }
}