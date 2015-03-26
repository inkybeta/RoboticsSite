using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RoboticsWebsite.Startup))]
namespace RoboticsWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
