using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts
{
    public class ScopeToConsent
    {
        public string Description { get; }
        public string DisplayName { get; }
        public bool DoEmphasize { get; }
        public bool IsRequired { get; }
        public string UniqueName { get; }

        public ScopeToConsent(
            string description,
            string displayName,
            string uniqueName,
            bool doEmphasize,
            bool isRequired)
        {
            Guard.StringNotNullOrEmpty(() => description);
            Guard.StringNotNullOrEmpty(() => displayName);
            Guard.StringNotNullOrEmpty(() => uniqueName);

            Description = description;
            DisplayName = displayName;
            UniqueName = uniqueName;
            DoEmphasize = doEmphasize;
            IsRequired = isRequired;
        }
    }
}