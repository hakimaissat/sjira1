using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses.Models
{
    public partial class DashboardGadget
    {
        public int DashboardGadgetId { get; set; }
        public int GadgetId { get; set; }
        public int DashboardId { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string ModifiedDate { get; set; }
        public virtual Dashboard Dashboard { get; set; }
        public virtual Gadget Gadget { get; set; }
    }
}
