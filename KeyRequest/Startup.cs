using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KeyRequest.Startup))]
namespace KeyRequest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
