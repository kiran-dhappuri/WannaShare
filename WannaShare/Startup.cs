using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WannaShare.Startup))]
namespace WannaShare
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
