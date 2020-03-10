namespace Mmu.IdentityProvider.WebApi.Areas.IdentityServer.Operational.Web.Dtos
{
    public class IdentityErrorDto
    {
        public string Message { get; set; }

        public string MessageDescription { get; set; }

        public static IdentityErrorDto CreateEmpty()
        {
            return new IdentityErrorDto
            {
                Message = "No Error",
                MessageDescription = "No error decsription"
            };
        }
    }
}