using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BA_Portal.Startup))]
namespace BA_Portal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
