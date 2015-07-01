using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer.Context;
using DataLayer.Interfaces;
using DomainClasses.Models;
using MvcSJira.Infrastructure;
using MvcSJira.Models;
using SJiraCore.Interfaces;

namespace MvcSJira.Controllers
{
    public class MenuItemController : Controller
    {
        private readonly ICurrentUser _currentUser;
        IUnitOfWork<MenuItemContext> _menuItemUnitOfWork;
        private IMenuItemRepository _menuItemRepository;
        private IMenuItemService _menuItemService;
        ICrudRepository<MenuItemType> _menuItemTypeRepository;
        public MenuItemController(IMenuItemService menuItemService,
                                    IMenuItemRepository menuItemRepository,
                                    ICrudRepository<MenuItemType> menuItemTypeRepository,
            IUnitOfWork<MenuItemContext> menuItemUnitOfWork, ICurrentUser currentUser)
        {
            //db = new MenuItemContext();
            this._menuItemService = menuItemService;
            this._menuItemRepository = menuItemRepository;
            this._menuItemTypeRepository = menuItemTypeRepository; 
            this._menuItemUnitOfWork=menuItemUnitOfWork;
            this._currentUser = currentUser;
        }

        // GET: /MenuItem/
        public ActionResult Index()
        {
            var menuitems = _menuItemRepository.AllIncluding(m => m.MenuItemType);
            return View(menuitems.ToList());
        }

        // GET: /MenuItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = _menuItemRepository.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        // GET: /MenuItem/Create
        public ActionResult Create()
        {
            ViewBag.MenuItemTypeId = new SelectList(_menuItemTypeRepository.List(), "MenuItemTypeId", "Name");
            return View();
        }

        // POST: /MenuItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MenuItemId,ParentId,Title,DisplayOrder,MenuAction,MenuIcon,MenuIconAfter,MenuItemTypeId")] MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                _menuItemRepository.InsertGraph(menuitem);
                _menuItemRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemTypeId = new SelectList(_menuItemTypeRepository.List(), "MenuItemTypeId", "Name", menuitem.MenuItemTypeId);
            return View(menuitem);
        }

        // GET: /MenuItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = _menuItemRepository.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            ViewBag.MenuItemTypeId = new SelectList(_menuItemTypeRepository.List(), "MenuItemTypeId", "Name", menuitem.MenuItemTypeId);
            return View(menuitem);
        }

        // POST: /MenuItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MenuItemId,ParentId,Title,DisplayOrder,MenuAction,MenuIcon,MenuIconAfter,MenuItemTypeId")] MenuItem menuitem)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(menuitem).State = EntityState.Modified;
                //db.SaveChanges();
                _menuItemRepository.InsertOrUpdate(menuitem);
                _menuItemRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.MenuItemTypeId = new SelectList(_menuItemTypeRepository.List(), "MenuItemTypeId", "Name", menuitem.MenuItemTypeId);
            return View(menuitem);
        }

        // GET: /MenuItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuItem menuitem = _menuItemRepository.Find(id);
            if (menuitem == null)
            {
                return HttpNotFound();
            }
            return View(menuitem);
        }

        // POST: /MenuItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _menuItemRepository.Delete(id);
            _menuItemRepository.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        //_menuItemRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            List<MenuItem> MainMenuItems = _menuItemService.MainList("Main");
            return PartialView("_MainMenu", MainMenuItems);
        }
        public ActionResult SideBarDashboard()
        {
            List<MenuItem> SideBarMenuItems = _menuItemService.SideBarList("Dashboards");
            return PartialView("_SideBar", SideBarMenuItems);
        }
        public ActionResult SideBarManage()
        {
            List<MenuItem> SideBarMenuItems = _menuItemService.SideBarList("Manage Dashboards");
            return PartialView("_SideBar", SideBarMenuItems);
        }
        
    }
}
