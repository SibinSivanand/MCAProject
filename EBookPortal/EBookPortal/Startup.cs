using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EBookPortal.Startup))]
namespace EBookPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
