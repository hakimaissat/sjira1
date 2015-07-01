using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Sprint
    {
        public Sprint()
        {
            this.Works = new List<Work>();
        }

        public int SprintId { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateRange_Start { get; set; }
        public Nullable<System.DateTime> DateRange_End { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> BoardId { get; set; }
        public virtual Board Board { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
