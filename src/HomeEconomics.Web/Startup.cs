using System.Configuration;
using Autofac;
using Microsoft.Owin;
using MongoDB.Driver;
using Owin;

[assembly: OwinStartup(typeof(HomeEconomics.Web.Startup))]

namespace HomeEconomics.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var mongo = new MongoClient(ConfigurationManager.ConnectionStrings["home-economics"].ConnectionString);
            var builder = new ContainerBuilder();
            builder.RegisterModule<Data.Module>();
            var container = builder.Build();
            app.UseAutofacMiddleware(container);

            ConfigureAuth(app);
        }
    }
}
