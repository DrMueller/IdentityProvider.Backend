using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Models;

namespace Mmu.IdentityProvider.WebApi.Areas.DotNetIdentity.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AccountCreationResult> CreateAccountAsync(AccountToCreate accountToCreate)
        {
            var appUser = new ApplicationUser
            {
                UserName = accountToCreate.UserName
            };

            var createResult = await _userManager.CreateAsync(appUser, accountToCreate.Password);
            var errorDescriptions = createResult.Errors.Select(f => f.Description).ToList();

            return new AccountCreationResult(errorDescriptions);
        }
    }
}
