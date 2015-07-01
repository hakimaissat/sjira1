using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Linq.Expressions;
using SJiraCore.Interfaces;
using SJiraCore.Models;
using DomainClasses.Models;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using DataLayer.UnitOfWork;
using DataLayer.Context;
using DataLayer.Interfaces;
namespace DataLayer.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        DashboardContext _context;
        private readonly DbSet<Dashboard> _dbSet;
        private readonly ICurrentUser _currentUser;
        //public DashboardRepository()
        //{
        //    var uow = new DashboardUnitOfWork();
        //    _context = uow.Context;
        //    this._dbSet = _context.Set<Dashboard>();
        //}
        IUnitOfWork<DashboardContext> _uow;
        public DashboardRepository(IUnitOfWork<DashboardContext> uow, ICurrentUser currentUser)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<Dashboard>();
            _uow = uow;
            this._currentUser = currentUser;
        }
        //public DashboardRepository(DashboardContext context)
        //{
        //    this._context = context;
        //    this._dbSet = context.Set<Dashboard>();
        //}
        List<DashboardModel> IDashboardRepository.GetFavoritesDashboards()
        {
            return (from d in _context.Dashboards
                    join ud in _context.DashboardUsers on d.DashboardId equals ud.DashboardId
                    join up in _context.Users on ud.UserId equals up.Id

                    where up.UserName == _currentUser.User.UserName && ud.Favorite == true
                    select new
                    {
                        DashboardId = d.DashboardId,
                        Owner = d.ApplicationUser.UserName,
                        Name = d.Name,
                        Favorite = ud.Favorite,
                        SharedWith = d.SharedWith.Name
                    }).AsEnumerable().Select(x => new DashboardModel
                    {
                        DashboardId = x.DashboardId,
                        Owner = x.Owner,
                        Name = x.Name,
                        Favorite = x.Favorite,
                        SharedWith = x.SharedWith

                    }).ToList();


        }
        List<DashboardModel> IDashboardRepository.GetMyDashboards()
        {
            var MyDashboards = _context.Dashboards.Include(d => d.DashboardType).Include(d => d.SharedWith)
                                           .Where(p => p.ApplicationUser.UserName == _currentUser.User.UserName)
                                           .Select(d => new DashboardModel
                                           {
                                               DashboardId = d.DashboardId,
                                               Owner = d.ApplicationUser.UserName,
                                               Name = d.Name,
                                               Favorite = d.Favorite,
                                               SharedWith = d.SharedWith.Name
                                           }).ToList();

            return MyDashboards;
        }
        List<DashboardModel> IDashboardRepository.GetPopularDashboards()
        {
            return (from d in _context.Dashboards
                    from ud in _context.DashboardUsers.Where(ud => ud.DashboardId == d.DashboardId).DefaultIfEmpty()

                    join up in _context.Users on d.OwnerId equals up.Id

                    join sw in _context.SharedWiths on d.SharedWithId equals sw.SharedWithId
                    //where sw.Name == "Shared with all users"

                    group d by new
                    {
                        d.DashboardId,
                        up.UserName,
                        DashboardName = d.Name,
                        SharedWithName = sw.Name

                    } into g

                    select new DashboardModel()
                    {
                        DashboardId = g.Key.DashboardId,
                        Owner = g.Key.UserName,
                        Name = g.Key.DashboardName,
                        SharedWith = g.Key.SharedWithName,
                        Popularity = g.Where(p => p.Dashboard_Users.Any()).Count(),
                        Favorite = _context.DashboardUsers.Where(du => du.DashboardId == g.Key.DashboardId).Select(du => du.Favorite).FirstOrDefault(),
                    })
                    .ToList();
        }
        List<DashboardModel> IDashboardRepository.GetSearchDashboards(string ownerId, int sharedWithId, string search)
        {

            return (from d in _context.Dashboards
                    from ud in _context.DashboardUsers.Where(ud => ud.DashboardId == d.DashboardId).DefaultIfEmpty()
                    join up in _context.Users on d.OwnerId equals up.Id
                    join up1 in _context.Users on ud.UserId equals up1.Id
                    join sw in _context.SharedWiths on d.SharedWithId equals sw.SharedWithId
                    where up1.UserName == _currentUser.User.UserName

                    && (ownerId == null  || d.OwnerId == ownerId)
                    && (sharedWithId == 0 || d.SharedWithId == sharedWithId)
                    && (search == null || d.Name == search)
                    group d by new
                    {
                        d.DashboardId,
                        up.UserName,
                        DashboardName = d.Name,
                        SharedWithName = sw.Name
                    } into g

                    select new DashboardModel()
                    {
                        DashboardId = g.Key.DashboardId,
                        Owner = g.Key.UserName,
                        Name = g.Key.DashboardName,
                        SharedWith = g.Key.SharedWithName,
                        Popularity = g.Where(p => p.Dashboard_Users.Any()).Count(),
                        Favorite = _context.DashboardUsers.Where(du => du.DashboardId == g.Key.DashboardId).Select(du => du.Favorite).FirstOrDefault(),
                    })
                   .ToList();

          
        }


        public IQueryable<Dashboard> All
        {
            get { return _context.Dashboards; }
        }
        public IQueryable<Dashboard> AllIncluding(params Expression<Func<Dashboard, object>>[] includeProperties)
        {
            IQueryable<Dashboard> query = _context.Dashboards;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }
        public Dashboard Find(int? id)
        {
            //var mgr1 = _context.Dashboards
            //    .Include(p => p.DashboardType).Include(p => p.Dashboard_Gadgets.Select(g => g.Gadget))
            //    .Include(p => p.DashboardType)
            // .Where(p => p.DashboardId == id).FirstOrDefault();
            //return mgr1;

            var dashboard = _context.Dashboards
              .Include(p => p.Dashboard_Gadgets.Select(g => g.Gadget))
              .Include(p => p.DashboardMenuItems.Select(g => g.MenuItem))
              .Include(p => p.DashboardType)
           .Where(p => p.DashboardId == id)
           .FirstOrDefault();
            return dashboard;

        }
        public Dashboard Find(string name)
        {
            try
            {
                Dashboard dashboard = null;
                if (name == null || name == "")
                {
                    dashboard = _context.Dashboards
                        //.Join(_context.DashboardUsers, d => d.DashboardId, ud => ud.DashboardId,
                        //(d, ud) => new { d, ud })
                        //.Where(p => p.ud.Favorite == true && p.ud.UserId==1)

               .Include(p => p.Dashboard_Users.Select(g => g.ApplicationUser))
               .Include(p => p.Dashboard_Gadgets.Select(g => g.Gadget))
               .Include(p => p.DashboardMenuItems.Select(g => g.MenuItem))
               .Include(p => p.DashboardType)
                      .Where(p => p.Dashboard_Users.Select(ud => ud.Favorite == true && ud.UserId == _currentUser.User.Id).FirstOrDefault())
               .FirstOrDefault();
                }
                else
                {
                    dashboard = _context.Dashboards
                        //.Join(_context.DashboardUsers, d => d.DashboardId, ud => ud.DashboardId,
                        //(d, ud) => new { d, ud })
                        //.Where(p => p.ud.Favorite == true)
                   .Include(p => p.Dashboard_Users.Select(g => g.ApplicationUser))
                   .Include(p => p.Dashboard_Gadgets.Select(g => g.Gadget))
                   .Include(p => p.DashboardMenuItems.Select(g => g.MenuItem))
                   .Include(p => p.DashboardType).Where(p => p.Name == name || name == "")
                   .FirstOrDefault();
                }
                return dashboard;
            }
            catch (Exception eFind)
            {

                //throw eFind;
                return null;
            }

        }
        public void InsertGraph(Dashboard entity)
        {
            _context.Dashboards.Add(entity);
        }
        public void InsertOrUpdate(Dashboard entity)
        {
            if (entity.DashboardId == default(int)) // New entity
            {

                //context.Dashboards.Add(Dashboard);
                _context.Entry(entity).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
        }
        public void Delete(int id)
        {
            var Dashboard = _context.Dashboards.Find(id);
            _context.Dashboards.Remove(Dashboard);
        }
        //public void Dispose()
        //{
        //    _context.Dispose();
        //}
        public void Save()
        {
            _uow.Save();
        }


        public IEnumerable<Dashboard> List()
        {
            return _dbSet.ToList();
        }
    }
}
