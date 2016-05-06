using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GrocerCheckRebuild.Startup))]
namespace GrocerCheckRebuild
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
