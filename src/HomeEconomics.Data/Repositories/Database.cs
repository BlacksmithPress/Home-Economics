using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities;
using HomeEconomics.Types;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Database
    {
        internal Database(IMongoDatabase database, ContainerBuilder builder)
        {
            var people = database.GetCollection<IPerson>("People");
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<Repository<IPerson>>().As<IRepository<IPerson>>();
            builder.RegisterInstance(people).As<IMongoCollection<IPerson>>();

            var families = database.GetCollection<IFamily>("Families");
            builder.RegisterType<Family>().As<IFamily>();
            builder.RegisterType<Repository<IFamily>>().As<IRepository<IFamily>>();
            builder.RegisterInstance(families).As<IMongoCollection<IFamily>>();

            People = People.CreateRepository(database, "People");
        }

        public static Database Instance { get; internal set; }

        public Families Families { get; set; }
        public People People { get; set; }

        public void Clear()
        {
            Families?.Clear();
            People?.Clear();
        }
    }

}
