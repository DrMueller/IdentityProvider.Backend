namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Consents.Requsts.RequestResults
{
    public abstract class ConsentRequestResult
    {
        public static ConsentRequestResult CreateFailure(string errorMessage)
        {
            return new FailureResult(errorMessage);
        }

        public static ConsentRequestResult CreateSuccess(ConsentRequest consentRequest)
        {
            return new SuccessResult(consentRequest);
        }
    }
}