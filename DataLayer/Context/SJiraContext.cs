﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//NAME
//    Update-Database
    
//SYNOPSIS
//    Applies any pending migrations to the database.
    
    
//SYNTAX
//    Update-Database [-SourceMigration <String>] [-TargetMigration <String>] [-Script] [-Force] 
//    [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] 
//    [-ConnectionStringName <String>] [<CommonParameters>]
    
//    Update-Database [-SourceMigration <String>] [-TargetMigration <String>] [-Script] [-Force] 
//    [-ProjectName <String>] [-StartUpProjectName <String>] [-ConfigurationTypeName <String>] 
//    -ConnectionString <String> -ConnectionProviderName <String> [<CommonParameters>]
    
    
//DESCRIPTION
//    Updates the database to the current model by applying pending migrations.
    

//PARAMETERS
//    -SourceMigration <String>
//        Only valid with -Script. Specifies the name of a particular migration to use
//        as the update's starting point. If ommitted, the last applied migration in
//        the database will be used.
        
//    -TargetMigration <String>
//        Specifies the name of a particular migration to update the database to. If
//        ommitted, the current model will be used.
        
//    -Script [<SwitchParameter>]
//        Generate a SQL script rather than executing the pending changes directly.
        
//    -Force [<SwitchParameter>]
//        Specifies that data loss is acceptable during automatic migration of the
//        database.
        
//    -ProjectName <String>
//        Specifies the project that contains the migration configuration type to be
//        used. If ommitted, the default project selected in package manager console
//        is used.
        
//    -StartUpProjectName <String>
//        Specifies the configuration file to use for named connection strings. If
//        omitted, the specified project's configuration file is used.
        
//    -ConfigurationTypeName <String>
//        Specifies the migrations configuration to use. If omitted, migrations will
//        attempt to locate a single migrations configuration type in the target
//        project.
        
//    -ConnectionStringName <String>
//        Specifies the name of a connection string to use from the application's
//        configuration file.
        
//    -ConnectionString <String>
//        Specifies the the connection string to use. If omitted, the context's
//        default connection will be used.
        
//    -ConnectionProviderName <String>
//        Specifies the provider invariant name of the connection string.
        
//    <CommonParameters>
//        This cmdlet supports the common parameters: Verbose, Debug,
//        ErrorAction, ErrorVariable, WarningAction, WarningVariable,
//        OutBuffer, PipelineVariable, and OutVariable. For more information, see 
//        about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216). 
    
//REMARKS
//    To see the examples, type: "get-help Update-Database -examples".
//    For more information, type: "get-help Update-Database -detailed".
//    For technical information, type: "get-help Update-Database -full".


//enable-migrations
//add-migration Initial -IgnoreChanges
 //update-database
//update-database -verbose
 //update-database -TargetMigration:"Initial1"
//Install-Package EntityFramework -Version 5.0.0 
//install-package t4scaffolding
//scaffold repository DomainClasses.Models.Project
//scaffold repository DomainClasses.Models.MenuItem -DbContextType:MenuItemContext
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


    public partial class SJiraContext : BaseContext<SJiraContext>
    {


       
        public DbSet<Component> Components { get; set; }
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
        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardType> BoardTypes { get; set; }
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
