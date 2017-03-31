using Microsoft.Owin;

[assembly: OwinStartup(typeof(CarShop.WebApp.Startup))]

namespace CarShop.WebApp
{
    using Owin;

    /// <summary>
    /// The startup.
    /// </summary>
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}