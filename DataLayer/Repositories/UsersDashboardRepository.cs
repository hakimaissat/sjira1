using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SJiraCore.Interfaces;
using SJiraCore.Models;
using DomainClasses.Models;
using System.Data;
using DataLayer.UnitOfWork;
using DataLayer.Context;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class DashboardUserRepository : IDashboardUserRepository
    {
        // DashboardContext _context;

        //public DashboardUserRepository()
        //{
        //    var uow = new DashboardUnitOfWork();
        //    _context = uow.Context;
        //}
        //public DashboardUserRepository(DashboardUnitOfWork uow)
        //{
        //    _context = uow.Context;
        //}

        DashboardContext _context;
        private readonly DbSet<DashboardUser> _dbSet;
        //public DashboardUserRepository()
        //{
        //    var uow = new DashboardUnitOfWork();
        //    _context = uow.Context;
        //    this._dbSet = _context.Set<DashboardUser>();
        //}
        IUnitOfWork<DashboardContext> _uow;
        public DashboardUserRepository(IUnitOfWork<DashboardContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<DashboardUser>();
            _uow = uow;
        }
        //public DashboardUserRepository(DashboardContext context)
        //{
        //    this._context = context;
        //    this._dbSet = context.Set<DashboardUser>();
        //}

        void IDashboardUserRepository.Add(int dashboardId, string userId)
        {
            _context.DashboardUsers.Add(new DashboardUser { UserId = userId, DashboardId = dashboardId });
        }

        public IQueryable<DashboardUser> All
        {
            get { return _context.DashboardUsers; }
        }

        public IQueryable<DashboardUser> AllIncluding(params System.Linq.Expressions.Expression<Func<DashboardUser, object>>[] includeProperties)
        {
            IQueryable<DashboardUser> query = _context.DashboardUsers;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public DashboardUser Find(int? id)
        {
            return _context.DashboardUsers.Find(id);
        }

        public void InsertOrUpdate(DashboardUser dashboardUsers)
        {
            if (dashboardUsers.DashboardUserId == default(int)) // New entity
            {
                _context.DashboardUsers.Add(dashboardUsers);
                //context.Entry(customer).State = EntityState.Added;
            }
            else        // Existing entity
            {
                _context.DashboardUsers.Add(dashboardUsers);
                _context.Entry(dashboardUsers).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _uow.Save();
        }

        public DashboardUser Find(string Name)
        {
            throw new NotImplementedException();
        }


        public void InsertGraph(DashboardUser entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DashboardUser> List()
        {
            return _dbSet.ToList();
        }
    }
}
