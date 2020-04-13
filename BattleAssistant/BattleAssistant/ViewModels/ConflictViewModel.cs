using DataLayer.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleAssistant.ViewModels
{
    public class ConflictViewModel
    {
        public ConflictViewModel()
        {

        }

        public ConflictViewModel(Conflict conflict)
        {
            ConflictId = conflict.Id;
            ConflictName = conflict.Name;
            Teams = new List<TeamViewModel>();
            if (conflict.ConflictTeams != null)
            {
                foreach (var team in conflict.ConflictTeams.Select(ct => ct.Team))
                {
                    Teams.Add(new TeamViewModel(team));
                }
            }
        }


        public Guid ConflictId { get; set; }
        public string ConflictName { get; set; }
        public List<TeamViewModel> Teams { get; set; }
    }
}
