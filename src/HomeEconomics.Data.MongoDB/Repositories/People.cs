using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB.Repositories
{
    public class People : Repository<IPerson, Person>
    {
        private People(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static IRepository<IPerson> CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new People(database, builder);
        }
    }
}
