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
    public class ProjectRepository : IProjectRepository
    {
        ProjectContext _context;
        private readonly DbSet<Project> _dbSet;
        IUnitOfWork<ProjectContext> _uow;
        public ProjectRepository(IUnitOfWork<ProjectContext> uow)
        {
            _context = uow.Context;
            this._dbSet = _context.Set<Project>();
            _uow = uow;
        }
        public IQueryable<Project> All
        {
            get { return _context.Projects; }
        }
        public List<Project> AllProjects
        {
            get { return _context.Projects.ToList(); }
        }
        public IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties)
        {
            IQueryable<Project> query = _context.Projects;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Project Find(int? id)
        {
            return _context.Projects.Find(id);
        }

        public void InsertOrUpdate(Project project)
        {
            if (project.ProjectId == default(int)) // New entity
            {

                //context.Projects.Add(project);
                _context.Entry(project).State = EntityState.Added;
            }
            else // Existing entity
            {
                _context.Entry(project).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var project = _context.Projects.Find(id);
            _context.Projects.Remove(project);
        }

        public void Save()
        {
            _uow.Save();
        }

        //public void Dispose()
        //{
        //    _context.Dispose();
        //}


        public Project Find(string Name)
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