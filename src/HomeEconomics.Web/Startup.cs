﻿using System.Configuration;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using HomeEconomics.Web.Areas.Rewards;
using HomeEconomics.Web.Controllers;
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

            builder.RegisterControllers(typeof(HomeController).Assembly);
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<Data.Module>();
            builder.RegisterModule<RewardsAreaModule>();
            var container = builder.Build();
            app.UseAutofacMiddleware(container);

            ConfigureAuth(app);
        }
    }
}
