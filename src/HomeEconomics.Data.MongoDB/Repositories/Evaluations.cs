using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB.Repositories
{
    public class Evaluations : Repository<IEvaluation, Evaluation>
    {
        private Evaluations(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IEvaluation> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Evaluations(database, builder);
        }
    }
}
