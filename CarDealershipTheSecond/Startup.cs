using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CarDealershipTheSecond.Startup))]
namespace CarDealershipTheSecond
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
