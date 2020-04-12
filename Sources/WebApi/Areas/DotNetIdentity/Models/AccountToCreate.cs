using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models
{
    public class AccountToCreate
    {
        public string Password { get; }
        public string UserName { get; }

        public AccountToCreate(
            string userName,
            string password)
        {
            Guard.StringNotNullOrEmpty(() => userName);
            Guard.StringNotNullOrEmpty(() => password);

            UserName = userName;
            Password = password;
        }
    }
}