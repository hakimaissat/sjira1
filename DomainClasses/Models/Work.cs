using System;
using System.Collections.Generic;

namespace DomainClasses.Models
{
    public partial class Work
    {
        public System.Guid WorkId { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> IssueId { get; set; }
        public Nullable<int> SprintId { get; set; }
        public string AssigneeId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> TimeWorked { get; set; }
        public Nullable<int> WorkTypeId { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual Status Status { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual WorkType WorkType { get; set; }
    }
}
