using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Dashboard
    {
        public Dashboard()
        {
            this.Dashboard_Gadgets = new List<DashboardGadget>();
            this.Dashboard_Users = new List<DashboardUser>();
            this.Childs = new List<Dashboard>();
            this.DashboardMenuItems = new List<DashboardMenuItem>();
        }

        public int DashboardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Favorite { get; set; }
        public Nullable<int> SharedWithId { get; set; }
        public string OwnerId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> DashboardTypeId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<DashboardGadget> Dashboard_Gadgets { get; set; }
        public virtual ICollection<DashboardUser> Dashboard_Users { get; set; }
        public virtual ICollection<DashboardMenuItem> DashboardMenuItems { get; set; }
        public virtual ICollection<Dashboard> Childs { get; set; }

        public virtual Dashboard Parent { get; set; }
        public virtual DashboardType DashboardType { get; set; }
        public virtual SharedWith SharedWith { get; set; }
    }
}
