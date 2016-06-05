using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class People : Repository<IPerson>
    {
        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var people = database.GetCollection<IPerson>("People");
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<Repository<IPerson>>().As<IRepository<IPerson>>();
            builder.RegisterInstance(people).As<IMongoCollection<IPerson>>();
        }

        private People(IMongoCollection<IPerson> collection) : base(collection) { }

        public static People CreateRepository(IMongoDatabase database, string name)
        {
            return new People(database.GetCollection<IPerson>(name));
        }
    }
}
