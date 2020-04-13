using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Entites
{
    public class Conflict
    {
        public Conflict()
        {
            ConflictTeams = new List<ConflictTeam>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual List<ConflictTeam> ConflictTeams { get; set; }
    }
}
