using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcSJira.Models
{
    public partial class DashboardModel
    {
        
        public int DashboardId { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int OwnerId { get; set; }
        [Display(Name = "Shared With")]
        public string SharedWith { get; set; }
        public int SharedWithId { get; set; }
        
      
        
    }
}
