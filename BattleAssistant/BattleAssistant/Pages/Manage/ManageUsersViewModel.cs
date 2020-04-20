using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAssistant.Pages.Manage
{
    public class ManageUsersViewModel
    {

        public ManageUsersViewModel()
        {
            UserViewModels = new List<ManageUserViewModel>();
        }

        public List<ManageUserViewModel> UserViewModels { get; set; }


    }

    public class ManageUserViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }

    }
}
