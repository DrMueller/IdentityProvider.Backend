using System.Collections.Generic;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts
{
    public class ConsentRequest
    {
        public bool AllowToRememberConsent { get; }
        public string ClientName { get; }
        public Maybe<string> ClientUri { get; }
        public IReadOnlyCollection<ScopeToConsent> IdentityScopes { get; }
        public IReadOnlyCollection<ScopeToConsent> ResourceScopes { get; }
        public string ReturnUrl { get; }

        public ConsentRequest(
            string returnPath,
            string clientName,
            Maybe<string> clientUri,
            bool allowToRememberConsent,
            IReadOnlyCollection<ScopeToConsent> identityScopes,
            IReadOnlyCollection<ScopeToConsent> resourceScopes)
        {
            Guard.StringNotNullOrEmpty(() => returnPath);
            Guard.StringNotNullOrEmpty(() => clientName);
            Guard.ObjectNotNull(() => clientUri);
            Guard.ObjectNotNull(() => identityScopes);
            Guard.ObjectNotNull(() => resourceScopes);

            ReturnUrl = returnPath;
            ClientName = clientName;
            ClientUri = clientUri;
            AllowToRememberConsent = allowToRememberConsent;
            IdentityScopes = identityScopes;
            ResourceScopes = resourceScopes;
        }
    }
}