using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Responses
{
    public class UserConsentAcceptance
    {
        public string AbsoluteReturnPath { get; }
        public IReadOnlyCollection<string> ConsentedScopeNames { get; }
        public bool ConsentWasAccepted { get; }
        public bool RememberConsent { get; }

        public UserConsentAcceptance(
            string absoluteReturnPath,
            bool consentWasAccepted,
            bool rememberConsent,
            IReadOnlyCollection<string> consentedScopeNames)
        {
            Guard.StringNotNullOrEmpty(() => absoluteReturnPath);
            Guard.ObjectNotNull(() => consentedScopeNames);

            AbsoluteReturnPath = absoluteReturnPath;
            ConsentWasAccepted = consentWasAccepted;
            RememberConsent = rememberConsent;
            ConsentedScopeNames = consentedScopeNames;
        }
    }
}