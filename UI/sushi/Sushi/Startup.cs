using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sushi.Startup))]
namespace Sushi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
