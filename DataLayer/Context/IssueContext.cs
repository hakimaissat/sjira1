
namespace DataLayer.Context
{
    using System.Data.Entity.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Data;
    using System.Data.Entity.ModelConfiguration;
    using System.Collections.Generic;
    using DomainClasses.Models;
    using DataLayer.Mapping;
    using DataLayer.Migrations;
    public partial class IssueContext : BaseContext<IssueContext>
    {
        public System.Data.Entity.DbSet<DomainClasses.Models.Issue> Issues { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.IssuePriority> IssuePriorities { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.IssueResolution> IssueResolutions { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.IssueType> IssueTypes { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.Project> Projects { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.Status> Status { get; set; }
    
        public DbSet<LogAction> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
