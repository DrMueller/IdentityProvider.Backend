namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Web.Dtos
{
    public class LoginResultDto
    {
        public string ErrorMessage { get; set; }
        public string SuccessReturnUrl { get; set; }
        public bool WasSuccess { get; set; }
    }
}