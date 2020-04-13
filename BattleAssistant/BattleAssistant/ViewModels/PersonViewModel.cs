using DataLayer.Entities.Entites;
using System;

namespace BattleAssistant.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {

        }

        public PersonViewModel(Person person)
        {
            Id = person.Id;
            Name = person.Name;
            PersonInfo = new PersonInfoViewModel(person);
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public PersonInfoViewModel PersonInfo {get; set;}

    }
}
