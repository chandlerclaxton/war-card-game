using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(warCardGame.Startup))]
namespace warCardGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
