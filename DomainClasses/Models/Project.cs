using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Project
    {
        public Project()
        {
            this.Boards = new List<Board>();
            this.Issues = new List<Issue>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string LeadId { get; set; }
        public Nullable<int> ProjectCategoryId { get; set; }
        public Nullable<int> ProjectTypeId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<Board> Boards { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual ProjectType ProjectType { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
