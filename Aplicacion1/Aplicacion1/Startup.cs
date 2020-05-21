using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Aplicacion1.Startup))]
namespace Aplicacion1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
