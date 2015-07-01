using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SJiraDataLayer;
//using SJiraDataLayer.Migrations;
//using SJiraDomainClasses.Model;
//using SJiraRepository;
using SJiraShared;
using Repository;
using DomainClasses.Model;
using DataLayer;
namespace ConsoleSJira
{
    class Program1
    {
        private static SimpleRepository _repository;
        //static void Main(string[] args)
        //{

        //    CreateDataBase();
        //    _repository = new SimpleRepository();

        //    Database.SetInitializer(new DropCreateDatabaseAlways<CrudContext>());
        //    //Database.SetInitializer<CrudContext>(null);
        //    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrudContext, Configuration>());
        //    //InsertProjectCategory();
        //    InsertProjectCategoryAndSave();
        //    //UpdateProjectCategory();
        //    //InsertProjectCategory_Project();
        //        //LazyLoading();
            
        //}
        static void Main(string[] args)
        {

            CreateDataBase();
           

        }

        private static void CreateDataBase()
        {
            try
            {
                var context = new CrudContext();
                context.Database.Initialize(true);
            }
            catch (Exception w)
            {
                
                throw;
            }
            
        }

        private static void InsertProjectCategoryAndSave()
        {
            var projectCategory = new ProjectCategory { Name = "Test" };
            _repository.InsertProjectCategoryAndSave(ref projectCategory);

            GetProjectCategory(projectCategory.Id);
        }

        private static void EagerLoading()
        {

            using (var context = new CrudContext())
            {
                var project1 = context.Projects.Include(p => p.Issues).ToList();
                var project2 = context.Projects.Include("Issues").ToList();
                var projectCategory3 = context.ProjectCategories.Include("Projects.Issues").ToList();

                 var projectCategory4 = context.ProjectCategories
                     .Where(pc=>pc.Projects.Any())
                     //.Include(pc => pc.Projects.Select(p => p.Issues.Select(w => w.UserProfile)))
                     .ToList()          ;
                 var projectCategory = projectCategory4[0];

            }
        }
        private static void ExplicitLoading()
        {

            using (var context = new CrudContext())
            {
               
                var projectCategory = context.ProjectCategories.First();
                context.Entry(projectCategory).Collection(pc => pc.Projects).Load();

                Console.WriteLine("project count for {0},{1}", projectCategory.Name, projectCategory.Projects.Count());

            }
        }
        private static void LazyLoading()
        {

            using (var context = new CrudContext())
            {

                var projectCategory = context.ProjectCategories.First();
                //context.Entry(projectCategory).Collection(pc => pc.Projects).Load();
                Console.WriteLine("project count for {0},{1}", projectCategory.Name, projectCategory.Projects.Count());


            }
        }
        private static void GetProject1()
        {

            using (var context = new CrudContext())
            {
                var project = context.Projects.Where(p => p.Issues.Any())
                    .Select(p =>
                        new { Project=p.Name, ProjectCategory = p.ProjectCategoryId });
                
            }
        }
        private static void GetProject2()
        {

            using (var context = new CrudContext())
            {

                var project = from p in context.Projects
                              where p.Issues.Any()
                    select new 
                         { Project = p.Name, ProjectCategory = p.ProjectCategoryId };

            }
        }
        private static void InsertProjectCategory_Project()
        {
            try
            {
                var status = GetStatus();
                var projectCategory = new ProjectCategory
                {
                    Name = "Internal",
                
                };
                var project = new Project
                {
                    Name = "Jira1",
                    CompanyId = 1,
                    //ProjectId = Guid.NewGuid(),
                    //Works = {new Work(Guid.NewGuid()) {StatusId=status[0].StatusId,  TimeRange_Start=DateTime.Now.AddDays(-5),TimeRange_End=DateTime.Now.AddDays(-4) },
                    //    new Work(Guid.NewGuid()) {StatusId=status[0].StatusId, TimeRange_Start=DateTime.Now.AddDays(-3),TimeRange_End=DateTime.Now.AddDays(-2) }}
                };
                //project.ProjectCategory = projectCategory;
                projectCategory.Projects.Add(project);
                using (var context = new CrudContext())
                {
                    context.ProjectCategories.Add(projectCategory);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e);
            }
            
            
           
        }
        private static void InsertProjectCategory()
        {
            var projectCategory = new ProjectCategory { Name = "Internal" };
            using (var context = new CrudContext())
            {
                context.ProjectCategories.Add(projectCategory);
                context.SaveChanges();
            }
            GetProjectCategory(projectCategory.Id);
        }
        private static void GetProjectCategory(int id)
        {
            var projectCategory = _repository.GetProjectCategoryById(id);
            Console.WriteLine(projectCategory.Name);
            //using (var context = new SJiraEntities())
            //{
            //    var projectCategory = context.ProjectCategories.Find(id);
            //    Console.WriteLine(projectCategory.Name);
            //}
        }
        private static List<Status> GetStatus()
        {

            using (var context = new CrudContext())
            {
                return context.Status.ToList();
                
            }
        }
        private static void UpdateProjectCategory()
        {
            int Id;
            using (var context = new CrudContext())
            {
                var projectCategory = context.ProjectCategories.FirstOrDefault(c => c.Name == "Internal");
                Id = projectCategory.Id;
                projectCategory.Description = "Internal projects";
                context.SaveChanges();
                
            }
            GetProjectCategory(Id);
        }
        private static void DeleteProjectCategory()
        {
            int Id;
            using (var context = new CrudContext())
            {
                var projectCategoies  = context.ProjectCategories.Where(c => c.Name == "Internal").ToList();
                foreach (var projectCategory in projectCategoies)
                {
                    context.ProjectCategories.Remove(projectCategory);
                }
                context.SaveChanges();
            }
            
        }
    }
}

