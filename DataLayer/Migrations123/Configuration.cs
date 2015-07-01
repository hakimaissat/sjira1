using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataLayer.Migrations
{
    using DataLayer;
    using DomainClasses.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DataLayer.Context;

    public class Configuration1 : DbMigrationsConfiguration<SJiraContext>
    {
        public Configuration1()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "DataLayer.Context.SJiraContext";
            //AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SJiraContext context)
        {
#if true
            CreateProjectCategory(context);
            CreateProjectType(context);
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
            CreateMenuItemType(context);
            //CreateMenumanagerType(context);

            //CreateMenuManagers_Home(context);
            CreateMenuItems_Home_Main(context);
            CreateMenuItems_Home_Secondary(context);

            //CreateBarMenuManager(context);
            //CreateMenuManagers_My_Open_Issues(context);
            CreateMenuItems_My_Open_Issues_SideBar(context);
            CreateMenuItems_My_Open_Issues_ToolBar(context);

            CreateGadgetType(context);
            CreateGadget(context);
            CreateSharedWith(context);
            CreateBoardType(context);
            CreateDashboardType(context);
            //CreateSharesFavorite(context);

            CreateDashboard(context);
            CreateDashboardMenuItems(context);
            CreateDashboardGadget(context);
            CreateDashboardUser(context);
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
        //private void CreateMenuManagers_Home(SJiraContext context)
        //{
        //    var Menus = new List<MenuManager>();
        //    //var MenuManagerTypeSideBar = context.MenuManagerTypes.Local.Where(c => c.Name == "SideBar").FirstOrDefault();
        //    //var MenuManagerTypeToolBar = context.MenuManagerTypes.Local.Where(c => c.Name == "ToolBar").FirstOrDefault();
        //    var MenuManagerTypeMain = context.MenuManagerTypes.Local.Where(c => c.Name == "Main").FirstOrDefault();
        //    var MenuManagerTypeSecondary = context.MenuManagerTypes.Local.Where(c => c.Name == "Secondary").FirstOrDefault();


        //    MenuManager entity = new MenuManager();
        //    //entity.MenuItemId = null; 

        //    entity.Title = "Home Main";
        //    entity.MenuManagerTypeId = MenuManagerTypeMain.MenuManagerTypeId;
        //    Menus.Add(entity);

        //     entity = new MenuManager();
        //    //entity.MenuItemId = null; 

        //     entity.Title = "Home SideBar";
        //    entity.MenuManagerTypeId = MenuManagerTypeSecondary.MenuManagerTypeId;
        //    Menus.Add(entity);


        //    context.MenuManagers.AddOrUpdate(c => new { c.Title, c.MenuManagerTypeId }, Menus.ToArray()); context.SaveChanges();
        //}
        private void CreateMenuItems_Home_Main(SJiraContext context)
        {
            try
            {

                var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
                var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
                var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
                var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();

                //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "Home Main" && c.MenuManagerType.Name == "Main").FirstOrDefault();


                var Menus = new List<MenuItem>();
                MenuItem entity = new MenuItem();
                entity.Title = "Main";
                entity.DisplayOrder = 10;
                entity.MenuAction = "#";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                entity = new MenuItem();
                entity.Title = "SideBar";
                entity.DisplayOrder = 10;
                entity.MenuAction = "#";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                entity = new MenuItem();
                entity.Title = "ToolBar";
                entity.DisplayOrder = 10;
                entity.MenuAction = "#";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray());
                context.SaveChanges();

                Menus = new List<MenuItem>();
                // Submenu for MenuItemId=2
                var MenuMain = context.MenuItems.Local.Where(m => m.Title == "Main").FirstOrDefault();

                //entity.ParentId = MenuMain.MenuItemId;
                //entity.Title = "Home";
                //entity.DisplayOrder = 10;
                //entity.MenuAction = "/Dashboards/SystemDashboard";
                ////entity.MenuManagerId = MenuManager1.MenuManagerId;
                //entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuMain.MenuItemId;
                entity.Title = "Dashboards";
                entity.MenuAction = "/Dashboard/Dashboard";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 20;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuMain.MenuItemId;
                entity.Title = "Projects";
                entity.MenuAction = "/Project/Projects";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 30;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuMain.MenuItemId;
                entity.Title = "Issues";
                entity.MenuAction = "/Issue/Issues";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 30;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuMain.MenuItemId;
                entity.Title = "Agile";
                entity.MenuAction = "/Agile/Agile";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 40;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();




                // Submenu for MenuItemId=2

                //--------------------------------------------------------------------------

                Menus = new List<MenuItem>();
                // Submenu for MenuItemId=2
                var Parent = context.MenuItems.Local.Where(m => m.Title == "Dashboards").FirstOrDefault();



                //--------------------------------------------------------------------------

                //entity = new MenuItem();

                //entity.ParentId = Parent.MenuItemId;
                //entity.Title = "Separated link";
                //entity.DisplayOrder = 90;
                ////entity.MenuManagerId = MenuManager1.MenuManagerId;
                //entity.MenuAction = "/Manage/Favorites";
                //entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                //entity = new MenuItem();

                entity.ParentId = Parent.MenuItemId;
                entity.Title = "Manage Dashboards";
                entity.DisplayOrder = 100;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Manage/Favorites";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();

                var MenuItemManageDashboards = context.MenuItems.Local.Where(m => m.Title == "Manage Dashboards").FirstOrDefault();

                entity = new MenuItem();
                entity.ParentId = MenuItemManageDashboards.MenuItemId;
                entity.Title = "Favorites";
                entity.DisplayOrder = 10;
                entity.MenuAction = "/Manage/Favorites";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                entity = new MenuItem();
                entity.ParentId = MenuItemManageDashboards.MenuItemId;
                entity.Title = "My";
                entity.DisplayOrder = 20;
                entity.MenuAction = "/Manage/My";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();
                entity.ParentId = MenuItemManageDashboards.MenuItemId;
                entity.Title = "Popular";
                entity.DisplayOrder = 30;
                entity.MenuAction = "/Manage/Popular";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();
                entity.ParentId = MenuItemManageDashboards.MenuItemId;
                entity.Title = "Search";
                entity.DisplayOrder = 40;
                entity.MenuAction = "/Dashboard/Search";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();


                // Submenus for MenuItemId=3
                var MenuItem3 = context.MenuItems.Local.Where(m => m.Title == "Projects").FirstOrDefault();

                //Current Project

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Current Project";
                entity.DisplayOrder = 1;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "My Scrum Project (MSP)";
                entity.DisplayOrder = 10;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/My_Scrum_Project_(MSP)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 11;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/My_Scrum_Project_(MSP)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                //--------------------------------------------------------------------------
                //Recent Projects

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Recent Projects";
                entity.DisplayOrder = 12;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "IRKD (IRKD)";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/IRKD_(IRKD)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Pomodoro Web Client (PWC)";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Pomodoro_Web_Client_(PWC)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 21;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Pomodoro_Web_Client_(PWC)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                //--------------------------------------------------------------------------
                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "View All Projects";
                entity.DisplayOrder = 30;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Index";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                //--------------------------------------------------------------------------
                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 31;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Index";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Import External Project";
                entity.DisplayOrder = 40;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Import_External_Project";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem3.MenuItemId;
                entity.Title = "Create Project";
                entity.DisplayOrder = 50;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Project/Create";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                // Submenus for MenuItemId=4
                var MenuItem4 = context.MenuItems.Local.Where(m => m.Title == "Issues").FirstOrDefault();

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();



                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Current Filter";
                entity.DisplayOrder = 1;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "IRKD Planning (30 Issues)";
                entity.DisplayOrder = 10;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/IRKD_Planning_(30 Issues)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                //----------------------------------------------------------------------------------

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 11;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/IRKD_Planning_(30 Issues)";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Search for Issues";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Search_for_Issues";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                Menus.Add(entity);
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Create Issue";
                entity.DisplayOrder = 30;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Create";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                //--------------------------------------------------------------------------
                Menus.Add(entity);
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 31;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Create";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();

                //Recent Issues 

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Recent Issues ";
                entity.DisplayOrder = 32;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                Menus.Add(entity);
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "IRKD-5 As a user, I would like";
                entity.DisplayOrder = 40;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/IRKD-5_As_a_user_I_would_like";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 41;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/IRKD-5_As_a_user_I_would_like";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                //--------------------------------------------------------------------------
                //Filters


                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Filters";
                entity.DisplayOrder = 42;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "My Open Issues";
                entity.DisplayOrder = 50;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/My_Open_Issues";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Reported by Me";
                entity.DisplayOrder = 60;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Reported_by_Me";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "2.0 Tirage";
                entity.DisplayOrder = 70;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/2.0_Tirage";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "High priority work";
                entity.DisplayOrder = 80;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/High_priority_work";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "IRKD Planning";
                entity.DisplayOrder = 90;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/IRKD_Planning";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Recent Created Bug";
                entity.DisplayOrder = 100;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Recent_Created_Bugss";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();

                //----------------------------------------------------------------------
                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 101;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Recent_Created_Bugss";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
                Menus = new List<MenuItem>();

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Manger Filters";
                entity.DisplayOrder = 110;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Issue/Manger_Filters";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();

                Menus = new List<MenuItem>();

                // Submenus for MenuItemId=5
                var MenuItem5 = context.MenuItems.Where(m => m.Title == "Agile").FirstOrDefault();

                //Recent Boards
                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Recent Boards";
                entity.DisplayOrder = 1;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "#";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "My Scrum Project";
                entity.DisplayOrder = 10;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/My_Scrum_Project";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "IRKD";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/IRKD";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "IRKD Planning";
                entity.DisplayOrder = 30;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/IRKD_Planning";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "2.0 Triage";
                entity.DisplayOrder = 40;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/2.0_Triage";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();

                Menus = new List<MenuItem>();

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "more...";
                entity.DisplayOrder = 50;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/more";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 51;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/more";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();

                Menus = new List<MenuItem>();



                //--------------------------------------------------------------------------
                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Mange Boards";
                entity.DisplayOrder = 60;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/Mange_Boards";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Getting Started";
                entity.DisplayOrder = 70;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/Getting_Started";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Separated link";
                entity.DisplayOrder = 80;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/Getting_Started";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                //--------------------------------------------------------------------------
                entity = new MenuItem();

                entity.ParentId = MenuItem5.MenuItemId;
                entity.Title = "Classic...";
                entity.DisplayOrder = 90;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Agile/Classic";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
            }
            catch (Exception eCreateMenuItem)
            {

                throw eCreateMenuItem;
            }
        }
        private void CreateMenuItems_Home_Secondary(SJiraContext context)
        {
            try
            {

                var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
                var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
                var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
                var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();

                //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "Home SideBar" && c.MenuManagerType.Name == "Secondary").FirstOrDefault();
                MenuItem entity = new MenuItem();
                var Menus = new List<MenuItem>();


                entity.Title = "Paln";
                entity.DisplayOrder = 10;
                entity.MenuAction = "/Plan/Index";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.Title = "Work";
                entity.MenuAction = "/Work/Work";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 20;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.Title = "Report";
                entity.MenuAction = "/Report/Report";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 30;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.Title = "Tools";
                entity.MenuAction = "/Tools/Tools";
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.DisplayOrder = 30;
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);



                //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();
                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();

                Menus = new List<MenuItem>();
                // Submenu for MenuItemId=2
                var MenuItem4 = context.MenuItems.Local.Where(m => m.Title == "Tools").FirstOrDefault();


                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Configure";
                entity.DisplayOrder = 10;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Tools/Configure";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);



                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Copy";
                entity.DisplayOrder = 30;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Tools/Copy";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);






                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Delete";
                entity.DisplayOrder = 10;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Tools/Delete";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);






                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Create Board";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Tools/Create_Board";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

                entity = new MenuItem();

                entity.ParentId = MenuItem4.MenuItemId;
                entity.Title = "Show Epic Panel";
                entity.DisplayOrder = 20;
                //entity.MenuManagerId = MenuManager1.MenuManagerId;
                entity.MenuAction = "/Tools/Show_Epic_Panel";
                entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);



                context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
            }
            catch (Exception eCreateMenuItem)
            {

                throw eCreateMenuItem;
            }
        }
        //private void CreateMenuManagers_My_Open_Issues(SJiraContext context)
        //{
        //    var MenuItemMyOpenIssues= context.MenuItems.Local.Where(c => c.Title == "My Open Issues").FirstOrDefault();
        //    var MenuManagerTypeSideBar = context.MenuManagerTypes.Local.Where(c => c.Name == "SideBar").FirstOrDefault();
        //    var MenuManagerTypeToolBar = context.MenuManagerTypes.Local.Where(c => c.Name == "ToolBar").FirstOrDefault();

        //    var Menus = new List<MenuManager>();

        //    MenuManager entity = new MenuManager();
        //    entity.MenuItemId = MenuItemMyOpenIssues.MenuItemId; 

        //    entity.Title = "My Open Issues";
        //    entity.MenuManagerTypeId = MenuManagerTypeSideBar.MenuManagerTypeId;
        //    Menus.Add(entity);

        //    entity = new MenuManager();
        //    entity.MenuItemId = MenuItemMyOpenIssues.MenuItemId;

        //    entity.Title = "My Open Issues";
        //    entity.MenuManagerTypeId = MenuManagerTypeToolBar.MenuManagerTypeId;
        //    Menus.Add(entity);

        //    context.MenuManagers.AddOrUpdate(c => new { c.Title, c.MenuManagerTypeId }, Menus.ToArray()); context.SaveChanges();
        //}
        private void CreateMenuItems_My_Open_Issues_SideBar(SJiraContext context)
        {
            //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "My Open Issues" && c.MenuManagerType.Name == "SideBar").FirstOrDefault();
            var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
            var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
            var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
            var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();
            MenuItem entity = new MenuItem();

            var Menus = new List<MenuItem>();

            entity.Title = "New Filter";
            entity.MenuAction = "/Issue/New_Filter";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 10;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Find filters";
            entity.MenuAction = "/Issue/Find_filters";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 20;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            //------------------------------------------------------------------

            //--------------------------------------------------------------------------

            entity = new MenuItem();


            entity.Title = "Separated link";
            entity.DisplayOrder = 21;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Issue/Find_filters";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "My Open Issues";
            entity.MenuAction = "/Issue/My_Open_Issues";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 30;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Reported by Me";
            entity.MenuAction = "/Issue/Reported_by_Me";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 40;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Recently Viewed";
            entity.MenuAction = "/Issue/Recently_Viewed";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 50;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "All Issues";
            entity.MenuAction = "/Issue/All_Issues";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 60;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            //---------------------------------------------------------------------------
            entity = new MenuItem();

            entity.Title = "Separated link";
            entity.DisplayOrder = 61;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Issue/All_Issues";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "FAVORITE FILTERS";
            entity.DisplayOrder = 62;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "#";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "2.0 Triage";
            entity.MenuAction = "/Issue/2.0_Triage";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 70;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);



            entity = new MenuItem();

            entity.Title = "High priority work";
            entity.MenuAction = "/Issue/High_priority_work";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 80;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "IRDK Planning";
            entity.MenuAction = "/Issue/IRDK_Planning";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 90;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Recently Created Bugs";
            entity.MenuAction = "/Issue/Recently_Created_Bugs";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 100;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
            //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();
        }
        private void CreateMenuItems_My_Open_Issues_ToolBar(SJiraContext context)
        {
            var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
            var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
            var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
            var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();

            //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "My Open Issues" && c.MenuManagerType.Name == "ToolBar").FirstOrDefault();
            MenuItem entity = new MenuItem();

            var Menus = new List<MenuItem>();

            entity.Title = "New Filter";
            entity.MenuAction = "/Issue/New_Filter";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 10;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Type";
            entity.MenuAction = "/Issue/Type";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 20;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            //------------------------------------------------------------------
            entity = new MenuItem();

            entity.Title = "Status";
            entity.MenuAction = "/Issue/Status";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 30;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Assignee";
            entity.MenuAction = "/Issue/Assigneee";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 40;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Contains Text";
            entity.MenuAction = "/Issue/Contains_Text";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 50;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "More";
            entity.MenuAction = "/Issue/More";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 60;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            //---------------------------------------------------------------------------

            entity = new MenuItem();

            entity.Title = "Advanced";
            entity.MenuAction = "/Issue/Advanced";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 70;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);



            entity = new MenuItem();

            entity.Title = "List_Detail";
            entity.MenuAction = "/Issue/List_Detail";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 80;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId; Menus.Add(entity);

            context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
            //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();


        }
        private void CreateDashboardMenuItems(SJiraContext context)
        {
            var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
            var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
            var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
            var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();
            var Menus = new List<MenuItem>();

            MenuItem entity = new MenuItem();
            entity.Title = "Add Gadget";
            entity.MenuAction = "/Dashboard/Search";
            entity.DisplayOrder = 10;
            entity.MenuIcon = @"<i class=""fa fa-plus""></i>";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();
            entity.Title = "Edit Layout";
            entity.MenuAction = "/Dashboard/Search";
            entity.DisplayOrder = 10;
            entity.MenuIcon = @"<i class=""fa fa-pencil""></i>";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();
            entity.Title = "Tools";
            entity.MenuAction = "/Dashboard/Search";
            entity.DisplayOrder = 10;
            entity.MenuIcon = @"<i class=""fa a-gear fa-cog""></i>";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);
            //80	NULL	Add Gadget	10	/Dashboard/Search	<i class="fa fa-plus"></i> 	NULL
            //81	NULL	Edit Layout	20	/Dashboard/Search	<i class="fa fa-pencil"></i>	NULL
            //82	NULL	Tools	30	/Dashboard/Search	<i class="fa a-gear fa-cog"></i>	NULL
            context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();

            var MenuitemTools = context.MenuItems.Where(c => c.Title == "Tools" && c.MenuAction == "/Dashboard/Search").FirstOrDefault();
            var MenuitemEditLayout = context.MenuItems.Where(c => c.Title == "Edit Layout" && c.MenuAction == "/Dashboard/Search").FirstOrDefault();
            var MenuitemAddGadget = context.MenuItems.Where(c => c.Title == "Add Gadget" && c.MenuAction == "/Dashboard/Search").FirstOrDefault();


            //var DashboardSystemDashboard = context.Dashboards.Where(c => c.Name == "System Dashboard").FirstOrDefault();
            //var DashboardJIRAJuniorDasboard = context.Dashboards.Where(c => c.Name == "JIRA Junior Dasboard").FirstOrDefault();
            //var DashboardTheQuirkyIRKDDashboard = context.Dashboards.Where(c => c.Name == "The Quirky IRKD Dashboard").FirstOrDefault();
            var Menus1 = new List<DashboardMenuItem>();

            foreach (Dashboard dashboard in context.Dashboards)
            {

                if (dashboard.DashboardType.Name != "One")
                {
                    DashboardMenuItem entity1 = new DashboardMenuItem();
                    
                    entity1.MenuItemId = MenuitemAddGadget.MenuItemId;
                    entity1.DashboardId = dashboard.DashboardId;
                    entity1.DisplayOrder = 10;
                    Menus1.Add(entity1);

                    entity1 = new DashboardMenuItem();
                    entity1.MenuItemId = MenuitemEditLayout.MenuItemId;
                    entity1.DashboardId = dashboard.DashboardId;
                    entity1.DisplayOrder = 20;
                    Menus1.Add(entity1);

                    entity1 = new DashboardMenuItem();
                    entity1.MenuItemId = MenuitemTools.MenuItemId;
                    entity1.DashboardId = dashboard.DashboardId;
                    entity1.DisplayOrder = 30;
                    Menus1.Add(entity1);

                }
                else if (dashboard.DashboardType.Name == "One")
                {

                    DashboardMenuItem entity1 = new DashboardMenuItem();
                    entity1.MenuItemId = MenuitemTools.MenuItemId;
                    entity1.DashboardId = dashboard.DashboardId;
                    entity1.DisplayOrder = 10;
                    Menus1.Add(entity1);

                }
            }
            context.DashboardMenuItems.AddOrUpdate(c => new { c.MenuItemId, c.DashboardId }, Menus1.ToArray()); context.SaveChanges();
            //DashboardMenuItem entity1 = new DashboardMenuItem();
            //entity1.MenuItemId = MenuitemTools.MenuItemId;
            //entity1.DashboardId = DashboardSystemDashboard.DashboardId;
            //entity1.DisplayOrder = 10;

            //Menus1.Add(entity1);

            //entity1 = new DashboardMenuItem();
            //entity1.MenuItemId = MenuitemEditLayout.MenuItemId;
            //entity1.DashboardId = DashboardJIRAJuniorDasboard.DashboardId;
            //entity1.DisplayOrder = 10;

            //Menus1.Add(entity1);
            //entity1 = new DashboardMenuItem();
            //entity1.MenuItemId = MenuitemAddGadget.MenuItemId;
            //entity1.DashboardId = DashboardJIRAJuniorDasboard.DashboardId;
            //entity1.DisplayOrder = 20;

            //Menus1.Add(entity1);
            //entity1 = new DashboardMenuItem();
            //entity1.MenuItemId = MenuitemTools.MenuItemId;
            //entity1.DashboardId = DashboardJIRAJuniorDasboard.DashboardId;
            //entity1.DisplayOrder = 30;

            //Menus1.Add(entity1);

            //context.DashboardMenuItems.AddOrUpdate(c => new { c.MenuItemId, c.DashboardId }, Menus1.ToArray()); context.SaveChanges();

        }
        //private void CreateMenuManagers_Configure(SJiraContext context)
        //{
        //    var MenuItemConfigure = context.MenuItems.Local.Where(c => c.Title == "Configure").FirstOrDefault();
        //    var MenuManagerTypeTabs = context.MenuManagerTypes.Local.Where(c => c.Name == "Tabs").FirstOrDefault();
        //    var Menus = new List<MenuManager>();
        //    MenuManager entity = new MenuManager();
        //    entity.MenuItemId = MenuItemConfigure.MenuItemId;

        //    entity.Title = "Configure";
        //    entity.MenuManagerTypeId = MenuManagerTypeTabs.MenuManagerTypeId;
        //    Menus.Add(entity);
        //    context.MenuManagers.AddOrUpdate(c => new { c.Title, c.MenuManagerTypeId }, Menus.ToArray()); context.SaveChanges();
        //}
        private void CreateMenuItems_Configure_Tabs(SJiraContext context)
        {
            //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "Configure" && c.MenuManagerType.Name == "Tabs").FirstOrDefault();
            var MenuitemTypeButton = context.MenuItemTypes.Local.Where(c => c.Name == "Button").FirstOrDefault();
            var MenuitemTypeLink = context.MenuItemTypes.Local.Where(c => c.Name == "Link").FirstOrDefault();
            var MenuitemTypeDropdown = context.MenuItemTypes.Local.Where(c => c.Name == "Dropdown").FirstOrDefault();
            var MenuitemTypeInput = context.MenuItemTypes.Local.Where(c => c.Name == "Input").FirstOrDefault();
            MenuItem entity = new MenuItem();

            var Menus = new List<MenuItem>();

            entity.Title = "Filter";
            entity.MenuAction = "/Configure/Filter";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 10;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Columns";
            entity.MenuAction = "/Configure/Columns";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 20;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Swimlanes";
            entity.DisplayOrder = 21;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Configure/Swimlanes";
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "Quick Filters";
            entity.MenuAction = "/Configure/Quick_Filters";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 30;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Card Colours";
            entity.MenuAction = "/Configure/Card_Colours";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 40;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Estimation";
            entity.MenuAction = "/Configure/Estimation";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 50;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);


            entity = new MenuItem();

            entity.Title = "Working Days";
            entity.MenuAction = "/Configure/Working_Days";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 60;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);





            entity = new MenuItem();

            entity.Title = "Issue Detail View";
            entity.MenuAction = "/Configure/Issue_Detail_View";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 70;
            entity.MenuItemTypeId = MenuitemTypeLink.MenuItemTypeId;
            Menus.Add(entity);

            context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuAction }, Menus.ToArray()); context.SaveChanges();
            //context.MenuItems.AddOrUpdate(c => new { c.Title, c.MenuManagerId }, Menus.ToArray()); context.SaveChanges();
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
        private void CreateDashboard(SJiraContext context)
        {
            var DashboardFour = context.DashboardTypes.Where(c => c.Name == "Four").FirstOrDefault();
            var DashboardOne = context.DashboardTypes.Where(c => c.Name == "One").FirstOrDefault();
            var DashboardOneLeft = context.DashboardTypes.Where(c => c.Name == "One Left").FirstOrDefault();
            var DashboardSharedWithAll = context.SharedWiths.Where(c => c.Name == "Shared with all users").FirstOrDefault();
            var DashboardPrivateDashboard = context.SharedWiths.Where(c => c.Name == "Private Dashboard").FirstOrDefault();
            var user1 = context.UserProfiles.Where(c => c.UserName == "XT19141").FirstOrDefault();
            var Dasboards = new List<Dashboard>();

            Dashboard entity = new Dashboard();
            entity.Name = "System Dashboard";
            entity.SharedWithId = DashboardSharedWithAll.SharedWithId;
            entity.Description = "PDB";
            entity.DashboardTypeId = DashboardOne.DashboardTypeId;
            entity.OwnerId = user1.UserId;
            Dasboards.Add(entity);

            entity = new Dashboard();
            entity.Name = "JIRA Junior Dasboard";
            entity.SharedWithId = DashboardSharedWithAll.SharedWithId;
            entity.Description = "PIP";
            entity.DashboardTypeId = DashboardOneLeft.DashboardTypeId;
            entity.OwnerId = user1.UserId;
            Dasboards.Add(entity);

            var user2 = context.UserProfiles.Where(c => c.UserName == "xt17640").FirstOrDefault();
            entity = new Dashboard();
            entity.Name = "The Quirky IRKD Dashboard";
            entity.SharedWithId = DashboardPrivateDashboard.SharedWithId;
            entity.Description = "PIP";
            entity.DashboardTypeId = DashboardFour.DashboardTypeId;
            entity.OwnerId = user2.UserId;
            Dasboards.Add(entity);

            var user3 = context.UserProfiles.Where(c => c.UserName == "XT10596").FirstOrDefault();
            entity = new Dashboard();
            entity.Name = "IRKD Dashboard";
            entity.SharedWithId = DashboardSharedWithAll.SharedWithId;
            entity.Description = "PIP";
            entity.DashboardTypeId = DashboardFour.DashboardTypeId;
            entity.OwnerId = user3.UserId;
            Dasboards.Add(entity);


            entity = new Dashboard();
            entity.Name = "Agile Dashboard";
            entity.SharedWithId = DashboardSharedWithAll.SharedWithId;
            entity.Description = "PIP";
            entity.DashboardTypeId = DashboardFour.DashboardTypeId;
            entity.OwnerId = user3.UserId;
            Dasboards.Add(entity);



            entity = new Dashboard();
            entity.Name = "Realtime Activity Dashboard";
            entity.SharedWithId = DashboardSharedWithAll.SharedWithId;
            entity.Description = "PIP";
            entity.DashboardTypeId = DashboardFour.DashboardTypeId;
            entity.OwnerId = user3.UserId;
            Dasboards.Add(entity);

            //   var Dashboard = new List<Dashboard>
            //{

            //    new Dashboard{ Name="Sytem Dashboard",
            //       SharedWithId=DashboardSharedWiths.SharedWithId,
            //        Description="PDB",
            //        DashboardTypeId=DashboardFour.DashboardTypeId,
            //        OwnerId=user1.UserId},

            //    new Dashboard{ Name="JIRA Junior Dasboard",
            //        SharedWithId=DashboardSharedWiths.SharedWithId,
            //        Description="PIP",

            //        DashboardTypeId=DashboardFour.DashboardTypeId,
            //        OwnerId=user1.UserId},


            //};
            context.Dashboards.AddOrUpdate(c => new { c.Name }, Dasboards.ToArray()); context.SaveChanges();
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
            try
            {
                context.ProjectCategories.AddOrUpdate(c => c.Name, projectCategory.ToArray()); context.SaveChanges();
            }
            catch (Exception eProjectCategory)
            {

                throw eProjectCategory;
            }

        }
        private void CreateProjectType(SJiraContext context)
        {
            var projectType = new List<ProjectType>
        {


            new ProjectType{ Name="Simple Issue Tracking",Description="Simple Issue Trackings" },
            new ProjectType{ Name="Project Mangement",Description="Project Mangement"},
            new ProjectType{ Name="Agile Kanban",Description="Agile Kanban"},
            new ProjectType{ Name="JIRA Classic",Description="JIRA Classic" },
            new ProjectType{ Name="Software Development",Description="Software Development"},
            new ProjectType{ Name="Agile Scrum",Description="Agile Scrum"},
            new ProjectType{ Name="Demo Projet",Description="Demo Projet"},
            

        };
            context.ProjectTypes.AddOrUpdate(c => c.Name, projectType.ToArray()); context.SaveChanges();
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

            new WorkType{ Name="Spint Change"},
            new WorkType{ Name="User Change"},
            new WorkType{ Name="Status Change"},
            new WorkType{ Name="Log Work"},
           

        };
            context.WorkTypes.AddOrUpdate(c => c.Name, workType.ToArray()); context.SaveChanges();
        }
        private void CreateMenuItemType(SJiraContext context)
        {
            var menuItemType = new List<MenuItemType>
        {

            new MenuItemType{ Name="button"},
            new MenuItemType{ Name="Link", },
            new MenuItemType{ Name="Dropdown"},
            new MenuItemType{ Name="input"},
            

        };
            context.MenuItemTypes.AddOrUpdate(c => c.Name, menuItemType.ToArray()); context.SaveChanges();
        }
        //private void CreateMenumanagerType(SJiraContext context)
        //{
        //    var menuManagerType = new List<MenuManagerType>
        //{
        //    new MenuManagerType{ Name="ToolBar"},
        //    new MenuManagerType{ Name="SideBar", },
        //    new MenuManagerType{ Name="Main"},  
        //     new MenuManagerType{ Name="Secondary"},
        //     new MenuManagerType{ Name="Tabs"},  

        //};
        //    context.MenuManagerTypes.AddOrUpdate(c => c.Name, menuManagerType.ToArray()); context.SaveChanges();
        //}
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
            try
            {
                var issueTypes = new List<IssueType>
                {

                    new IssueType{ Name="Bug", Description="Software Developpement ", Sequence=5},
                    new IssueType{ Name="template"},
                    new IssueType{ Name="SRS_Issue"},
                    new IssueType{ Name="In Development"},
                    new IssueType{ Name="DataCity"},
                    new IssueType{ Name="SL-Action"},
                    new IssueType{ Name="Theme"},
                    new IssueType{ Name="Task (general)"},
                    new IssueType{ Name="Technical Task"},
                    new IssueType{ Name="New Feature",Description="Software Developpement ", Sequence=4},
                    new IssueType{ Name="Question"},
                    new IssueType{ Name="Task", Description="Software Developpement ", Sequence=2},
                    new IssueType{ Name="Improvement"},
                    new IssueType{ Name="Sub Task",Description="Software Developpement ", Sequence=3},
                    new IssueType{ Name="Epic"},
                    new IssueType{ Name="Story", Description="Software Developpement ", Sequence=1},
                    new IssueType{ Name="Technical Debt"}
                };
                context.IssueTypes.AddOrUpdate(c => c.Name, issueTypes.ToArray()); context.SaveChanges();
                //issueTypes.ForEach(b => context.IssueTypes.Add(b));
            }
            catch (Exception eCreateIssueType)
            {

                throw eCreateIssueType;
            }

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
                        new Issue //(Guid.NewGuid())
                          {
                              IssueId=Guid.NewGuid(),
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
                              IssueId=Guid.NewGuid(),
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
        private void CreateChild(SJiraContext context)
        {

            //var MenuManager1 = context.MenuManagers.Local.Where(c => c.Title == "Principal").FirstOrDefault();
            MenuItem entity = new MenuItem();
            var Menus = new List<MenuItem>();


            entity.Title = "Home";
            entity.DisplayOrder = 10;
            entity.MenuAction = "/Home/Home";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Maintenance";
            entity.MenuAction = "/Maintenance/Maintenance";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 20;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Reports";
            entity.MenuAction = "/Reports/Reports";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 30;
            Menus.Add(entity);

            entity = new MenuItem();

            entity.Title = "Lookup";
            entity.MenuAction = "/Lookup/Lookup";
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.DisplayOrder = 30;
            Menus.Add(entity);


            context.MenuItems.AddOrUpdate(c => new { c.Title }, Menus.ToArray()); context.SaveChanges();
            Menus = new List<MenuItem>();
            // Submenu for MenuItemId=2
            var Parent = context.MenuItems.Local.Where(m => m.Title == "Maintenance").FirstOrDefault();


            entity = new MenuItem();

            entity.ParentId = Parent.MenuItemId;
            entity.Title = "Users";
            entity.DisplayOrder = 10;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Maintenance/Users";
            Menus.Add(entity);
            //Menus.Find(m => m.Title == "Maintenance").Menus.Add(entity);

            entity = new MenuItem();

            entity.ParentId = Parent.MenuItemId;
            entity.Title = "Roles";
            entity.DisplayOrder = 20;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Maintenance/Roles";
            //Menus.Find(m => m.Title == "Maintenance").Menus.Add(entity);
            Menus.Add(entity);
            // Submenus for MenuItemId=3
            var MenuItem3 = context.MenuItems.Local.Where(m => m.Title == "Reports").FirstOrDefault();

            entity = new MenuItem();

            entity.ParentId = MenuItem3.MenuItemId;
            entity.Title = "Report 1";
            entity.DisplayOrder = 10;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Reports/Report1";
            //Menus.Find(m => m.Title == "Reports").Menus.Add(entity);
            Menus.Add(entity);

            entity = new MenuItem();

            entity.ParentId = MenuItem3.MenuItemId;
            entity.Title = "Report 2";
            entity.DisplayOrder = 20;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Reports/Report2";
            //Menus.Find(m => m.Title == "Reports").Menus.Add(entity);
            Menus.Add(entity);

            // Submenus for MenuItemId=4
            var MenuItem4 = context.MenuItems.Local.Where(m => m.Title == "Lookup").FirstOrDefault();

            entity = new MenuItem();

            entity.ParentId = MenuItem4.MenuItemId;
            entity.Title = "Logs";
            entity.DisplayOrder = 10;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Lookup/Logs";
            //Menus.Find(m => m.Title == "Lookup").Menus.Add(entity);
            Menus.Add(entity);

            entity = new MenuItem();

            entity.ParentId = MenuItem4.MenuItemId;
            entity.Title = "Resources";
            entity.DisplayOrder = 20;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Lookup/Resources";
            //Menus.Find(m => m.Title == "Lookup").Menus.Add(entity);
            Menus.Add(entity);

            entity = new MenuItem();

            entity.ParentId = MenuItem4.MenuItemId;
            entity.Title = "Lookup Tables";
            entity.DisplayOrder = 30;
            //entity.MenuManagerId = MenuManager1.MenuManagerId;
            entity.MenuAction = "/Lookup/LookupTables";
            //Menus.Find(m => m.Title == "Lookup").Menus.Add(entity);
            Menus.Add(entity);


            context.MenuItems.AddOrUpdate(c => new { c.Title }, Menus.ToArray()); context.SaveChanges();
        }
        private void CreateGadgetType(SJiraContext context)
        {
            var gadgetType = new List<GadgetType>
        {

          
                new GadgetType{ Name="Bambo"},
                new GadgetType{ Name="Charts"},
                new GadgetType{ Name="Clover"},
                 new GadgetType{ Name="JIRA"},
                  new GadgetType{ Name="Other"},
                  new GadgetType{ Name="Walboard"},

        };
            context.GadgetTypes.AddOrUpdate(c => c.Name, gadgetType.ToArray()); context.SaveChanges();
        }
        private void CreateGadget(SJiraContext context)
        {
            var gadget = new List<Gadget>
        {

            new Gadget{ Name="Resolved Charts",Title="Line Chart Example",MenuAction="~/Views/Dashboard/Gadgets/Line_Chart.cshtml",DisplayOrder=5},
            new Gadget{ Name="Pie Chat",Title="Pie Chart Example",MenuAction="~/Views/Dashboard/Gadgets/Pie_Chart.cshtml",DisplayOrder=1},
            new Gadget{ Name="Filter Result",Title="Multiple Axes Line Chart Example ",MenuAction="~/Views/Dashboard/Gadgets/Multiple_Line_Chart.cshtml",DisplayOrder=2},
            new Gadget{ Name="Road Map",Title="Bar Chart Example ",MenuAction="~/Views/Dashboard/Gadgets/Bar_Chart.cshtml",DisplayOrder=4},
             new Gadget{ Name="Two Dimentional Filter  Statistics",Title="Moving Line Chart Example",MenuAction="~/Views/Dashboard/Gadgets/Moving_Line_Chart.cshtml",DisplayOrder=3},
               
        };
            context.Gadgets.AddOrUpdate(c => c.Name, gadget.ToArray()); context.SaveChanges();
        }
        private void CreateDashboardGadget(SJiraContext context)
        {
            var DashboardGadget = new List<DashboardGadget>
        {
            new DashboardGadget{ GadgetId=1,DashboardId=1,Sequence=1},         
            new DashboardGadget{ GadgetId=1,DashboardId=2,Sequence=1},
            new DashboardGadget{ GadgetId=2,DashboardId=2,Sequence=2}, 
            new DashboardGadget{ GadgetId=3,DashboardId=1,Sequence=2},         
            new DashboardGadget{ GadgetId=3,DashboardId=3,Sequence=2},
            new DashboardGadget{ GadgetId=4,DashboardId=2,Sequence=2}, 
            new DashboardGadget{ GadgetId=5,DashboardId=3,Sequence=1},
        };
            context.DashboardGadgets.AddOrUpdate(c => new { c.GadgetId, c.DashboardId }, DashboardGadget.ToArray()); context.SaveChanges();
        }
        private void CreateDashboardUser(SJiraContext context)
        {
            //    var DashboardUser = new List<DashboardUser>
            //{
            //    new DashboardUser{ UserId=2,DashboardId=1},
            //    new DashboardUser{ UserId=2,DashboardId=1},
            //    new DashboardUser{ UserId=2,DashboardId=2},
            //    new DashboardUser{ UserId=2,DashboardId=3},
            //    new DashboardUser{ UserId=3,DashboardId=1},
            //    new DashboardUser{ UserId=4,DashboardId=1},
            //    new DashboardUser{ UserId=4,DashboardId=3},
            //    new DashboardUser{ UserId=5,DashboardId=3},
            //    new DashboardUser{ UserId=1,DashboardId=1},
            //    new DashboardUser{ UserId=1,DashboardId=2},
            //    new DashboardUser{ UserId=1,DashboardId=3},       
            //};
            //    context.DashboardUsers.AddOrUpdate(c => new { c.UserId, c.DashboardId }, DashboardUser.ToArray()); context.SaveChanges();
            var dashboardUser = new List<DashboardUser>();

            foreach (Dashboard dashboard in context.Dashboards)
            {
                if (dashboard.SharedWith.Name == "Private Dashboard")
                {
                    dashboardUser.Add(new DashboardUser { UserId = dashboard.OwnerId, DashboardId = dashboard.DashboardId });
                }
                if (dashboard.SharedWith.Name == "Shared with all users")
                {
                    foreach (UserProfile user in context.UserProfiles)
                    {
                        //if (dashboard.OwnerId != user.UserId)
                        //{
                        dashboardUser.Add(new DashboardUser { UserId = user.UserId, DashboardId = dashboard.DashboardId });
                        //}
                    }
                }
            }

            context.DashboardUsers.AddOrUpdate(c => new { c.UserId, c.DashboardId }, dashboardUser.ToArray()); context.SaveChanges();
        }
        private void CreateSharedWith(SJiraContext context)
        {
            var sharedWith = new List<SharedWith>
        {

            new SharedWith{ Name="Private Dashboard"},
            new SharedWith{ Name="Shared with all users"},
           

        };
            context.SharedWiths.AddOrUpdate(c => c.Name, sharedWith.ToArray()); context.SaveChanges();
        }
        private void CreateBoardType(SJiraContext context)
        {
            var boardType = new List<BoardType>
        {

            new BoardType{ Name="Scrum"},
            new BoardType{ Name="Kanban"},
           

        };
            context.BoardTypes.AddOrUpdate(c => c.Name, boardType.ToArray()); context.SaveChanges();
        }
        private void CreateDashboardType(SJiraContext context)
        {
            var dashboardType = new List<DashboardType>
        {

            new DashboardType{ Name="One",Code="12",Layout="~/Views/Dashboard/Gadgets/One.cshtml"},
             new DashboardType{ Name="Two",Code="66",Layout="~/Views/Dashboard/Gadgets/Two.cshtml"},
             new DashboardType{ Name="Three",Code="444",Layout="~/Views/Dashboard/Gadgets/Three.cshtml"},
            new DashboardType{ Name="Four",Code="6666",Layout="~/Views/Dashboard/Gadgets/Four.cshtml"},       
            new DashboardType{ Name="One Left",Code="39",Layout="~/Views/Dashboard/Gadgets/OneLeft.cshtml"},
             new DashboardType{ Name="One Right",Code="93",Layout="~/Views/Dashboard/Gadgets/OneRight.cshtml"},
            
        };
            context.DashboardTypes.AddOrUpdate(c => c.Code, dashboardType.ToArray()); context.SaveChanges();
        }
        //private void CreateSharesFavorite(SJiraContext context)
        //{
        //    var sharesFavorite = new List<SharesFavorite>
        //{

        //    new SharesFavorite{ Name="Shares"},
        //    new SharesFavorite{ Name="Favorite"},


        //};
        //    context.SharesFavorites.AddOrUpdate(c => c.Name, sharesFavorite.ToArray()); context.SaveChanges();
        //}

        //private void CreateBarMenuItem_My_Open_Issues_SideBar(SJiraContext context)
        //{

        //    var BarMenuManager1 = context.BarMenuManagers.Local.Where(c => c.Title == "My Open Issues SideBar").FirstOrDefault();
        //    BarMenuItem entity = new BarMenuItem();

        //    var Menus = new List<BarMenuItem>();
        //    
        //    entity.Title = "New Filter";
        //    entity.MenuAction = "/Issue/New_Filter";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 10;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //   
        //    entity.Title = "Find filters";
        //    entity.MenuAction = "/Issue/Find_filters";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 20;
        //    Menus.Add(entity);
        //    //------------------------------------------------------------------

        //    //--------------------------------------------------------------------------

        //    entity = new BarMenuItem();
        //    

        //    entity.Title = "Separated link";
        //    entity.DisplayOrder = 21;
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.MenuAction = "/Issue/Find_filters";
        //    Menus.Add(entity);


        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "My Open Issues";
        //    entity.MenuAction = "/Issue/My_Open_Issues";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 30;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Reported by Me";
        //    entity.MenuAction = "/Issue/Reported_by_Me";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 40;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Recently Viewed";
        //    entity.MenuAction = "/Issue/Recently_Viewed";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 50;
        //    Menus.Add(entity);


        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "All Issues";
        //    entity.MenuAction = "/Issue/All_Issues";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 60;
        //    Menus.Add(entity);
        //    //---------------------------------------------------------------------------
        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Separated link";
        //    entity.DisplayOrder = 61;
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.MenuAction = "/Issue/All_Issues";
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "FAVORITE FILTERS";
        //    entity.DisplayOrder = 62;
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.MenuAction = "#";
        //    Menus.Add(entity);


        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "2.0 Triage";
        //    entity.MenuAction = "/Issue/2.0_Triage";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 70;
        //    Menus.Add(entity);



        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "High priority work";
        //    entity.MenuAction = "/Issue/High_priority_work";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 80;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "IRDK Planning";
        //    entity.MenuAction = "/Issue/IRDK_Planning";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 90;

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Recently Created Bugs";
        //    entity.MenuAction = "/Issue/Recently_Created_Bugs";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 100;
        //    Menus.Add(entity);
        //    context.BarMenuItems.AddOrUpdate(c => new { c.Title }, Menus.ToArray()); context.SaveChanges();
        //}
        //private void CreateBarMenuItem_My_Open_Issues_ToolBar(SJiraContext context)
        //{

        //    var BarMenuManager1 = context.BarMenuManagers.Local.Where(c => c.Title == "My Open Issues ToolBar").FirstOrDefault();
        //    BarMenuItem entity = new BarMenuItem();

        //    var Menus = new List<BarMenuItem>();
        //    
        //    entity.Title = "New Filter";
        //    entity.MenuAction = "/Issue/New_Filter";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 10;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //   
        //    entity.Title = "Type";
        //    entity.MenuAction = "/Issue/Type";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 20;
        //    Menus.Add(entity);
        //    //------------------------------------------------------------------
        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Status";
        //    entity.MenuAction = "/Issue/Status";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 30;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Assignee";
        //    entity.MenuAction = "/Issue/Assigneee";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 40;
        //    Menus.Add(entity);

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Contains Text";
        //    entity.MenuAction = "/Issue/Contains_Text";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 50;
        //    Menus.Add(entity);


        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "More";
        //    entity.MenuAction = "/Issue/More";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 60;
        //    Menus.Add(entity);
        //    //---------------------------------------------------------------------------

        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "Advanced";
        //    entity.MenuAction = "/Issue/Advanced";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 70;
        //    Menus.Add(entity);



        //    entity = new BarMenuItem();
        //    
        //    entity.Title = "List_Detati";
        //    entity.MenuAction = "/Issue/List_Detati";
        //    entity.BarMenuManagerId = BarMenuManager1.Id;
        //    entity.DisplayOrder = 80;
        //    Menus.Add(entity);


        //    context.BarMenuItems.AddOrUpdate(c => new { c.Title }, Menus.ToArray()); context.SaveChanges();
        //}
        //private void CreateBarMenuManager(SJiraContext context)
        //{
        //    var Child = context.MenuItems.Local.Where(c => c.Title == "My Open Issues").FirstOrDefault();

        //    var Menus = new List<BarMenuManager>();

        //    BarMenuManager entity = new BarMenuManager();
        //    
        //    entity.Title = "My Open Issues SideBar";
        //    entity.MenuItemId = Child.Id;
        //    Menus.Add(entity);

        //     entity = new BarMenuManager();
        //   
        //    entity.Title = "My Open Issues ToolBar";
        //    entity.MenuItemId = Child.Id;
        //    Menus.Add(entity);

        //    context.BarMenuManagers.AddOrUpdate(c => new { c.Title }, Menus.ToArray()); context.SaveChanges();
        //}

    }
}

