using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Entites
{
    public class ConflictTeam
    {
        public Guid ConflictId { get; set; }
        public Guid TeamId { get; set; }
        public virtual Conflict Conflict { get; set; }
        public virtual Team Team { get; set; }
    }
}
