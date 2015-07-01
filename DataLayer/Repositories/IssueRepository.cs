using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DataLayer;
using DomainClasses.Models;

using System.Data.Entity.Validation;
using System.Diagnostics;
using DataLayer.UnitOfWork;
using DataLayer.Context;
using DataLayer.Interfaces;
using SJiraCore.Interfaces;

namespace DataLayer.Repositories
{
    public class IssueRepository : IIssueRepository
    {
        IssueContext _context;
        private readonly DbSet<Issue> _dbSet;

        IUnitOfWork<IssueContext> _uow;
        public IssueRepository(IUnitOfWork<IssueContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<Issue>();
            _uow = uow;
        }
        public IQueryable<Issue> All
        {
            get { return _context.Issues; }
        }
        public List<Issue> AllIssues
        {
            get { return _context.Issues.ToList(); }
        }
        public IQueryable<Issue> AllIncluding(params Expression<Func<Issue, object>>[] includeProperties)
        {
            IQueryable<Issue> query = _context.Issues;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Issue Find(int? id)
        {
            return _context.Issues.Find(id);
        }

        public void InsertOrUpdate(Issue Issue)
        {
            if (Issue.IssueId == default(Guid)) // New entity
            {

                //context.Issues.Add(Issue);
                _context.Entry(Issue).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(Issue).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var Issue = _context.Issues.Find(id);
            _context.Issues.Remove(Issue);
        }

        public void Save()
        {
            _uow.Save();
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}


        public Issue Find(string Name)
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