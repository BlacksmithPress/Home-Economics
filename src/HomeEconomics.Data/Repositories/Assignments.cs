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
    public class Assignments : Repository<IAssignment, Assignment>
    {
        private Assignments(IMongoDatabase database, ContainerBuilder builder) : base(database, builder) { }

        public static Assignments CreateRepository(IMongoDatabase database, ContainerBuilder builder)
        {
            return new Assignments(database, builder);
        }
    }
}
