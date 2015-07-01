using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class DashboardType : IEntity
    {
        public DashboardType()
        {
            this.Dashboards = new List<Dashboard>();
        }

        public int DashboardTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Layout { get; set; }
        public virtual ICollection<Dashboard> Dashboards { get; set; }
    }
}
