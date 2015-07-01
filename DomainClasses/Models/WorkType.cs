using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class WorkType : IEntity
    {
        public WorkType()
        {
            this.Works = new List<Work>();
        }

        public int WorkTypeId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> Duration { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
