using System;
using System.Collections.Generic;
namespace DomainClasses.Models
{
    public partial class Gadget
    {
        public Gadget()
        {
            this.Dashboard_Gadgets = new List<DashboardGadget>();
        }

        public int GadgetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string MenuAction { get; set; }
        public string MenuIcon { get; set; }
        public string OwnerId { get; set; }
        public Nullable<int> GadgetTypeId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<DashboardGadget> Dashboard_Gadgets { get; set; }
        public virtual GadgetType GadgetType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
