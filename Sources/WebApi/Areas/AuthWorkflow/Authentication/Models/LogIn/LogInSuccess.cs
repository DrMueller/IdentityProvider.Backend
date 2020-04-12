using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.IdentityProvider.WebApi.Areas.AuthWorkflow.Authentication.Models
{
    public class LogInSuccess
    {
        public string ReturnPath { get; }

        public LogInSuccess(string returnPath)
        {
            Guard.StringNotNullOrEmpty(() => returnPath);

            ReturnPath = returnPath;
        }
    }
}