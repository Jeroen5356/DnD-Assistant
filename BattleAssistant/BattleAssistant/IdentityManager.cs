using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public class IdentityManager : IIdentityManager
    {
        //private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        //private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly ILogger<IdentityManager<TUser>> _logger;
        //private readonly IEmailSender _emailSender;

        public IdentityManager(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            //IUserEmailStore<IdentityUser> emailStore,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            //_emailStore = emailStore;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> AddUserAsync(IdentityUser user, string password, CancellationToken cancellationToken = default)
        {
            try
            {
                await _userStore.SetUserNameAsync(user, user.Email, cancellationToken);
                //await _emailStore.SetEmailAsync(user, user.Email, cancellationToken);
                return await _userManager.CreateAsync(user, password);
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError[] { new IdentityError { Description = ex.Message } });
            }
        }
    }
}
