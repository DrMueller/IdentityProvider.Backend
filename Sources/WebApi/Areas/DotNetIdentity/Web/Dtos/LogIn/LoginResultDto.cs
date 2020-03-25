namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Web.Dtos.LogIn
{
    public class LoginResultDto
    {
        public string ErrorMessage { get; set; }
        public string SuccessReturnUrl { get; set; }
        public bool WasSuccess { get; set; }

        public static LoginResultDto CreateFailure(string errorMessage)
        {
            return new LoginResultDto
            {
                ErrorMessage = errorMessage,
                SuccessReturnUrl = string.Empty,
                WasSuccess = true
            };
        }

        public static LoginResultDto CreateSuccess(string returnUrl)
        {
            return new LoginResultDto
            {
                ErrorMessage = string.Empty,
                SuccessReturnUrl = returnUrl,
                WasSuccess = true
            };
        }
    }
}