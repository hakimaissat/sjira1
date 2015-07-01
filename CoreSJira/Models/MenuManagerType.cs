using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace SJiraCore.Models
{
    public  class MenuManagerType : IEntity
    {
        public MenuManagerType()
        {
            this.MenuManagers = new List<MenuManager>();
        }

        public int MenuManagerTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string IconUrl { get; set; }
        public virtual ICollection<MenuManager> MenuManagers { get; set; }
    }
}
