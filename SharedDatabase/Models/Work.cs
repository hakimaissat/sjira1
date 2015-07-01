using System;
using System.Collections.Generic;

namespace SharedDatabase.Models
{
    public partial class Work
    {
        public System.Guid WorkId { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> IssueId { get; set; }
        public Nullable<int> SprintId { get; set; }
        public Nullable<int> AssignerId { get; set; }
        public Nullable<int> StatusId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> TimeWorked { get; set; }
        public Nullable<int> WorkTypeId { get; set; }
        public virtual Issue Issue { get; set; }
        public virtual Sprint Sprint { get; set; }
        public virtual Status Status { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual WorkType WorkType { get; set; }
    }
}
