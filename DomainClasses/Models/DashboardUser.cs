using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses.Models
{
    public partial class DashboardUser
    {
        
            public int DashboardUserId { get; set; }
            public string UserId { get; set; }
            public int DashboardId { get; set; }
            public bool Favorite { get; set; }
            
            public string ModifiedDate { get; set; }
            public virtual Dashboard Dashboard { get; set; }
            public virtual ApplicationUser ApplicationUser { get; set; }

        

    }
}
