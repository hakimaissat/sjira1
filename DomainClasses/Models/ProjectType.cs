using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class ProjectType : IEntity
    {
        public ProjectType()
        {
            this.Projects = new List<Project>();
            this.WorkFlows = new List<WorkFlow>();
        }

        public int ProjectTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<WorkFlow> WorkFlows { get; set; }
    }
}
