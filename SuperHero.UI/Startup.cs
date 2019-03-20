using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuperHero.UI.Startup))]
namespace SuperHero.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
