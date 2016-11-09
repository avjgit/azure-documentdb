using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lunch.Startup))]
namespace lunch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
