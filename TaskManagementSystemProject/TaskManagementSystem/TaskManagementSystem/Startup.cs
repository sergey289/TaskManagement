using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TaskManagementSystem.Startup))]

// Files related to ASP.NET Identity duplicate the Microsoft ASP.NET Identity file structure and contain initial Microsoft comments.

namespace TaskManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}