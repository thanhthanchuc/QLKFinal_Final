using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLKFinal.Startup))]
namespace QLKFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
