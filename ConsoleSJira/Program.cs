using System;
using System.Data.Entity;
using System.Web;

//using StructureMap;


namespace ConsoleSJira
{
    class Program1
    {
        //private static SimpleRepository _repository;
        //static void Main(string[] args)
        //{

        //    CreateDataBase();
        //    _repository = new SimpleRepository();

        //    Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SJiraContext>());
        //    //Database.SetInitializer<SJiraContext>(null);
        //    //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SJiraContext, Configuration>());
        //    //InsertProjectCategory();
        //    InsertProjectCategoryAndSave();
        //    //UpdateProjectCategory();
        //    //InsertProjectCategory_Project();
        //        //LazyLoading();
           
            
        //}
        static void Main(string[] args)
        {
            //System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<SJiraContext, DataLayer.Migrations.Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SJiraContext, DataLayer.Migrations.Configuration>());

            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SJiraContext>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SJiraContext, DataLayer.Migrations.Configuration>());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataLayer.Context.SJiraContext, DataLayer.Migrations.Configuration>());
                
            //Database.SetInitializer(new DropCreateDatabaseAlways<SJiraContext>());
            //Database.SetInitializer<SJiraContext>(null);
            CreateDataBase();
           

        }

        private static void CreateDataBase()
        {
            try
            {
       

                //var context = new SJiraContext();
                //context.Database.Initialize(true);
                
            }
            catch (Exception wCreateDataBase)
            {

                throw wCreateDataBase;
            }
            
        }

       
    }
}

