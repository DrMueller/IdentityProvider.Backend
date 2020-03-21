namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.Consents
{
    public class ScopeConsentDto
    {
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public bool Emphasize { get; set; }
        public bool IsRequired { get; set; }
        public string Name { get; set; }
    }
}