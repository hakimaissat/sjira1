using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DataLayer;
using DataLayer.UnitOfWork;
using DomainClasses.Models;
using SJiraCore.Interfaces;
using DataLayer.Context;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class WorkRepository : IWorkRepository
    {
        WorkContext _context;
         private readonly DbSet<DashboardUser> _dbSet;
         IUnitOfWork<WorkContext> _uow;
        public WorkRepository(IUnitOfWork<WorkContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<DashboardUser>();
            _uow = uow;
        }
        public IQueryable<Work> All
        {
            get { return _context.Works; }
        }
        public List<Work> AllWorks
        {
            get { return _context.Works.ToList(); }
        }
        public IQueryable<Work> AllIncluding(params Expression<Func<Work, object>>[] includeProperties)
        {
            IQueryable<Work> query = _context.Works;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Work Find(int? id)
        {
            return _context.Works.Find(id);
        }

        public void InsertOrUpdate(Work Work)
        {
            if (Work.WorkId == default(Guid)) // New entity
            {

                //context.Works.Add(Work);
                _context.Entry(Work).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(Work).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var Work = _context.Works.Find(id);
            _context.Works.Remove(Work);
        }

        public void Save()
        {
            _uow.Save();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public Work Find(string Name)
        {
            throw new NotImplementedException();
        }


        public void InsertGraph(Work entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Work> List()
        {
            throw new NotImplementedException();
        }
    }


}