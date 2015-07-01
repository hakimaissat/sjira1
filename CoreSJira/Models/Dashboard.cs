using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace SJiraCore.Models
{
    public partial class Dashboard : IEntity
    {
        public Dashboard()
        {
            //this.GadgetsDashboards = new List<GadgetsDashboard>();
            //this.UsersDashboards = new List<UsersDashboard>();
        }

        public int DashboardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> SharedWithId { get; set; }
        public Nullable<int> OwnerId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> DashboardTypeId { get; set; }
        public virtual ICollection<Dashboard> Dashboard1 { get; set; }
        public virtual Dashboard Dashboard2 { get; set; }
        //public virtual DashboardType DashboardType { get; set; }
        //public virtual SharedWith SharedWith { get; set; }
        //public virtual UserProfile UserProfile { get; set; }
        //public virtual ICollection<GadgetsDashboard> GadgetsDashboards { get; set; }
        //public virtual ICollection<UsersDashboard> UsersDashboards { get; set; }
    }
}
