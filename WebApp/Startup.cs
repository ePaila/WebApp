using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApp.Startup))]
namespace WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder App)
        {
            Configuration(App);
        }
    }
}