﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SharedDatabase.DataModel
{

    using System.Data.Entity.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Data.Entity.Infrastructure;
    using System.Data;
    using System.Data.Entity.ModelConfiguration;
    using System.Collections.Generic;

    using SharedDatabase.Model;
    using SharedDatabase.Mapping;
    public  class SJiraContext : DbContext
    {
        
        public SJiraContext()
            : base("name=SolidJira")
        {
            Configuration.LazyLoadingEnabled = true;
        }
        //public DbSet<CompleteIssue> CompleteIssues { get; set; }
        //public DbSet<Issue> Issues { get; set; }
        //public DbSet<IssuePriority> IssuePriorities { get; set; }
        //public DbSet<IssueResolution> IssueResolutions { get; set; }
        //public DbSet<IssueType> IssueTypes { get; set; }
        //public DbSet<Project> Projects { get; set; }
        //public DbSet<ProjectCategory> ProjectCategories { get; set; }
        //public DbSet<Status> Status { get; set; }
        //public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<CompleteIssue> CompleteIssues { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssuePriority> IssuePriorities { get; set; }
        public DbSet<IssueResolution> IssueResolutions { get; set; }
        public DbSet<IssueType> IssueTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        
        public DbSet<Work> Works { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //modelBuilder.Configurations.Add(new IssueMap());
            //modelBuilder.Configurations.Add(new IssuePriorityMap());
            //modelBuilder.Configurations.Add(new IssueResolutionMap());
            //modelBuilder.Configurations.Add(new IssueTypeMap());

            //modelBuilder.Configurations.Add(new CompleteIssueMap());
            //modelBuilder.Configurations.Add(new ProjectMap());
            //modelBuilder.Configurations.Add(new ProjectCategoryMap());
            //modelBuilder.Configurations.Add(new StatusMap());
            //modelBuilder.Configurations.Add(new UserProfileMap());

            modelBuilder.Configurations.Add(new CompleteIssueMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new IssuePriorityMap());
            modelBuilder.Configurations.Add(new IssueResolutionMap());
            modelBuilder.Configurations.Add(new IssueTypeMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new ProjectCategoryMap());
            modelBuilder.Configurations.Add(new SprintMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
           
            modelBuilder.Configurations.Add(new WorkMap());
          ;
        }

        public class TestInitializerForCrudContext : DropCreateDatabaseAlways<SJiraContext>
        {

            protected override void Seed(SJiraContext context)
            {
                #if true
                                //CreateProjectCategory(context);
                                //CreateUser(context);
                                //CreateStatus(context);
                                CreateIssueType(context);
                                CreateIssuePriority(context);
                                CreateIssueResolution(context);
                                //CreateProject(context);
                                //CreateSprint(context);
                                CreateIssue(context);

                                //CreateWork(context);


                #endif
            }
            //private void CreateProject(CrudContext context)
            //{
            //    var projectCategory1 = context.ProjectCategories.Local.Where(c => c.Name == "Internal").FirstOrDefault();
            //    var user1 = context.UserProfiles.Local.Where(c => c.UserName == "XT17349").FirstOrDefault();
            //    var project = new List<Project>
            //{
              
            //    new Project{ Name="People Dashboard",
            //        Description="<script>alert('xss');</script>",
            //        Code="PDB",
            //        //ProjectId=Guid.NewGuid(),
            //        ProjectCategoryId=projectCategory1.Id,
            //        LeadId=user1.Id},
                    
            //    new Project{ Name="Pipeline",
            //        Description="<script>alert('xss');</script>",
            //        Code="PIP",
            //        //ProjectId=Guid.NewGuid(),
            //        ProjectCategoryId=projectCategory1.Id,
            //        LeadId=user1.Id},
               

            //};
            //    context.Projects.AddOrUpdate(c => new { c.Code }, project.ToArray());
            //}
            //private void CreateProjectCategory(CrudContext context)
            //{
            //    var projectCategory = new List<ProjectCategory>
            //{
              
            
            //    new ProjectCategory{ Name="Internal",Description="Internal projects" },
            //    new ProjectCategory{ Name="External",Description="External projects"},
            //    new ProjectCategory{ Name="Enhancement",Description="Enhancement projects"},

            //};
            //    context.ProjectCategories.AddOrUpdate(c => c.Name, projectCategory.ToArray());
            //}
            private void CreateIssueResolution(SJiraContext context)
            {
                var issueResolution = new List<IssueResolution>
            {
              
                new IssueResolution{ Name="Fixed"},
                new IssueResolution{ Name="Won't Fix"},
                new IssueResolution{ Name="Duplicate"},
                new IssueResolution{ Name="Incomplete"},
                new IssueResolution{ Name="Cannot Reproduce"},
                new IssueResolution{ Name="Unresolved"},
                new IssueResolution{ Name="Done"}

            };
                context.IssueResolutions.AddOrUpdate(c => c.Name, issueResolution.ToArray());
            }
            private void CreateIssuePriority(SJiraContext context)
            {
                var issuePriority = new List<IssuePriority>
            {
              
                new IssuePriority{ Name="Blocker"},
                new IssuePriority{ Name="High"},
                new IssuePriority{ Name="Med"},
                new IssuePriority{ Name="Low"},
                new IssuePriority{ Name="Critical"},
                new IssuePriority{ Name="Major"},
                new IssuePriority{ Name="Minor"},
                new IssuePriority{ Name="Trivial"},
                new IssuePriority{ Name="3-Medium"},
                new IssuePriority{ Name="2-High"},
                new IssuePriority{ Name="4-Low"},
                new IssuePriority{ Name="1-Critical"}

            };
                context.IssuePriorities.AddOrUpdate(c => c.Name, issuePriority.ToArray());
            }
            private void CreateIssueType(SJiraContext context)
            {
                var issueType = new List<IssueType>
            {
              
                new IssueType{ Name="Bug"},
                new IssueType{ Name="template"},
                new IssueType{ Name="SRS_Issue"},
                new IssueType{ Name="In Development"},
                new IssueType{ Name="DataCity"},
                new IssueType{ Name="SL-Action"},
                new IssueType{ Name="Theme"},
                new IssueType{ Name="Task (general)"},
                new IssueType{ Name="Technical Task"},
                new IssueType{ Name="New Feature"},
                new IssueType{ Name="Question"},
                new IssueType{ Name="Task"},
                new IssueType{ Name="Improvement"},
                new IssueType{ Name="Sub Task"},
                new IssueType{ Name="Epic"},
                new IssueType{ Name="Story"},
                new IssueType{ Name="Technical Debt"}
            };
                context.IssueTypes.AddOrUpdate(c => c.Name, issueType.ToArray());
            }
            //private void CreateStatus(CrudContext context)
            //{
            //    var status = new List<Status>
            //{
            //    new Status{ Name="1-New"},
            //    new Status{ Name="2-On Hold"},
            //    new Status{ Name="Backlog"},
            //    new Status{ Name="Selected for Development"},
            //    new Status{ Name="In Refinement"},
            //    new Status{ Name="In Development"},
            //    new Status{ Name="Awaiting Review"},
            //    new Status{ Name="In Review"},
            //    new Status{ Name="Awaiting Deployment"},
            //    new Status{ Name="Ready for Release"},
            //    new Status{ Name="Closed"},
            //    new Status{ Name="Ready for UIT"},
            //    new Status{ Name="Ready for UAT"},
            //    new Status{ Name="Design"},
            //    new Status{ Name="Technical Mapping"},
            //    new Status{ Name="Development"},
            //    new Status{ Name="Validation"},
            //    new Status{ Name="Ready for Design Signoff"},
            //    new Status{ Name="In Progress 25%"},
            //    new Status{ Name="In Progress 50%"},
            //    new Status{ Name="In Progress 75%"},
            //    new Status{ Name="Technical UIT"},
            //    new Status{ Name="Business UIT"},
            //    new Status{ Name="UAT"},
            //    new Status{ Name="Client Info Required"},
            //    new Status{ Name="More Info Required"},
            //    new Status{ Name="In Progress"},
            //    new Status{ Name="On Hold"},
            //    new Status{ Name="DEV"},
            //    new Status{ Name="STG"},
            //    new Status{ Name="PRD"},
            //    new Status{ Name="Reopened"}

            //};
            //    context.Status.AddOrUpdate(c => c.Name, status.ToArray());
            //}
            //private void CreateUser(CrudContext context)
            //{
            //    var user = new List<UserProfile>
            //{
              
            //    new UserProfile{UserName="XT19141"
            //        //,LastName="Aissat",FirstName="Mohamed",,ContractType=ContractType.Consultant
            //    },
            //    new UserProfile{ UserName="xt17640"
            //        //,LastName="Paul",FirstName="Jerome",ContractType=ContractType.Consultant
            //    },
            //    new UserProfile{UserName="XT10596" 
            //        //,LastName="Lemaitre",FirstName="Nathalie",",ContractType=ContractType.Consultant
            //    },
            //   new UserProfile{ UserName="XT17349",
            //       //LastName="Gagne",FirstName="Ghislain ",,ContractType=ContractType.Consultant
            //   },
            //   new UserProfile{ UserName="996429",
            //       //LastName="Girgis",FirstName="Mark ",,ContractType=ContractType.Consultant
            //   },
            //};
            //    context.UserProfiles.AddOrUpdate(c => new { c.UserName }, user.ToArray());
            //}
            private void CreateIssue(SJiraContext context)
            {
                //var user1 = context.UserProfiles.Local.Where(c => c.UserName == "XT19141").FirstOrDefault();
                //var user2 = context.UserProfiles.Local.Where(c => c.UserName == "xt17640").FirstOrDefault();
                //var project1 = context.Projects.Local.Where(c => c.Code == "PDB").FirstOrDefault();
                //var project2 = context.Projects.Local.Where(c => c.Code == "PIP").FirstOrDefault();
                var IssueResolution1 = context.IssueResolutions.Local.Where(c => c.Name == "Unresolved").FirstOrDefault();
                var IssueResolution2 = context.IssueResolutions.Local.Where(c => c.Name == "Incomplete").FirstOrDefault();
                var IssueProprity1 = context.IssuePriorities.Local.Where(c => c.Name == "Blocker").FirstOrDefault();
                var IssueProprity2 = context.IssuePriorities.Local.Where(c => c.Name == "High").FirstOrDefault();
                var IssueType1 = context.IssueTypes.Local.Where(c => c.Name == "Epic").FirstOrDefault();
                var IssueType2 = context.IssueTypes.Local.Where(c => c.Name == "Story").FirstOrDefault();
                //var status1 = context.Status.Local.Where(c => c.Name == "1-New").FirstOrDefault();
                //var status2 = context.Status.Local.Where(c => c.Name == "2-On Hold").FirstOrDefault();
                try
                {
                    var issues = new List<Issue>
                          {
                            new Issue
                              {
                                    Code = "PSC-2152",
                                    Summary = "Export/Import Datastage",
                                    Description = "Export/Import Datastage",
                                    //DateOfBirth = new DateTime(2008, 1, 28),
                                    IssueTypeId=IssueType1.Id,
                                    IssuePriorityId=IssueProprity1.Id,
                                    IssueResolutionId=IssueResolution1.Id,
                                    CreatedDate=DateTime.Now,
                                //    CompleteIssue = new CompleteIssue(){
                                //    Votes=1,AssignerId=user1.Id,
                                //    Watches=1,
                                //    StatusId = status1.Id,
                                //    TimeOriginalIstimate=5000
                                //    //ProjectId=project1.ProjectId
                                //}
                              },
                            new Issue
                              {
                                    Code = "PSC-2153",
                                    Summary = "Prepare data for initial load",
                                    Description = "Prepare data for initial load",
                                    //DateOfBirth = new DateTime(1958, 1, 1),
                                    
                                    IssueTypeId=IssueType2.Id,
                                    IssuePriorityId=IssueProprity2.Id,
                                    IssueResolutionId=IssueResolution2.Id,
                                    CreatedDate=DateTime.Now,
                                //    CompleteIssue = new CompleteIssue(){
                                //    Votes=1,AssignerId=user1.Id,
                                //    Watches=1,
                                //    StatusId = status2.Id,
                                //    //ProjectId=project2.ProjectId,
                                //    TimeOriginalIstimate=6000
                                //}
                              }
                          };
                    context.Issues.AddOrUpdate(
                      c => new { c.Code }, issues.ToArray());
                }
                catch (Exception e)
                {

                    throw;
                }

            }
        }

        // method 2
        //public override int SaveChanges()
        //{
        //    int result;
        //    try
        //    {
        //        foreach (var stateInfo in this.ChangeTracker.Entries()
        //            .Where(e =>e.Entity is StateInfo  &&  e.State == EntityState.Added || e.State == EntityState.Modified)
        //            .Select(e => e.Entity as StateInfo))
        //        {
        //            stateInfo.ModifiedDate = DateTime.Now;
              


        //        }
        //         result = base.SaveChanges();
        //        foreach (var stateInfo in this.ChangeTracker.Entries()
        //            .Where(e => e.Entity is StateInfo )
        //            .Select(e => e.Entity as StateInfo))
        //        {
        //            stateInfo.IsDirty = false;
        //        }
        //    }
        //    catch (Exception e)
        //    {
                
        //        throw;
        //    }   
            
        //    return result;
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Configurations.Add(new CompleteIssueMappings());
        //    modelBuilder.Configurations.Add(new StatusMappings());
        //    //modelBuilder.Configurations.Add(new ProjectMappings());
        //    modelBuilder.Configurations.Add(new IssueMappings());
        //    //throw new UnintentionalCodeFirstException();
        //    //modelBuilder.Entity<Status>().HasKey(c => c.Id);
        //    //modelBuilder.Entity<Status>().Property(c => c.Name).HasColumnName("StatusName");
        //}
        //public class CompleteIssueMappings : EntityTypeConfiguration<CompleteIssue>
        //{
        //    public CompleteIssueMappings()
        //    {
        //        this.HasKey(i => i.Id) ;
        //        //Property(c => c.MobilePhone).HasColumnName("MobilePhone");
        //        //Property(c => c.HomePhone).HasMaxLength(20);
        //        //HasRequired(i => i.Issue).WithOptional(c => c.CompleteIssue);
        //        HasRequired(i => i.Issue).WithRequiredDependent(c => c.CompleteIssue).WillCascadeOnDelete(true);
        //    }
        //}
        //public class StatusMappings : EntityTypeConfiguration<Status>
        //{
        //    public StatusMappings()
        //    {
        //        HasKey(c => c.Id);
        //        Property(c => c.Name).HasColumnName("StatusName");
        //    }
        //}
        //public class ProjectMappings : EntityTypeConfiguration<Project>
        //{
        //    public ProjectMappings()
        //    {
        //        HasKey(c => c.ProjectId);
        //        Property(c => c.UserId).HasColumnName("LeadId");
        //    }
        //}
        //public class IssueMappings : EntityTypeConfiguration<Issue>
        //{
        //    public IssueMappings()
        //    {
        //        HasKey(c => c.Id);
        //        Property(c => c.Id).HasColumnName("AssignerId");
        //    }
        //}
    }
}
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
//PM> Install-Package EntityFramework -Version 5.0.0 