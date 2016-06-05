using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Activities : Repository<IActivity>
    {
        private Activities(IMongoCollection<IActivity> collection) : base(collection) { }

        public static Activities CreateRepository(IMongoDatabase database, string name)
        {
            return new Activities(database.GetCollection<IActivity>(name));
        }

        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var collection = database.GetCollection<IActivity>("Activities");
            builder.RegisterType<Activity>().As<IActivity>();
            builder.RegisterType<Repository<IActivity>>().As<IRepository<IActivity>>();
            builder.RegisterInstance(collection).As<IMongoCollection<IActivity>>();
        }
    }
}
