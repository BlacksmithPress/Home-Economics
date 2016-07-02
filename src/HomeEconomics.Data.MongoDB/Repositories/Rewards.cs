using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB.Repositories
{
    public class Rewards : Repository<IReward, Reward>
    {
        private Rewards(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IReward> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Rewards(database, builder);
        }
    }
}
