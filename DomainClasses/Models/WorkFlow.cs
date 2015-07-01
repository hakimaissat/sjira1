using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class WorkFlow
    {
        public int WorkFlowId { get; set; }
        public string Name { get; set; }
        public int Sequence { get; set; }
        public Nullable<int> ProjectTypeId { get; set; }
        public virtual ProjectType ProjectType { get; set; }
    }
}
