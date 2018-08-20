using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LIMSReporterWeb.Startup))]
namespace LIMSReporterWeb
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
