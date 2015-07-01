using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class BoardType : IEntity
    {
        public BoardType()
        {
            this.Boards = new List<Board>();
        }

        public int BoardTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string IconUrl { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
    }
}
