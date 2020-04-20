using BattleAssistant.Pages.Manage;
using System;
using System.Threading.Tasks;

namespace BattleAssistant
{
    public interface IViewModelFactory
    {
        Task<ManageUsersViewModel> CreateManageUsersViewModel();
        Task<EditUserViewModel> CreateEditUserViewModel(string userId);
    }
}