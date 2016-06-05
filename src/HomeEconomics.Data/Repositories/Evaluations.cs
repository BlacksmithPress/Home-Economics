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
    public class Evaluations : Repository<IEvaluation, Evaluation>
    {
        private Evaluations(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static Evaluations CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Evaluations(database, builder);
        }
    }
}
