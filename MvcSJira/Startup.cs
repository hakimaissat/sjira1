using Microsoft.Owin;
using Owin;
using MvcSJira;

[assembly: OwinStartupAttribute(typeof(MvcSJira.Startup))]

namespace MvcSJira
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}