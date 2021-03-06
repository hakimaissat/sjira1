//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SJiraCore.Models
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    //using SJiraDomainClasses.Enums;
    using SJiraShared;
    using SJiraShared.Enums;


    //[Table("Work")]
    public class Work : Entity<Guid>
    {

        public Nullable<System.Guid> SprintId  { get; set; }

        public int? ProjectId { get; set; }
        public int? IssueId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public int? WorkTypeId { get; set; }
        public DateTimeRange TimeRange { get; set; }
        public string Title { get; set; }
        

        public int? TimeSpend { get; set; }
        public TrackingState State { get; set; }

         public Work(Guid id)
            : base(id)
        {
        }

        private Work()
            : base(Guid.NewGuid()) // required for EF
        {
        }


       

        // Factory method for creation
        public static Work Create(Guid sprintId,
            int projectId, int issueId,
            int statusId, DateTime startTime, DateTime endTime,
            int workTypeId, int? userId, string title)
        {
            Guard.ForLessEqualZero(projectId, "clientId");
            Guard.ForLessEqualZero(issueId, "issueId");
            Guard.ForLessEqualZero(statusId, "statusId");
            Guard.ForLessEqualZero(workTypeId, "workTypeId");
            Guard.ForNullOrEmpty(title, "title");
            var appointment = new Work(Guid.NewGuid());
            appointment.SprintId = sprintId;
            appointment.IssueId = issueId;
            appointment.ProjectId = projectId;
            appointment.StatusId = statusId;
            appointment.TimeRange = new DateTimeRange(startTime, endTime);
            appointment.WorkTypeId = workTypeId;
            appointment.UserId = userId ?? 1;
            appointment.Title = title;
            return appointment;
        }
        
       
    }
}
