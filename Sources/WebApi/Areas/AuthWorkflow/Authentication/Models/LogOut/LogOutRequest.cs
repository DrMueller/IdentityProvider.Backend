using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models.LogOut
{
    public class LogOutRequest
    {
        public string LogOutId { get; }

        public LogOutRequest(string logOutId)
        {
            Guard.StringNotNullOrEmpty(() => logOutId);

            LogOutId = logOutId;
        }
    }
}