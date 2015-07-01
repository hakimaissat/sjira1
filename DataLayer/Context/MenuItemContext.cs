
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

    public partial class MenuItemContext : BaseContext<IssueContext>
    {
        public System.Data.Entity.DbSet<DomainClasses.Models.MenuItem> MenuItems { get; set; }

        public System.Data.Entity.DbSet<DomainClasses.Models.MenuItemType> MenuItemTypes { get; set; }
       
        public DbSet<Dashboard> Dashboards { get; set; }
      
        public DbSet<DashboardUser> DashboardUsers { get; set; }
       
        public DbSet<LogAction> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }
    }
}
