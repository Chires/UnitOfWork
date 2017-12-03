using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LYH.UnitOfWork.Site.Web.Startup))]
namespace LYH.UnitOfWork.Site.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
