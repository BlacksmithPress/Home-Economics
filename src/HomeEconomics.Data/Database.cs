using Autofac;
using HomeEconomics.Data.Repositories;
using MongoDB.Driver;

namespace HomeEconomics.Data
{
    public class Database
    {
        internal Database(IMongoDatabase database, ContainerBuilder builder)
        {
            People.RegisterTypes(database, builder);
            Families.RegisterTypes(database, builder);
            Activities.RegisterTypes(database, builder);
            Assignments.RegisterTypes(database, builder);
            Evaluations.RegisterTypes(database, builder);
            Rewards.RegisterTypes(database, builder);

            People = People.CreateRepository(database, "People");
            Families = Families.CreateRepository(database, "Families");
            Activities = Activities.CreateRepository(database, "Activities");
            Assignments = Assignments.CreateRepository(database, "Assignments");
            Evaluations = Evaluations.CreateRepository(database, "Evaluations");
            Rewards = Rewards.CreateRepository(database, "Rewards");
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
