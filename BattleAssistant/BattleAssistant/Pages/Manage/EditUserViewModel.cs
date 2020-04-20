using System.Collections.Generic;

namespace BattleAssistant.Pages.Manage
{
    public class EditUserViewModel
    {
        public string UserName { get; set; }
        public List<string> RolesOfUser { get; set; }
        public List<string> AllRoles { get; set; }

    }
}
