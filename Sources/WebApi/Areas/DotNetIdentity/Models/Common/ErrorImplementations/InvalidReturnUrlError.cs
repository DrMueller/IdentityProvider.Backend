namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models.Common.ErrorImplementations
{
    public class InvalidReturnUrlError : ServiceError
    {
        public InvalidReturnUrlError()
            : base("Invalid return URL")
        {
        }
    }
}