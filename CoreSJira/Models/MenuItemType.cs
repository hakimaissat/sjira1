using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace SJiraCore.Models
{
    public  class MenuItemType : IEntity
    {
        public MenuItemType()
        {
            this.MenuItems = new List<MenuItem>();
        }

        public int MenuTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string IconUrl { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
    }
}
