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
    public class Rewards : Repository<IReward, Reward>
    {
        private Rewards(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static Rewards CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Rewards(database, builder);
        }
    }
}
