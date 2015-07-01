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
    public class SprintRepository : ISprintRepository
    {
        SprintContext _context;
         private readonly DbSet<Sprint> _dbSet;
         IUnitOfWork<SprintContext> _uow;
        public SprintRepository(IUnitOfWork<SprintContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<Sprint>();
            _uow = uow;
        }
        public IQueryable<Sprint> All
        {
            get { return _context.Sprints; }
        }
        public List<Sprint> AllSprints
        {
            get { return _context.Sprints.ToList(); }
        }
        public IQueryable<Sprint> AllIncluding(params Expression<Func<Sprint, object>>[] includeProperties)
        {
            IQueryable<Sprint> query = _context.Sprints;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Sprint Find(int? id)
        {
            return _context.Sprints.Find(id);
        }

        public void InsertOrUpdate(Sprint Sprint)
        {
            if (Sprint.SprintId == default(int)) // New entity
            {

                //context.Sprints.Add(Sprint);
                _context.Entry(Sprint).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(Sprint).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var Sprint = _context.Sprints.Find(id);
            _context.Sprints.Remove(Sprint);
        }

        public void Save()
        {
            _uow.Save();
        }
        public void Dispose()
        {
            _context.Dispose();
        }


        public Sprint Find(string Name)
        {
            throw new NotImplementedException();
        }

        public Sprint GetSprintForDate(int companyId, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void Update(Sprint sprint)
        {
            throw new NotImplementedException();
        }

        IQueryable<Project> IEntityRepository<Project>.All
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties)
        {
            throw new NotImplementedException();
        }

        Project IEntityRepository<Project>.Find(int? id)
        {
            throw new NotImplementedException();
        }

        Project IEntityRepository<Project>.Find(string Name)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Project entity)
        {
            throw new NotImplementedException();
        }


        public void InsertGraph(Project entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> List()
        {
            throw new NotImplementedException();
        }
    }


}