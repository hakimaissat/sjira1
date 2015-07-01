using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using SJiraCore.Interfaces;
using SJiraCore.Models;
using DomainClasses.Models;
using DataLayer.UnitOfWork;
using DataLayer.Context;
using System.Data;
using DataLayer.Interfaces;
namespace DataLayer.Repositories
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly MenuItemContext _context;
        private readonly DbSet<MenuItem> _dbSet;
        private readonly ICurrentUser _currentUser;

        //public MenuItemRepository()
        //{
        //    var uow = new MenuItemUnitOfWork();
        //    _context = uow.Context;
        //    this._dbSet = _context.Set<MenuItem>();
        //}
        IUnitOfWork<MenuItemContext> _uow;
        public MenuItemRepository(IUnitOfWork<MenuItemContext> uow, ICurrentUser currentUser)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<MenuItem>();
            _uow = uow;
            this._currentUser = currentUser;
        }
        //public MenuItemRepository(MenuItemContext context)
        //{
        //    this._context = context;
        //    this._dbSet = context.Set<MenuItem>();
        //}

        public List<MenuItem> GetMainMenuItems(string menuIem)
        {
            List<MenuItem> menuItems2 = GetMenuItemsofDashboards();
            foreach (var item in menuItems2)
            {
                _context.MenuItems.Add(item);
            }
            var menuItems1 = _context.MenuItems.OrderBy(p => p.DisplayOrder)
                .Include(p => p.Child).Include(p => p.Parent)
             .Where(p => p.Parent.Title == menuIem)//.Union(mgr2)

             .ToList();
            return menuItems1;
        }
        public List<MenuItem> GetMenuItems(string menuIem)
        {
            var menuItems = _context.MenuItems.OrderBy(p => p.DisplayOrder)
                .Include(p => p.Child).Include(p => p.Parent)
             .Where(p => p.Parent.Title == menuIem)//.Union(mgr2)
             .ToList();
            return menuItems;
        }
        public List<MenuItem> GetMenuItemsofDashboards()
        {
            return (from d in _context.Dashboards
                    join ud in _context.DashboardUsers on d.DashboardId equals ud.DashboardId
                    join up in _context.Users on ud.UserId equals up.Id
                    where up.UserName == _currentUser.User.UserName && ud.Favorite == true
                    select new
                    {
                        ParentId = _context.MenuItems.Where(p => p.Title == "Dashboards").FirstOrDefault().MenuItemId,
                        Title = d.Name,
                        DisplayOrder = 10 + d.DashboardId,
                        MenuAction = "/Dashboards/" + d.Name,
                        MenuItemTypeId = _context.MenuItemTypes.Where(p => p.Name == "Link").FirstOrDefault().MenuItemTypeId,
                    }).AsEnumerable().Select(x => new MenuItem
                    {
                        ParentId = x.ParentId,
                        Title = x.Title,
                        DisplayOrder = x.DisplayOrder,
                        MenuAction = x.MenuAction,
                        MenuItemTypeId = x.MenuItemTypeId,
                    }).ToList();
        }
        public List<MenuItem> GetMenuItemsofIssues()
        {
            throw new NotImplementedException();
        }
        public List<MenuItem> GetMenuItemsofProjects()
        {
            throw new NotImplementedException();
        }
        public List<MenuItem> GetMenuItemsofAgile()
        {
            throw new NotImplementedException();
        }

        public IQueryable<MenuItem> All
        {
            get { return _context.MenuItems; }
        }
        public IQueryable<MenuItem> AllIncluding(params System.Linq.Expressions.Expression<Func<MenuItem, object>>[] includeProperties)
        {
            IQueryable<MenuItem> query = _context.MenuItems;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public MenuItem Find(int? id)
        {
            var menuItem = _context.MenuItems
           .Where(p => p.MenuItemId == id)
           .FirstOrDefault();
            return menuItem;
        }
        public MenuItem Find(string name)
        {
            var menuItem = _context.MenuItems
           .Where(p => p.Title == name)
           .FirstOrDefault();
            return menuItem;
        }
        public void InsertGraph(MenuItem entity)
        {
            _context.MenuItems.Add(entity);
        }
        public void InsertOrUpdate(MenuItem entity)
        {
            if (entity.MenuItemId == default(int)) // New entity
            {
                _context.Entry(entity).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var MenuItem = _context.MenuItems.Find(id);
            _context.MenuItems.Remove(MenuItem);
        }
        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
        public void Save()
        {
            _uow.Save();
        }

        public IEnumerable<MenuItem> List()
        {
            return _dbSet.ToList();
        }
    }
}
