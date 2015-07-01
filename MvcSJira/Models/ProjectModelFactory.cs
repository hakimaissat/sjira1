using DomainClasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcSJira.Models
{
    public class ProjectModelFactory
    {
        public ProjectModel Create(Project project)
        {
            return new ProjectModel()
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                Code = project.Code,
                Lead = project.ApplicationUser.UserName,
                Category = project.ProjectCategory.Name

            };
        }
    }
}