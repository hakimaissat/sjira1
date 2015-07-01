using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class MenuManager
    {
        public MenuManager()
        {
            this.MenuItems = new List<MenuItem>();
        }

        public int MenuManagerId { get; set; }
        public string Title { get; set; }
        public Nullable<int> MenuId { get; set; }
        public int MenuManagerTypeId { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public virtual MenuManagerType MenuManagerType { get; set; }
    }
}
