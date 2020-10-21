using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PersonalSiteV2.UI.MVC.Startup))]
namespace PersonalSiteV2.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
