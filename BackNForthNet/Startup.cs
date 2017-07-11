using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BackNForthNet.Startup))]
namespace BackNForthNet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
