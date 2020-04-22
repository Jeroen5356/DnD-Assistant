using BattleAssistant.Pages.Manage;
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

        public async Task ChangeRolesOfUser(string username, List<UserRole> roles)
        {
            var user = await _userManager.FindByNameAsync(username);
            var taskList = new List<Task>();
            foreach (var role in roles.Where(r => !r.UserIsInRole))
            {
                taskList.Add(_userManager.RemoveFromRoleAsync(user, role.RoleName));
            }
            foreach (var role in roles.Where(r => r.UserIsInRole))
            {
                taskList.Add(_userManager.AddToRoleAsync(user, role.RoleName));
            }

            WaitAll(taskList);
        }

        //public static void WaitAll(this IEnumerable<Task> tasks)
        //{
        //    Task.WaitAll(tasks.ToArray());
        //}
    }
}
