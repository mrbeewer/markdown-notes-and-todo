using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MarkdownManager.Startup))]
namespace MarkdownManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
