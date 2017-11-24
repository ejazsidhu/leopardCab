using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LepardCab.Startup))]
namespace LepardCab
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
