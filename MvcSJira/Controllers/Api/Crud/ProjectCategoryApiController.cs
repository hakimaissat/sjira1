using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer;
using DomainClasses.Models;
using SJiraCore.Interfaces;
namespace MvcSJira.Controllers.Api.Crud
{
    public class ProjectCategoryApiController : ApiController
    {
        //SJiraContext db = ;
        ICrudRepository<ProjectCategory> _projectCategoryRepository; //= new Repository<Project>(new SJiraContext());

        public ProjectCategoryApiController(ICrudRepository<ProjectCategory> projectCategoryRepository)
        {
            try
            {
                _projectCategoryRepository = projectCategoryRepository;
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
            // GET api/values
            public IEnumerable<ProjectCategory> Get()
            {
                var  projectCategories=_projectCategoryRepository.List().OrderBy(P => P.Name).Take(10).ToList();
                return projectCategories;
            }
            // GET api/values/5
            public ProjectCategory Get(string Name)
            {
                var projectCategory = _projectCategoryRepository.GetByName(Name);
                if (projectCategory == null)
                {
                    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
                }
                return projectCategory;
            }
            // POST api/values
            public void Post([FromBody]
                         ProjectCategory projectCategory)
            {
                _projectCategoryRepository.Insert(projectCategory);
            }

            // PUT api/values/5
            public void Put(string Name, [FromBody]
                        ProjectCategory projectCategory)
            {
                var projectToUpdate = _projectCategoryRepository.GetByName(Name);
                projectToUpdate.Name = projectCategory.Name;
                projectToUpdate.Description = projectCategory.Description;
              
                _projectCategoryRepository.Update(projectToUpdate);
            }

            // DELETE api/values/5
            public void Delete(int id)
            {
                _projectCategoryRepository.Delete(id);
            }
    }
}
