using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Data.MongoDB.Repositories;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB
{
    public class Database : IDatabase
    {
        internal Database(IMongoDatabase database, ContainerBuilder builder)
        {
            People = Repositories.People.CreateRepository(database, builder);
            Families = Repositories.Families.CreateRepository(database, builder);
            Activities = Repositories.Activities.CreateRepository(database, builder);
            Assignments = Repositories.Assignments.CreateRepository(database, builder);
            Evaluations = Repositories.Evaluations.CreateRepository(database, builder);
            Rewards = Repositories.Rewards.CreateRepository(database, builder);
        }

        public static Database Instance { get; internal set; }

        public IRepository<IFamily> Families { get; set; }
        public IRepository<IPerson> People { get; set; }
        public IRepository<IAssignment> Assignments { get; set; }
        public IRepository<IActivity> Activities { get; set; }
        public IRepository<IEvaluation> Evaluations { get; set; }
        public IRepository<IReward> Rewards { get; set; }

        public void Clear()
        {
            Families?.Clear();
            People?.Clear();
            Activities?.Clear();
            Assignments?.Clear();
            Evaluations?.Clear();
            Rewards?.Clear();
        }
    }

}
