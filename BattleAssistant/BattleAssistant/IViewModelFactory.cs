using BattleAssistant.Pages.Manage;
using System;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public interface IViewModelFactory
    {
        Task<ManageUsersViewModel> CreateManageUsersViewModel();
        Task<ManageUserViewModel> CreateManageUserViewModel(string userId);
    }
}