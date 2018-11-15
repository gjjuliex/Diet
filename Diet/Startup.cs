using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Diet.Startup))]
namespace Diet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
