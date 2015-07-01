using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
{
    public partial class IssueResolution
    {
        public IssueResolution()
        {
            this.Issues = new List<Issue>();
        }

        public int IssueResolutionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<int> Sequence { get; set; }
        public string IconUrl { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
    }
}
