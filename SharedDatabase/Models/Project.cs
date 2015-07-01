using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
{
    public partial class Project
    {
        public Project()
        {
            this.Issues = new List<Issue>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<int> LeadId { get; set; }
        public Nullable<int> ProjectCategoryId { get; set; }
        public Nullable<int> TimeOriginalIstimate { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual ProjectCategory ProjectCategory { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
