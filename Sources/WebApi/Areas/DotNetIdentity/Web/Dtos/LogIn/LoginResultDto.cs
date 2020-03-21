namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.LogIn
{
    public class LoginResultDto
    {
        public string ErrorMessage { get; set; }
        public string SuccessReturnUrl { get; set; }
        public bool WasSuccess { get; set; }
    }
}