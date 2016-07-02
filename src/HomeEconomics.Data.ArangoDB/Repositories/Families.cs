using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;

namespace HomeEconomics.Data.ArangoDB.Repositories
{
    public class Families : Repository<IFamily, Family>
    {
        private Families(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IFamily> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Families(database, builder);
        }
    }
}