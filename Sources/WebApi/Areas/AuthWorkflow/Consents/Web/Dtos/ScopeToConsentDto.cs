namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Web.Dtos
{
    public class ScopeToConsentDto
    {
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool Emphasize { get; set; }
        public bool IsRequired { get; set; }
        public string Name { get; set; }
    }
}