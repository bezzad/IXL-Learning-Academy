using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IXL.Startup))]
namespace IXL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
