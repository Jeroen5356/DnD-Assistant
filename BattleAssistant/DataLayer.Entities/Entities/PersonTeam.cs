using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Entities.Entites
{
    public class PersonTeam
    {
        public Guid PersonId { get; set; }
        public Guid TeamId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Team Team { get; set; }
    }
}
