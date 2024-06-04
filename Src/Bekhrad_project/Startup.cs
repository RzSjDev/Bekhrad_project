using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bekhrad_project.Startup))]
namespace Bekhrad_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
