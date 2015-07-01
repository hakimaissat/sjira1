using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class SharedWith : IEntity
    {
        public SharedWith()
        {
            this.Dashboards = new List<Dashboard>();
        }

        public int SharedWithId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Dashboard> Dashboards { get; set; }
    }
}
