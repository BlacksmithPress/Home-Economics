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
    public class Rewards : Repository<IReward>
    {
        private Rewards(IMongoCollection<IReward> collection) : base(collection) { }

        public static Rewards CreateRepository(IMongoDatabase database, string name)
        {
            return new Rewards(database.GetCollection<IReward>(name));
        }

        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var collection = database.GetCollection<IReward>("Rewards");
            builder.RegisterType<Reward>().As<IReward>();
            builder.RegisterType<Repository<IReward>>().As<IRepository<IReward>>();
            builder.RegisterInstance(collection).As<IMongoCollection<IReward>>();
        }
    }
}
