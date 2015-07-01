using System;
using System.Collections.Generic;

namespace SJiraCore.Models
{
    public  class MenuItem
    {
        public MenuItem()
        {
           
            this.MenuItem1 = new List<MenuItem>();
            this.MenuManagers = new List<MenuManager>();
        }

        public int MenuId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Title { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string MenuAction { get; set; }
        public int MenuManagerId { get; set; }
        public Nullable<int> MenuTypeId { get; set; }
       
        public virtual ICollection<MenuItem> MenuItem1 { get; set; }
        public virtual MenuItem MenuItem2 { get; set; }
        public virtual MenuItemType MenuItemType { get; set; }
        public virtual MenuManager MenuManager { get; set; }
        public virtual ICollection<MenuManager> MenuManagers { get; set; }
    }
}
