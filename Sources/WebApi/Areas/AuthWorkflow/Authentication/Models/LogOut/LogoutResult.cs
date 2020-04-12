using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models.LogOut
{
    public class LogoutResult
    {
        public string PostLogoutPath { get; }

        public LogoutResult(string postLogoutPath)
        {
            Guard.StringNotNullOrEmpty(() => postLogoutPath);

            PostLogoutPath = postLogoutPath;
        }
    }
}