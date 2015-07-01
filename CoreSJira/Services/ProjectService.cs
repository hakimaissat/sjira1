using System;
using System.Linq;
using SJiraCore.Interfaces;
using SJiraCore.Models;

namespace SJiraCore.Services
{
    public class ProjectService
    {
        private readonly IEntityRepository<Project> _ProjectRepository;

        public ProjectService(IEntityRepository<Project> ProjectRepository)
        {
            _ProjectRepository= ProjectRepository;
        }
        public IQueryable<Project> GetProjectsModel()
        {
            try
            {
                return _ProjectRepository.All;
            }
            catch (Exception eGetProjectsModel)
            {

                throw eGetProjectsModel;
            }
            
        }
    }
}
