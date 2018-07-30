using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetCoursework.Startup))]
namespace NetCoursework
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
