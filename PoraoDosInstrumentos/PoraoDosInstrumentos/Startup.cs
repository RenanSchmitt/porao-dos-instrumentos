using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PoraoDosInstrumentos.Startup))]
namespace PoraoDosInstrumentos
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
