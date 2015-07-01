using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class SharesFavorite 
    {
        public SharesFavorite()
        {
            this.Dashboard_Users = new List<DashboardUser>();
        }

        public int SharesFavoriteId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<DashboardUser> Dashboard_Users { get; set; }
    }
}
