using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Assignments : Repository<IAssignment>
    {
        private Assignments(IMongoCollection<IAssignment> collection) : base(collection) { }

        public static Assignments CreateRepository(IMongoDatabase database, string name)
        {
            return new Assignments(database.GetCollection<IAssignment>(name));
        }

        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var collection = database.GetCollection<IAssignment>("Assignments");
            builder.RegisterType<Assignment>().As<IAssignment>();
            builder.RegisterType<Repository<IAssignment>>().As<IRepository<IAssignment>>();
            builder.RegisterInstance(collection).As<IMongoCollection<IAssignment>>();
        }
    }
}
