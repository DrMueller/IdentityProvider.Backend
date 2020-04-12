using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Consents.Models.ConsentRequests
{
    public class ScopeToConsent
    {
        public string Description { get; }
        public string DisplayName { get; }
        public bool Emphasize { get; }
        public bool IsRequired { get; }
        public string UniqueName { get; }

        public ScopeToConsent(
            string description,
            string displayName,
            string uniqueName,
            bool emphasize,
            bool isRequired)
        {
            Guard.StringNotNullOrEmpty(() => uniqueName);

            Description = description;
            DisplayName = displayName;
            UniqueName = uniqueName;
            Emphasize = emphasize;
            IsRequired = isRequired;
        }
    }
}