using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts.RequestResults
{
    public class SuccessResult : ConsentRequestResult
    {
        public ConsentRequest ConsentRequest { get; }

        public SuccessResult(ConsentRequest consentRequest)
        {
            Guard.ObjectNotNull(() => consentRequest);

            ConsentRequest = consentRequest;
        }
    }
}