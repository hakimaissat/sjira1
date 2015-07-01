using System;
using System.Data.Entity;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MvcSJira.Infrastructure;
using MvcSJira.Infrastructure.Tasks;
using StructureMap;
using MvcSJira.App_Start;
using DataLayer.Context;
using DataLayer.Migrations;
using WebMatrix.WebData;

namespace MvcSJira
{
    //http://travis.io/blog/2015/03/24/migrate-from-aspnet-membership-to-aspnet-identity.html
    //Install-Package Microsoft.AspNet.Identity.Owin
    //Install-Package Microsoft.Owin.Host.SystemWeb
    //Install-Package structuremap -Version 2.6.4.1
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            //Install-Package structuremap -Version 2.6.4.1
            get
            {
                return (IContainer)HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }

        protected void Application_Start()
        {
            try
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<SJiraContext, Configuration>());
                AreaRegistration.RegisterAllAreas();
                WebApiConfig.Register(GlobalConfiguration.Configuration);
                FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
                RouteConfig.RegisterRoutes(RouteTable.Routes);
                BundleConfig.RegisterBundles(BundleTable.Bundles);
                AuthConfig.RegisterAuth();
                
                //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SJiraContext>());
                DependencyResolver.SetResolver(
                  new StructureMapDependencyResolver(() => Container ?? ObjectFactory.Container));

                ObjectFactory.Configure(cfg =>
                {
                    cfg.AddRegistry(new StandardRegistry());
                    cfg.AddRegistry(new ControllerRegistry());
                    cfg.AddRegistry(new ActionFilterRegistry(
                        () => Container ?? ObjectFactory.Container));
                    cfg.AddRegistry(new MvcRegistry());
                    cfg.AddRegistry(new TaskRegistry());
                    cfg.AddRegistry(new DomainRegistry());
                });
                using (var container = ObjectFactory.Container.GetNestedContainer())
                {
                    foreach (var task in container.GetAllInstances<IRunAtInit>())
                    {
                        task.Execute();
                    }

                    foreach (var task in container.GetAllInstances<IRunAtStartup>())
                    {
                        task.Execute();
                    }
                }

            }
            catch (Exception eApplication_Start)
            {

                throw eApplication_Start;
            }

        }

        public void Application_BeginRequest()
        {
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {
            try
            {
                foreach (var task in
                    Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }
    }
}