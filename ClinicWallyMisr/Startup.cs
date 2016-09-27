using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClinicWallyMisr.Startup))]
namespace ClinicWallyMisr
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
