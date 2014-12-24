using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(nmct.ba.CashlessProject.api.Startup))]
namespace nmct.ba.CashlessProject.api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
