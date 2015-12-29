using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ePaila.com.Startup))]
namespace ePaila.com
{
    public class Startup
    {
        public void Configuration(IAppBuilder App)
        {
            Configuration(App);
        }
    }
}