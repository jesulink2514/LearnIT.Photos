using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LearnIT.Startup))]
namespace LearnIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
