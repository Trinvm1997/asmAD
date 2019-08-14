using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(asmAD.Startup))]
namespace asmAD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
