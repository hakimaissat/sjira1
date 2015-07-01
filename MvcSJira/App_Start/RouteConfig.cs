using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcSJira
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // /Project
            
            //routes.MapRoute("Project",
            //    "project/{name}",
            //    new { controller = "Project", action = "Search", name = UrlParameter.Optional });

            //routes.MapRoute("Dashboard",
            //    "Dashboard/{name}",
            //    new { controller = "Dashboard", action = "Search", name = UrlParameter.Optional });

            //routes.MapRoute("Dashboards",
            //    "Dashboards/{menuAction}",
            //    new { controller = "Home", action = "Dashboards", menuAction = UrlParameter.Optional });

            routes.MapRoute("Manage",
                "Manage/{name}",
                new { controller = "Dashboard", action = "Manage", name = UrlParameter.Optional });


            routes.MapRoute("Dashboards",
                "Dashboards/{name}",
                new { controller = "Dashboard", action = "Index", name = UrlParameter.Optional });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{name}",
                defaults: new { controller = "Dashboard", action = "Index", name  = UrlParameter.Optional }
            );
        }
    }
}