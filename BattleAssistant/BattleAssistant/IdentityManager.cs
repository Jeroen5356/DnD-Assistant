using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public class IdentityManager : IIdentityManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;

        public IdentityManager(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore)
        {
            _userManager = userManager;
            _userStore = userStore;
        }

        public async Task<IdentityResult> AddUserAsync(IdentityUser user, string password, CancellationToken cancellationToken = default)
        {
            try
            {
                await _userStore.SetUserNameAsync(user, user.Email, cancellationToken);
                return await _userManager.CreateAsync(user, password);
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed(new IdentityError[] { new IdentityError { Description = ex.Message } });
            }
        }

        public List<IdentityUser> GetAllUsers()
        {
            return _userManager.Users.ToList();
        }

        public async Task<IList<string>> GetRolesOfUser(IdentityUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public async Task<IdentityUser> GetUser(string id)
        {
            return await _userManager.FindByIdAsync(id.ToString());
        }
    }
}
