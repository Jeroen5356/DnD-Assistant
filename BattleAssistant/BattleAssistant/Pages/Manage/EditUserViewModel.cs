using System.Collections.Generic;

namespace BattleAssistant.Pages.Manage
{
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            UserIsInRole = new List<UserRole>();
        }

        public string UserName { get; set; }

        public List<UserRole> UserIsInRole { get; set; }

        

    }

    public class UserRole
    {
        public string RoleName { get; set; }
        public bool UserIsInRole { get; set; }
    }
}
