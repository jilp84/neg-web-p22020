using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(P_Market.Startup))]
namespace P_Market
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
