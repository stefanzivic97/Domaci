using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gamerent.Startup))]
namespace Gamerent
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
