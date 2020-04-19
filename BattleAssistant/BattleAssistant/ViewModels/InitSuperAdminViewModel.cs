using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAssistant.ViewModels
{
    public class InitSuperAdminViewModel
    {
        [Required]
        public string Password { get; set; }
    }
}
