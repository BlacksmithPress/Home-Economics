using System;
using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Families : Repository<IFamily, Family>
    {
        private Families(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static Families CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Families(database, builder);
        }
    }
}