using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
//using AutoMapper;

namespace MvcSJira.Infrastructure.Mapping
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}