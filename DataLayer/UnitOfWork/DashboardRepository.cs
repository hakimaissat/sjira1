using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DataLayer;
using DomainClasses.Models;
using SJiraCore.Domain;


namespace DataLayer.Domain
{
    public class DashboardRepository : IEntityRepository<Dashboard>
    {
        DashboardContext _context;

        public DashboardRepository(DashboardUnitOfWork uow)
        {
            _context = uow.Context;
        }

        public IQueryable<Dashboard> All
        {
            get { return _context.Dashboards; }
        }

        public List<Dashboard> AllDashboards
        {
            get { return _context.Dashboards.ToList(); }
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

        public Dashboard Find(int id)
        {
            return _context.Dashboards.Find(id);
        }

        public void InsertOrUpdate(Dashboard Dashboard)
        {
            if (Dashboard.DashboardId == default(int)) // New entity
            {

                //context.Dashboards.Add(Dashboard);
                _context.Entry(Dashboard).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(Dashboard).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var Dashboard = _context.Dashboards.Find(id);
            _context.Dashboards.Remove(Dashboard);
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch ( Exception eSave)
            {

                throw eSave;
            }


        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}

        public Dashboard GetByName(string Name)
        {
            throw new NotImplementedException();
        }
    }


}