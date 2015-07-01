using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class GadgetType : IEntity
    {
        public GadgetType()
        {
            this.Gadgets = new List<Gadget>();
        }

        public int GadgetTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Gadget> Gadgets { get; set; }
    }
}
