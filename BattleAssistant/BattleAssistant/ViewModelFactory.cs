using BattleAssistant.Pages.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public class ViewModelFactory : IViewModelFactory
    {
        private IIdentityManager _identityManager;

        public ViewModelFactory(IIdentityManager identityManager)
        {
            _identityManager = identityManager;
        }

        public async Task<ManageUsersViewModel> CreateManageUsersViewModel()
        {
            var manageUsersViewModel = new ManageUsersViewModel();
            var allUsers = _identityManager.GetAllUsers();
            foreach (var user in allUsers)
            {
                manageUsersViewModel.UserViewModels.Add(await CreateManageUserViewModelForUser(user));
            }

            return manageUsersViewModel;
        }

        private async Task<ManageUserViewModel> CreateManageUserViewModelForUser(Microsoft.AspNetCore.Identity.IdentityUser user)
        {
            var rolesOfUser = await _identityManager.GetRolesOfUser(user);

            return new ManageUserViewModel
            {
                Id = user.Id,
                Email = user.Email,
                UserName = user.UserName,
                Roles = string.Join(",", rolesOfUser.ToArray())
            };
        }

        public async Task<EditUserViewModel> CreateEditUserViewModel(string userId)
        {
            var user = await _identityManager.GetUser(userId);
            var rolesOfUser = await _identityManager.GetRolesOfUser(user);
            var allRoles = _identityManager.GetAllRoles();

            var userIsInRole = new List<UserRole>();
            allRoles.ForEach(r => userIsInRole.Add(
                new UserRole { 
                    RoleName = r.Name, 
                    UserIsInRole = rolesOfUser.Contains(r.Name) }
                ));

            return new EditUserViewModel { 
                UserName = user.UserName, 
                UserIsInRole = userIsInRole
            };
        }
    }
}
