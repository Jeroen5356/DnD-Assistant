using DataLayer.Entities.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BattleAssistant.ViewModels
{
    public class PersonInfoViewModel
    {
        public PersonInfoViewModel()
        {

        }

        public PersonInfoViewModel(Person person)
        {
            CurrentHealth = person.CurrentHealth;
            MaxHealth = person.MaxHealth;
            Level = person.Level;
        }

        public int Level { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
    }
}
