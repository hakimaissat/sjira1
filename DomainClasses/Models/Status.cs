using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class Status : IEntity
    {
        public Status()
        {
            this.Issues = new List<Issue>();
            this.Works = new List<Work>();
        }

        public int StatusId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sequence { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
