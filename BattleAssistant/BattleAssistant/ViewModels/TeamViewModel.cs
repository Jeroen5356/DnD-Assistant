using DataLayer.Entities.Entites;
using System;
using System.Collections.Generic;

namespace BattleAssistant.ViewModels
{
    public class TeamViewModel
    {
        public TeamViewModel()
        {

        }

        public TeamViewModel(Team team)
        {
            Id = team.Id;
            Name = team.Name;
            PersonViewModels = new List<PersonViewModel>();
            if (team.PersonTeams != null)
            {
                foreach (var personTeam in team.PersonTeams)
                {
                    PersonViewModels.Add(new PersonViewModel(personTeam.Person));
                }
            }
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<PersonViewModel> PersonViewModels { get; set; }
    }
}
