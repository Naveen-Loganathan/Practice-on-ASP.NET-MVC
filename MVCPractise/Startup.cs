using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPractise.Startup))]
namespace MVCPractise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
