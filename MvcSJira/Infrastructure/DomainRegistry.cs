using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using StructureMap.Configuration.DSL;
    using SJiraCore.Interfaces;
    using SJiraCore.Services;
    using DataLayer.Context;
    using DataLayer.Repositories;
    using DataLayer.UnitOfWork;
    using DataLayer.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using DomainClasses.Models;
using DataLayer.Service;

namespace MvcSJira.Infrastructure
{
    public class DomainRegistry : Registry
    {
        public DomainRegistry()
        {
           

            For(typeof(ICrudRepository<>)).Use(typeof(CrudRepository<>));
            For(typeof(IUnitOfWork<ApplicationUserContext>)).Use(typeof(ApplicationUserUnitOfWork));
            For(typeof(IUnitOfWork<MenuItemContext>)).Use(typeof(MenuItemUnitOfWork));
            For(typeof(IUnitOfWork<DashboardContext>)).Use(typeof(DashboardUnitOfWork));

            //kernel.Bind<MenuItemUnitOfWork>().Use<MenuItemUnitOfWork>();
            //For(typeof(IdentityDbContext<ApplicationUser>)).Use(typeof(SJiraContext));
            For<IMenuItemService>().Use<MenuItemService>();
            For<IDashboardService>().Use<DashboardService>();
            For<IMenuItemRepository>().Use<MenuItemRepository>() ;
            For<IDashboardRepository>().Use<DashboardRepository>();
            For<IDashboardUserRepository>().Use<DashboardUserRepository>() ;
            For<IApplicationUserRepository>().Use<ApplicationUserRepository>() ;
            For<ICurrentUser>().Use<CurrentUser>();   
        }
    }
}

          //For<IMenuItemRepository>().Use<MenuItemRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>)); ;
          //  For<IDashboardRepository>().Use<DashboardRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>));
          //  For<IDashboardUserRepository>().Use<DashboardUserRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>)); ;
          //  For<IApplicationUserRepository>().Use<ApplicationUserRepository>().WithConstructorArgument(typeof(IUnitOfWork<ApplicationUserContext>)); ;        