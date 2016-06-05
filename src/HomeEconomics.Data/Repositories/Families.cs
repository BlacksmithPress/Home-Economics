using System;
using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Families : Repository<IFamily>
    {
        private Families(IMongoCollection<IFamily> collection) : base(collection) { }

        public static Families CreateRepository(IMongoDatabase database, string name)
        {
            return new Families(database.GetCollection<IFamily>(name));
        }

        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var families = database.GetCollection<IFamily>("Families");
            builder.RegisterType<Family>().As<IFamily>();
            builder.RegisterType<Repository<IFamily>>().As<IRepository<IFamily>>();
            builder.RegisterInstance(families).As<IMongoCollection<IFamily>>();
        }
    }
}