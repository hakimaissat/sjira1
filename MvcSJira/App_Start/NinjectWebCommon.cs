[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MvcSJira.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MvcSJira.App_Start.NinjectWebCommon), "Stop")]

namespace MvcSJira.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using DataLayer;
    using System.Web.Http;
    using WebApiContrib.IoC.Ninject;
    using SJiraCore.Interfaces;
    using SJiraCore.Services;
    using DataLayer.Context;
    using DataLayer.Repositories;
    using DataLayer.UnitOfWork;
    using DataLayer.Interfaces;

    //Get-Scaffolder
    //Get-DefaultScaffolder
    //set-defaultscaffolder repository linqtosqlscaffolding.Repository
    //set-defaultscaffolder repository T4Scaffolding.EFRepository
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                // Support WebAPI
                GlobalConfiguration.Configuration.DependencyResolver =
                  new NinjectResolver(kernel);

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(ICrudRepository<>)).To(typeof(CrudRepository<>));
            kernel.Bind(typeof(IUnitOfWork<UserProfileContext>)).To(typeof(UserProfileUnitOfWork));
            kernel.Bind(typeof(IUnitOfWork<MenuItemContext>)).To(typeof(MenuItemUnitOfWork));
            kernel.Bind(typeof(IUnitOfWork<DashboardContext>)).To(typeof(DashboardUnitOfWork));    

            //kernel.Bind<MenuItemUnitOfWork>().To<MenuItemUnitOfWork>();
            kernel.Bind<SJiraContext>().To<SJiraContext>();
            kernel.Bind<IMenuItemService>().To<MenuItemService>();
            kernel.Bind<IDashboardService>().To<DashboardService>();
            kernel.Bind<IMenuItemRepository>().To<MenuItemRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>)); ;
            kernel.Bind<IDashboardRepository>().To<DashboardRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>));
            kernel.Bind<IDashboardUserRepository>().To<DashboardUserRepository>().WithConstructorArgument(typeof(IUnitOfWork<DashboardContext>)); ;
            kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>().WithConstructorArgument(typeof(IUnitOfWork<UserProfileContext>)); ;   
        }        
    }
}
