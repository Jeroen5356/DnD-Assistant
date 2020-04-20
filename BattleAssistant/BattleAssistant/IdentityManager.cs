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
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityManager(
            UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _userStore = userStore;
            _roleManager = roleManager;
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

        public List<IdentityRole> GetAllRoles()
        {
            return _roleManager.Roles.ToList();
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
