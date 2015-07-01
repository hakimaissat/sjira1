using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses.Models
{
    public partial class MenuItem
    {
        public MenuItem()
        {
           
            this.Child = new List<MenuItem>();
            this.DashboardMenuItems = new List<DashboardMenuItem>();
        }
        [Key]
        public int MenuItemId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Title { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string MenuAction { get; set; }
        public string MenuIcon { get; set; }
        public string MenuIconAfter { get; set; }
        public Nullable<int> MenuItemTypeId { get; set; }
       
        public virtual ICollection<MenuItem> Child { get; set; }
        public virtual MenuItem Parent { get; set; }
        public virtual MenuItemType MenuItemType { get; set; }
        public virtual ICollection<DashboardMenuItem> DashboardMenuItems { get; set; }
    }
}
