using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models
{
    public class LogInRequest
    {
        public string Password { get; }
        public bool RememberLogin { get; }
        public string ReturnPath { get; }
        public string UserName { get; }

        public LogInRequest(string userName, string password, bool rememberLogin, string returnPath)
        {
            Guard.StringNotNullOrEmpty(() => userName);
            Guard.StringNotNullOrEmpty(() => returnPath);

            UserName = userName;
            Password = password;
            RememberLogin = rememberLogin;
            ReturnPath = returnPath;
        }
    }
}