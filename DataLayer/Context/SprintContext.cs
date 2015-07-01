
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
    public partial class SprintContext : BaseContext<SprintContext>
    {
        //public DbSet<Board> Boards { get; set; }
        //public DbSet<BoardType> BoardTypes { get; set; }
        //public DbSet<Component> Components { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<DashboardGadget> DashboardGadgets { get; set; }
        public DbSet<DashboardMenuItem> DashboardMenuItems { get; set; }
        public DbSet<DashboardType> DashboardTypes { get; set; }
        public DbSet<DashboardUser> DashboardUsers { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<GadgetType> GadgetTypes { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssuePriority> IssuePriorities { get; set; }
        public DbSet<IssueResolution> IssueResolutions { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemType> MenuItemTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<SharedWith> SharedWiths { get; set; }

        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Status> Status { get; set; }


        public DbSet<Work> Works { get; set; }
        public DbSet<WorkFlow> WorkFlows { get; set; }
        public DbSet<WorkType> WorkTypes { get; set; }
        public DbSet<LogAction> Logs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
