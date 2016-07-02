using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.ArangoDB.Repositories
{
    public class Activities : Repository<IActivity, Activity>
    {
        private Activities(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IActivity> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Activities(database, builder);
        }
    }
}
