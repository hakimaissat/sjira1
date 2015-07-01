using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap.Configuration.DSL;

namespace MvcSJira.Infrastructure
{
    public class ControllerRegistry : Registry
    {
        public ControllerRegistry()
        {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.With(new ControllerConvention());
            });
        }
    }
}