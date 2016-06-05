using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class People : Repository<IPerson, Person>
    {
        private People(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static People CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new People(database, builder);
        }
    }
}
