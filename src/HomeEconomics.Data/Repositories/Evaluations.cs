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
    public class Evaluations : Repository<IEvaluation>
    {
        private Evaluations(IMongoCollection<IEvaluation> collection) : base(collection) { }

        public static Evaluations CreateRepository(IMongoDatabase database, string name)
        {
            return new Evaluations(database.GetCollection<IEvaluation>(name));
        }

        public static void RegisterTypes(IMongoDatabase database, ContainerBuilder builder)
        {
            var collection = database.GetCollection<IEvaluation>("Evaluations");
            builder.RegisterType<Evaluation>().As<IEvaluation>();
            builder.RegisterType<Repository<IEvaluation>>().As<IRepository<IEvaluation>>();
            builder.RegisterInstance(collection).As<IMongoCollection<IEvaluation>>();
        }
    }
}
