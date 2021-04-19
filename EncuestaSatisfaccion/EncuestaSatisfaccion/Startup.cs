using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EncuestaSatisfaccion.Startup))]
namespace EncuestaSatisfaccion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
