using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
{
    public partial class Status
    {
        public Status()
        {
            this.Works = new List<Work>();
        }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
