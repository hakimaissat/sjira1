using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using DomainClasses.Models;

namespace ConsoleSJira.Models
{ 
    public class ProjectRepository : IProjectRepository
    {
        ConsoleSJiraContext context = new ConsoleSJiraContext();

        public IQueryable<Project> All
        {
            get { return context.Projects; }
        }

        public IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties)
        {
            IQueryable<Project> query = context.Projects;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Project Find(int id)
        {
            return context.Projects.Find(id);
        }

        public void InsertOrUpdate(Project project)
        {
            if (project.ProjectId == default(int)) {
                // New entity
                context.Projects.Add(project);
            } else {
                // Existing entity
                context.Entry(project).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var project = context.Projects.Find(id);
            context.Projects.Remove(project);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IProjectRepository : IDisposable
    {
        IQueryable<Project> All { get; }
        IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties);
        Project Find(int id);
        void InsertOrUpdate(Project project);
        void Delete(int id);
        void Save();
    }
}