using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.People;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
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
