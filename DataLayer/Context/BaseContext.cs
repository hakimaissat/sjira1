using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Mapping;
using DomainClasses.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer.Context
{
    public class BaseContext<TContext>
     : IdentityDbContext<ApplicationUser> where TContext : IdentityDbContext<ApplicationUser>
    {

        protected BaseContext()
            : base("name=SolidJira1Context")
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
            modelBuilder.Configurations.Add(new ComponentMap());
            modelBuilder.Configurations.Add(new DashboardMap());
            modelBuilder.Configurations.Add(new DashboardTypeMap());
            modelBuilder.Configurations.Add(new GadgetMap());
            modelBuilder.Configurations.Add(new DashboardGadgetMap());
            modelBuilder.Configurations.Add(new DashboardMenuItemMap());
            modelBuilder.Configurations.Add(new GadgetTypeMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new IssuePriorityMap());
            modelBuilder.Configurations.Add(new IssueResolutionMap());
            modelBuilder.Configurations.Add(new IssueTypeMap());
            modelBuilder.Configurations.Add(new MenuItemMap());
            modelBuilder.Configurations.Add(new MenuItemTypeMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectCategoryMap());
            modelBuilder.Configurations.Add(new ProjectTypeMap());
            modelBuilder.Configurations.Add(new SharedWithMap());
            modelBuilder.Configurations.Add(new SprintMap());
            modelBuilder.Configurations.Add(new StatusMap());
            //modelBuilder.Configurations.Add(new ApplicationUserMap());
            modelBuilder.Configurations.Add(new DashboardUserMap());
            modelBuilder.Configurations.Add(new WorkMap());
            modelBuilder.Configurations.Add(new WorkFlowMap());
            modelBuilder.Configurations.Add(new WorkTypeMap());
            modelBuilder.Configurations.Add(new BoardMap());
            modelBuilder.Configurations.Add(new BoardTypeMap());
        }
    }
}
