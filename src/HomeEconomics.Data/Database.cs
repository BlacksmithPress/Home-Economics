using Autofac;
using HomeEconomics.Data.Repositories;
using MongoDB.Driver;

namespace HomeEconomics.Data
{
    public interface IDatabase
    {
        Families Families { get; set; }
        People People { get; set; }
        Assignments Assignments { get; set; }
        Activities Activities { get; set; }
        Evaluations Evaluations { get; set; }
        Rewards Rewards { get; set; }
        void Clear();
    }

    public class Database : IDatabase
    {
        internal Database(IMongoDatabase database, ContainerBuilder builder)
        {
            People = People.CreateRepository(database, builder);
            Families = Families.CreateRepository(database, builder);
            Activities = Activities.CreateRepository(database, builder);
            Assignments = Assignments.CreateRepository(database, builder);
            Evaluations = Evaluations.CreateRepository(database, builder);
            Rewards = Rewards.CreateRepository(database, builder);
        }

        public static Database Instance { get; internal set; }

        public Families Families { get; set; }
        public People People { get; set; }
        public Assignments Assignments { get; set; }
        public Activities Activities { get; set; }
        public Evaluations Evaluations { get; set; }
        public Rewards Rewards { get; set; }

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
