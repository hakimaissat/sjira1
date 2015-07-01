using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
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
        public virtual ICollection<Work> Works { get; set; }
    }
}
