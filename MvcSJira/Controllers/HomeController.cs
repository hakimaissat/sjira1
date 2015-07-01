using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainClasses.Models;
using MvcSJira.Models;
using DataLayer;
using SJiraCore.Services;
using SJiraCore.Interfaces;
using DataLayer.Context;
using MvcSJira.Infrastructure.Tasks;
using MvcSJira.Infrastructure;


//Get-Scaffolder
//Get-DefaultScaffolder
//set-defaultscaffolder repository linqtosqlscaffolding.Repository
//set-defaultscaffolder repository T4Scaffolding.EFRepository
//Install-Package StructureMap
namespace MvcSJira.Controllers
{
    //[Authorize(Roles="administrators,sales")]
    public class HomeController : Controller
    {
        private readonly ICurrentUser _currentUser;

        //private SJiraContext db;
        //private IMenuItemService _menuItemService;
        //private IMenuItemRepository _menuItemRepository;

        //public HomeController(IMenuItemService menuItemService, IMenuItemRepository menuItemRepository)
        //{
        //    db = new SJiraContext();
        //    this._menuItemService = menuItemService;
        //    this._menuItemRepository = menuItemRepository;
        //}
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }
        
        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "Aissat";
            model.Location = "Montreal";
            return View(model);
        }
       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}
