using System;
using System.Collections.Generic;
using DomainClasses.Interfaces;

namespace DomainClasses.Models
{
    public partial class ProjectCategory : IEntity
    {
        public ProjectCategory()
        {
            this.Projects = new List<Project>();
        }

        public int ProjectCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
