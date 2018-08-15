using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RESAERCHMENTOR.NET.Startup))]
namespace RESAERCHMENTOR.NET
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
