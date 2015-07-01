using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Issue
    {
        public Issue()
        {
            this.Works = new List<Work>();
        }

        public System.Guid IssueId { get; set; }
        public string Code { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string Environment { get; set; }
        public string Attachement { get; set; }
        public string Labels { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> IssuePriorityId { get; set; }
        public Nullable<int> IssueTypeId { get; set; }
        public Nullable<int> IssueResolutionId { get; set; }
        public Nullable<int> TimeOriginalIstimate { get; set; }
        public string AssigneeId { get; set; }
        public string ReporterId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<int> Votes { get; set; }
        public Nullable<int> Watches { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual IssuePriority IssuePriority { get; set; }
        public virtual IssueResolution IssueResolution { get; set; }
        public virtual IssueType IssueType { get; set; }
        public virtual Project Project { get; set; }
        public virtual Status Status { get; set; }
        public virtual ApplicationUser Assignee { get; set; }
        public virtual ApplicationUser Reporter { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
