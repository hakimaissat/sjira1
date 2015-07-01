using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using DataLayer;
using System.Linq;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using SJiraCore.Models;
using DataLayer.Context;
using DataLayer.Interfaces;
using MvcSJira.Filters;
using MvcSJira.Infrastructure.Tasks;
using MvcSJira.Infrastructure;


namespace MvcSJira.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ICurrentUser _currentUser;

        IUnitOfWork<DashboardContext> _dashboardUnitOfWork;
        private IMenuItemService _menuItemService;
        private IDashboardService _dashboardService;
        private IMenuItemRepository _menuItemRepository;
        private IDashboardRepository _dashboardRepository;
        //private IDashboardUserRepository _dashboardUserRepository;
        private IApplicationUserRepository _ApplicationUserRepository;
        ICrudRepository<SharedWith> _sharedWithRepository;
        ICrudRepository<DashboardType> _dashboardTypeRepository;

        public DashboardController(IMenuItemService menuItemService, IDashboardService dashboardService,
                                    IMenuItemRepository menuItemRepository,
                                    IDashboardRepository dashboardRepository,
            //IDashboardUserRepository dashboardUserRepository,
                                    IApplicationUserRepository ApplicationUserRepository,
                                    ICrudRepository<SharedWith> sharedWithRepository,
                                    ICrudRepository<DashboardType> dashboardTypeRepository,
              IUnitOfWork<DashboardContext> dashboardUnitOfWork, ICurrentUser currentUser)
        {
            //db = new SJiraContext();
            this._menuItemService = menuItemService;
            this._menuItemRepository = menuItemRepository;
            this._dashboardRepository = dashboardRepository;
            this._dashboardService = dashboardService;
            //this._dashboardUserRepository = dashboardUserRepository;
            this._ApplicationUserRepository = ApplicationUserRepository;
            this._sharedWithRepository = sharedWithRepository;
            this._dashboardTypeRepository = dashboardTypeRepository;
            this._dashboardUnitOfWork = dashboardUnitOfWork;
            this._currentUser = currentUser;

        }
        // GET: /Dashboard/
        public ActionResult Index(string name)
        {
            Dashboard dashboard = _dashboardRepository.Find(name);
            return View(dashboard);
        }


        // GET: /Dashboard/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = _dashboardRepository.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }

        // GET: /Dashboard/Create
        
        public ActionResult Create()
        {
            ViewBag.DashboardTypeId = new SelectList(_dashboardTypeRepository.List(), "DashboardTypeId", "Name");
            ViewBag.SharedWithId = new SelectList(_sharedWithRepository.List(), "SharedWithId", "Name");
            ViewBag.OwnerId = new SelectList(_ApplicationUserRepository.List(), "UserId", "UserName");
            ViewBag.ParentId = new SelectList(_dashboardRepository.List(), "DashboardId", "Name");
            return View();
        }

        // POST: /Dashboard/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       [HttpPost, ValidateAntiForgeryToken, Log("Created Dashboard")]
      
        public ActionResult Create([Bind(Include = "DashboardId,Name,Description,SharedWithId,OwnerId,ModifiedDate,ParentId,DashboardTypeId")] Dashboard dashboard)
        {
            if (ModelState.IsValid)
            {
                dashboard.OwnerId = _currentUser.User.Id;
                dashboard.DashboardTypeId = 2;

                if (_sharedWithRepository.GetById(dashboard.SharedWithId).Name == "Private Dashboard")
                {
                    dashboard.Dashboard_Users.Add(new DashboardUser 
                    { 
                        UserId = dashboard.OwnerId, 
                        DashboardId = dashboard.DashboardId 
                    });
                }
                if (_sharedWithRepository.GetById(dashboard.SharedWithId).Name == "Shared with all users")
                {
                    foreach (DomainClasses.Models.ApplicationUser user in _ApplicationUserRepository.AllApplicationUsers())
                    {
                        dashboard.Dashboard_Users.Add(new DashboardUser 
                        {
                            UserId = user.Id, 
                            DashboardId = dashboard.DashboardId 
                        });
                    }
                }
                dashboard.DashboardMenuItems.Add(new DashboardMenuItem
                {
                    DashboardId = dashboard.DashboardId,
                    MenuItemId = 79,
                    DisplayOrder = 10
                });
                dashboard.DashboardMenuItems.Add(new DashboardMenuItem
                {
                    DashboardId = dashboard.DashboardId,
                    MenuItemId = 80,
                    DisplayOrder = 20
                });
                dashboard.DashboardMenuItems.Add(new DashboardMenuItem
                {
                    DashboardId = dashboard.DashboardId,
                    MenuItemId = 81,
                    DisplayOrder = 30
                });

                _dashboardRepository.InsertGraph(dashboard);
                _dashboardRepository.Save();
                return RedirectToAction("Manage", new { Name = "My" });
            }

            ViewBag.DashboardTypeId = new SelectList(_dashboardTypeRepository.List(), "DashboardTypeId", "Name", dashboard.DashboardTypeId);
            ViewBag.SharedWithId = new SelectList(_sharedWithRepository.List(), "SharedWithId", "Name", dashboard.SharedWithId);
            ViewBag.OwnerId = new SelectList(_ApplicationUserRepository.List(), "UserId", "UserName", dashboard.OwnerId);
            ViewBag.ParentId = new SelectList(_dashboardRepository.List(), "DashboardId", "Name", dashboard.ParentId);
            return View(dashboard);
        }

        // GET: /Dashboard/Edit/5
          [Log("Edit Dashboard {id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = _dashboardRepository.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }

        // POST: /Dashboard/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
   
        public ActionResult Edit(Dashboard dashboard)
        {
            //[Bind(Include = "DashboardId,Name,Description,SharedWithId,OwnerId,ModifiedDate,ParentId,DashboardTypeId")] 
            if (ModelState.IsValid)
            {
                dashboard = _dashboardRepository.AllIncluding(c => c.Dashboard_Users)
                    .Where(d => d.DashboardId == dashboard.DashboardId)
                    .FirstOrDefault();
                dashboard.Dashboard_Users.Where(c => c.UserId == _currentUser.User.Id).FirstOrDefault().Favorite = true;
                _dashboardRepository.InsertOrUpdate(dashboard);
                _dashboardRepository.Save();
                return RedirectToAction("Index", new { name = dashboard.Name });

            }
            return RedirectToAction("Index");
        }

        // GET: /Dashboard/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dashboard dashboard = _dashboardRepository.Find(id);
            if (dashboard == null)
            {
                return HttpNotFound();
            }
            return View(dashboard);
        }

        // POST: /Dashboard/Delete/5
        [HttpPost, ValidateAntiForgeryToken, ActionName("Delete"), Log("Deleted dashboard {id}")]
     
        public ActionResult DeleteConfirmed(int id)
        {
            Dashboard dashboard = _dashboardRepository.Find(id);
            _dashboardRepository.Delete(id);
            _dashboardRepository.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _dashboardRepository.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        // GET: /Dashboard/
        public ActionResult Manage(string name = "Index")
        {
            DashboardModels dashboardModels = null;
            dashboardModels = _dashboardService.Manage(name);
            return View(dashboardModels);
        }


        // GET: /Dashboard/
        public ActionResult Search()
        {
            List<DashboardModel> _dashboardModels = null;
            ViewBag.IsSearchAreaVisible = true;
            ViewBag.IsGridAreaVisible = false;
            ViewBag.DashboardTypeId = new SelectList(_dashboardTypeRepository.List(), "DashboardTypeId", "Name");
            ViewBag.SharedWithId = new SelectList(_sharedWithRepository.List(), "SharedWithId", "Name");
            ViewBag.OwnerId = new SelectList(_ApplicationUserRepository.List(), "UserId", "UserName");
            //ViewBag.manage = RouteData.Values["name"];
            return View(_dashboardModels);
        }


        // Post: /Dashboard/
        [HttpPost]
        public ActionResult Search(string OwnerId, int SharedWithId = 0, string Search = null)
        {
            List<DashboardModel> _dashboardModels = null;
            ViewBag.IsSearchAreaVisible = true;
            ViewBag.IsGridAreaVisible = true;
            ViewBag.DashboardTypeId = new SelectList(_dashboardTypeRepository.List(), "DashboardTypeId", "Name");
            ViewBag.SharedWithId = new SelectList(_sharedWithRepository.List(), "SharedWithId", "Name");
            ViewBag.OwnerId = new SelectList(_ApplicationUserRepository.List(), "UserId", "UserName");

            _dashboardModels = _dashboardService.Search(OwnerId, SharedWithId, Search);
            //ViewBag.manage = "Filter";
            return View(_dashboardModels);
        }

        // GET: /Dashboard/Create
        public ActionResult Add(int id)
        {
            //Dashboard dashboard;
            //DashboardUser dashboardUser;
            //using (var repo = new DashboardRepository())
            //{
            //    dashboard = repo.AllIncluding(c => c.Dashboard_Users).SingleOrDefault();
            //}

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Dashboard dashboard;
            dashboard = _dashboardRepository.AllIncluding(c => c.Dashboard_Users).FirstOrDefault(c => c.DashboardId == id);
            //Dashboard dashboard = db.Dashboards.Find(id);

            var dashboardUser = new DashboardUser
            {
                DashboardId = id,
                UserId = _currentUser.User.Id
            };
            dashboard.Dashboard_Users.Add(dashboardUser);

            //_DashboardUserRepository.Add(id, 1); 

            _dashboardRepository.InsertOrUpdate(dashboard);

            if (dashboard == null)
            {
                return HttpNotFound();
            }
            //_DashboardUserRepository.Add(id, 1);
            //TempData["manage"] = "name";
            return RedirectToAction("Index");
        }

        public ActionResult DashboardType()
        {

            return View();
        }
        public ActionResult MainBarDashboard(int id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            Dashboard dashboard = _dashboardRepository.AllIncluding(c => c.Dashboard_Users)
                .Where(d => d.DashboardId == id)
                .FirstOrDefault();
            DashboardUser dashboardUser = dashboard.Dashboard_Users
                .Where(du => du.UserId == _currentUser.User.Id)
                .FirstOrDefault();
            if (dashboardUser == null)
            {
                return HttpNotFound();
            }

            return PartialView("_MainBar", dashboardUser);
        }
    }
}
