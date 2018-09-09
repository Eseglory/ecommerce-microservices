using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RESAERCHMENTOR.NET_V2.Startup))]
namespace RESAERCHMENTOR.NET_V2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
