using Arango.Client;
using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;

namespace HomeEconomics.Data.ArangoDB.Repositories
{
    public class People : Repository<IPerson, Person>
    {
        private People(ADatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IPerson> CreateRepository(ADatabase database, ContainerBuilder builder)
        {
            return new People(database, builder);
        }
    }
}
