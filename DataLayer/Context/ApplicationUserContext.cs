
namespace DataLayer.Context
{

    //using DomainClasses.Enums;
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
    using Microsoft.AspNet.Identity.EntityFramework;

    public partial class ApplicationUserContext : BaseContext<ApplicationUserContext>
    {

        public DbSet<LogAction> Logs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           
        }





      

    }
}
