using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Entites
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<PersonTeam> PersonTeams { get; set; }
        public virtual List<ConflictTeam> ConflictTeams { get; set; }
    }
}
