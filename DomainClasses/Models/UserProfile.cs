using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DomainClasses.Models
{
    public partial class UserProfile 
    {
        public UserProfile()
        {
            this.Dashboards = new List<Dashboard>();
            this.Dashboard_Users = new List<DashboardUser>();
            this.Gadgets = new List<Gadget>();
            this.AssigneeIssues = new List<Issue>();
            this.ReporterIssues = new List<Issue>();
            this.Projects = new List<Project>();
            this.Works = new List<Work>();
        }
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public virtual ICollection<Dashboard> Dashboards { get; set; }
        public virtual ICollection<DashboardUser> Dashboard_Users { get; set; }
        public virtual ICollection<Gadget> Gadgets { get; set; }
        public virtual ICollection<Issue> AssigneeIssues { get; set; }
        public virtual ICollection<Issue> ReporterIssues { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Work> Works { get; set; }
    }
}
