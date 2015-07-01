using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcSJira.Models
{
    public class DashboardGadgetsModel
    {
        
        public int DashboardId { get; set; }
        public string Name { get; set; }
        public string DashboardType { get; set; }
        public virtual ICollection<GadgetModel> Gadgets { get; set; }
      
        
    }
}