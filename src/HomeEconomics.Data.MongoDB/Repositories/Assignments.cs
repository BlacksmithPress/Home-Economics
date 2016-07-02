using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB.Repositories
{
    public class Assignments : Repository<IAssignment, Assignment>
    {
        private Assignments(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IAssignment> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Assignments(database, builder);
        }
    }
}
