using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DomainClasses.Models;
using MvcSJira.Infrastructure.Mapping;

namespace MvcSJira.Models
{
    public class ProjectModel : IHaveCustomMappings
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        //public string Description { get; set; }
        public string Category { get; set; }
        public string Lead { get; set; }
        //public int? OriginalIstimate { get; set; }


        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectModel>()
                .ForMember(m => m.Lead, opt =>
                    opt.MapFrom(u => u.ApplicationUser.UserName))
                .ForMember(m => m.Name, opt =>
                    opt.MapFrom(u => u.Name))
                .ForMember(m => m.Code, opt =>
                    opt.MapFrom(u => u.Code))
                .ForMember(m => m.Category, opt =>
                    opt.MapFrom(u => u.ProjectCategory.Name));
        }
    }
}