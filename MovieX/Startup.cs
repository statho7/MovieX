using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovieX.Startup))]
namespace MovieX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
