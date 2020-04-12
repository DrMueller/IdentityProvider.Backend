namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Common.ErrorImplementations
{
    public class InvalidReturnUrlError : ServiceError
    {
        public InvalidReturnUrlError()
            : base("Invalid return URL")
        {
        }
    }
}