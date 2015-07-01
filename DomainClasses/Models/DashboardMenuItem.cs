using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses.Models
{
    public partial class DashboardMenuItem
    {

        public int DashboardMenuItemId { get; set; }
        public int MenuItemId { get; set; }
        public int DashboardId { get; set; }
        //public bool Favorite { get; set; }
        public int DisplayOrder { get; set; }
        public string ModifiedDate { get; set; }
        public virtual Dashboard Dashboard { get; set; }
        public virtual MenuItem MenuItem { get; set; } 
    }
}
