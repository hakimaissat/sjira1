using System;
using System.Linq;
using SJiraCore.Models;

namespace SJiraCore.Interfaces
{
    
    public interface IProjectRepository : IDisposable
    {
        IQueryable<SJiraCore.Models.Project1> GetProjects();
        IQueryable<Project> All { get; }
        IQueryable<Project> AllIncluding(params Expression<Func<Project, object>>[] includeProperties);
        Project Find(int id);
        void InsertOrUpdate(Project project);
        void Delete(int id);
        void Save();
    }
}
