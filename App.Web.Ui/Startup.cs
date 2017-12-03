using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(App.Web.Ui.Startup))]
namespace App.Web.Ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
