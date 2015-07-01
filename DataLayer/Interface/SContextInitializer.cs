using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using System.Data.Entity.Migrations;

using System.Data.Entity.Infrastructure;
using System.Data;
using DomainClasses.Models;

//using System.Data.Entity.ModelConfiguration;


namespace DataLayer
{
    public class SContextInitializer : DropCreateDatabaseIfModelChanges<SJiraContext>
    {
        protected override void Seed(SJiraContext context)
        {
#if true
            CreateProjectCategory(context);
            CreateUser(context);
            CreateStatus(context);
            CreateWorkType(context);
            CreateIssueType(context);
            CreateIssuePriority(context);
            CreateIssueResolution(context);
            CreateProject(context);
            CreateSprint(context);
            CreateIssue(context);
            CreateWork(context);
            //context.SaveChanges();
#endif
            //base.Seed(context);
        }
        private void CreateSprint(SJiraContext context)
        {
            //DateTimeRange DateRange1 = new DateTimeRange(DateTime.Now.AddDays(-100), DateTime.Now.AddDays(-50));
            //DateTimeRange DateRange2 = new DateTimeRange(DateTime.Now.AddDays(-49), DateTime.Now.AddDays(-1));
            var user = new List<Sprint>
        {

            new Sprint{ Name="Sp1",DateRange_Start=DateTime.Now.AddDays(-100) ,DateRange_End=DateTime.Now.AddDays(-50)},
            new Sprint{ Name="Sp2",DateRange_Start=DateTime.Now.AddDays(-49),DateRange_End=DateTime.Now.AddDays(-1)},

        };
            context.Sprints.AddOrUpdate(c => new { c.Name }, user.ToArray()); context.SaveChanges();
        }
        private void CreateWork(SJiraContext context)
        {
            var issue1 = context.Issues.Local.Where(c => c.Code == "PSC-2152").FirstOrDefault();
            var issue2 = context.Issues.Local.Where(c => c.Code == "PSC-2153").FirstOrDefault();
            var status1 = context.Status.Local.Where(c => c.Name == "1-New").FirstOrDefault();
            var status2 = context.Status.Local.Where(c => c.Name == "2-On Hold").FirstOrDefault();
            var project1 = context.Projects.Local.Where(c => c.Code == "PDB").FirstOrDefault();
            var project2 = context.Projects.Local.Where(c => c.Code == "PIP").FirstOrDefault();
            var user1 = context.UserProfiles.Local.Where(c => c.UserName == "XT19141").FirstOrDefault();
            var user2 = context.UserProfiles.Local.Where(c => c.UserName == "xt17640").FirstOrDefault();
            var sprint1 = context.Sprints.Local.Where(c => c.Name == "Sp1").FirstOrDefault();
            var sprint2 = context.Sprints.Local.Where(c => c.Name == "Sp2").FirstOrDefault();
            var works = new List<Work>
                           {
                             new Work()
                               { Title= "work1",
                                 WorkTypeId = 1,
                                 IssueId = issue1.IssueId,
                                 StatusId = status1.StatusId,
                                 StartDate=DateTime.Now.AddDays(-5),
                                 TimeWorked=4,
                                 WorkId=Guid.NewGuid(),
                                
                                   AssigneeId=user1.UserId,
                                 SprintId=sprint1.SprintId
                               },
                             new Work()
                               {Title= "work2",
                                 WorkTypeId = 1,
                                 IssueId = issue2.IssueId,
                                 StatusId = status2.StatusId,
                                 StartDate=DateTime.Now.AddDays(-3),
                                 TimeWorked=3,
                                 WorkId=Guid.NewGuid(),
                                 
                                    AssigneeId=user1.UserId,
                                   SprintId=sprint1.SprintId

                               }
                           
                           };

            context.Works.AddOrUpdate(c => new { c.Title }, works.ToArray()); context.SaveChanges();
            //DateTimeRange DateRange1 = new DateTimeRange(DateTime.Now.AddDays(-5), DateTime.Now.AddDays(-4));
            //DateTimeRange DateRange2 = new DateTimeRange(DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-1));

            //context.Works.Add(new Work(Guid.NewGuid())
            //{
            //    WorkType = WorkType.BackLog,
            //    IssueId = issue1.IssueId,
            //    StatusId = status1.Id,
            //    DateRange = DateRange1,
            //    //TimeRange_Start = DateTime.Now.AddDays(-5),
            //    //TimeRange_End = DateTime.Now.AddDays(-4),
            //    //WorkId=Guid.NewGuid(),
            //    ProjectId = project1.Id,
            //    UserId = user1.Id,
            //    SprintId = sprint1.Id
            //});
            //context.Works.Add(new Work(Guid.NewGuid())
            //{
            //    WorkType = WorkType.BackLog,
            //    IssueId = issue2.IssueId,
            //    StatusId = status2.Id,
            //    DateRange = DateRange2,
            //    //TimeRange_Start = DateTime.Now.AddDays(-3),
            //    //TimeRange_End = DateTime.Now.AddDays(-1),
            //    //WorkId = Guid.NewGuid(),
            //    ProjectId = project2.Id,
            //    UserId = user1.Id,
            //    SprintId = sprint1.Id

            //});
        }
        private void CreateProject(SJiraContext context)
        {
            var projectCategory1 = context.ProjectCategories.Local.Where(c => c.Name == "Internal").FirstOrDefault();
            var user1 = context.UserProfiles.Local.Where(c => c.UserName == "XT19141").FirstOrDefault();
            var project = new List<Project>
         {

             new Project{ Name="People Dashboard",
                 //Description="<script>alert('xss');</script>",
                 Code="PDB",
                 //ProjectId=Guid.NewGuid(),
                 ProjectCategoryId=projectCategory1.ProjectCategoryId,
                 LeadId=user1.UserId},

             new Project{ Name="Pipeline",
                 //Description="<script>alert('xss');</script>",
                 Code="PIP",
                 //ProjectId=Guid.NewGuid(),
                 ProjectCategoryId=projectCategory1.ProjectCategoryId,
                 LeadId=user1.UserId},


         };
            context.Projects.AddOrUpdate(c => new { c.Code }, project.ToArray()); context.SaveChanges();
        }
        private void CreateProjectCategory(SJiraContext context)
        {
            var projectCategory = new List<ProjectCategory>
        {


            new ProjectCategory{ Name="Internal",Description="Internal projects" },
            new ProjectCategory{ Name="External",Description="External projects"},
            new ProjectCategory{ Name="Enhancement",Description="Enhancement projects"},

        };
            context.ProjectCategories.AddOrUpdate(c => c.Name, projectCategory.ToArray());
        }
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
            context.IssueResolutions.AddOrUpdate(c => c.Name, issueResolution.ToArray()); context.SaveChanges();
        }

        private void CreateWorkType(SJiraContext context)
        {
            var workType = new List<WorkType>
        {

            new WorkType{ Name="Spint Cahnge"},
            new WorkType{ Name="User Change"},
            new WorkType{ Name="Status Change"},
            new WorkType{ Name="Log Work"},
           

        };
            context.WorkTypes.AddOrUpdate(c => c.Name, workType.ToArray()); context.SaveChanges();
        }

        private void CreateIssuePriority(SJiraContext context)
        {
            var IssuePriorities = new List<IssuePriority>
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
            context.IssuePriorities.AddOrUpdate(c => c.Name, IssuePriorities.ToArray()); context.SaveChanges();
        }
        private void CreateIssueType(SJiraContext context)
        {
            var issueTypes = new List<IssueType>
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
            context.IssueTypes.AddOrUpdate(c => c.Name, issueTypes.ToArray()); context.SaveChanges();
            //issueTypes.ForEach(b => context.IssueTypes.Add(b));
        }
        private void CreateStatus(SJiraContext context)
        {
            var status = new List<Status>
        {
            new Status{ Name="1-New"},
            new Status{ Name="2-On Hold"},
            new Status{ Name="Backlog"},
            new Status{ Name="Selected for Development"},
            new Status{ Name="In Refinement"},
            new Status{ Name="In Development"},
            new Status{ Name="Awaiting Review"},
            new Status{ Name="In Review"},
            new Status{ Name="Awaiting Deployment"},
            new Status{ Name="Ready for Release"},
            new Status{ Name="Closed"},
            new Status{ Name="Ready for UIT"},
            new Status{ Name="Ready for UAT"},
            new Status{ Name="Design"},
            new Status{ Name="Technical Mapping"},
            new Status{ Name="Development"},
            new Status{ Name="Validation"},
            new Status{ Name="Ready for Design Signoff"},
            new Status{ Name="In Progress 25%"},
            new Status{ Name="In Progress 50%"},
            new Status{ Name="In Progress 75%"},
            new Status{ Name="Technical UIT"},
            new Status{ Name="Business UIT"},
            new Status{ Name="UAT"},
            new Status{ Name="Client Info Required"},
            new Status{ Name="More Info Required"},
            new Status{ Name="In Progress"},
            new Status{ Name="On Hold"},
            new Status{ Name="DEV"},
            new Status{ Name="STG"},
            new Status{ Name="PRD"},
            new Status{ Name="Reopened"}

        };
            context.Status.AddOrUpdate(c => c.Name, status.ToArray()); context.SaveChanges();
        }
        private void CreateUser(SJiraContext context)
        {
            var user = new List<UserProfile>
        {

            new UserProfile{UserName="XT19141"
                //,LastName="Aissat",FirstName="Mohamed",,ContractType=ContractType.Consultant
            },
            new UserProfile{ UserName="xt17640"
                //,LastName="Paul",FirstName="Jerome",ContractType=ContractType.Consultant
            },
            new UserProfile{UserName="XT10596" 
                //,LastName="Lemaitre",FirstName="Nathalie",",ContractType=ContractType.Consultant
            },
           new UserProfile{ UserName="XT17349",
               //LastName="Gagne",FirstName="Ghislain ",,ContractType=ContractType.Consultant
           },
           new UserProfile{ UserName="996429",
               //LastName="Girgis",FirstName="Mark ",,ContractType=ContractType.Consultant
           },
        };
            context.UserProfiles.AddOrUpdate(c => new { c.UserName }, user.ToArray()); context.SaveChanges();
        }
        private void CreateIssue(SJiraContext context)
        {
            //var user1 = context.UserProfiles.Local.Where(c => c.UserName == "XT19141").FirstOrDefault();
            //var user2 = context.UserProfiles.Local.Where(c => c.UserName == "xt17640").FirstOrDefault();
            var project1 = context.Projects.Local.Where(c => c.Code == "PDB").FirstOrDefault();
            var project2 = context.Projects.Local.Where(c => c.Code == "PIP").FirstOrDefault();
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
                        new Issue //Guid.NewGuid())
                          {
                              IssueId= Guid.NewGuid(),
                                Code = "PSC-2152",
                                Summary = "Export/Import Datastage",
                                Description = "Export/Import Datastage",
                                //DateOfBirth = new DateTime(2008, 1, 28),
                                IssueTypeId=IssueType1.IssueTypeId,
                                IssuePriorityId=IssueProprity1.IssuePriorityId,
                                IssueResolutionId=IssueResolution1.IssueResolutionId,
                                CreatedDate=DateTime.Now,
                            //    CompleteIssue = new CompleteIssue(){
                                Votes=1,
                                Watches=1,
                            //    StatusId = status1.Id,
                                TimeOriginalIstimate=5000,
                                ProjectId=project1.ProjectId
                            //}
                          },
                        new Issue //(Guid.NewGuid())
                          {
                              IssueId= Guid.NewGuid(),
                                Code = "PSC-2153",
                                Summary = "Prepare data for initial load",
                                Description = "Prepare data for initial load",
                                //DateOfBirth = new DateTime(1958, 1, 1),

                                IssueTypeId=IssueType2.IssueTypeId,
                                IssuePriorityId=IssueProprity2.IssuePriorityId,
                                IssueResolutionId=IssueResolution2.IssueResolutionId,
                                CreatedDate=DateTime.Now,
                            //    CompleteIssue = new CompleteIssue(){
                                Votes=1,
                                Watches=1,
                            //    StatusId = status2.Id,
                                ProjectId=project2.ProjectId,
                                TimeOriginalIstimate=6000
                            //}
                          }
                      };
                context.Issues.AddOrUpdate(
                  c => new { c.Code }, issues.ToArray()); context.SaveChanges();
                //context.SaveChanges();
            }
            catch (Exception eCreateIssue)
            {

                throw eCreateIssue;
            }

        }
    }
}