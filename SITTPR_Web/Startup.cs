using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SITTPR_Web.Startup))]
namespace SITTPR_Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
