using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Board
    {
        public Board()
        {
            this.Sprints = new List<Sprint>();
        }

        public int BoardId { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProjetId { get; set; }
        public Nullable<int> BoardTypeId { get; set; }
        public virtual BoardType BoardType { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<Sprint> Sprints { get; set; }
    }
}
