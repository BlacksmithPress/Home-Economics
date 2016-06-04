using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class People : Repository<IPerson>
    {
        private People(IMongoCollection<IPerson> collection) : base(collection) { }

        public static People CreateRepository(IMongoDatabase database, string name)
        {
            return new People(database.GetCollection<IPerson>(name));
        }
    }

    public class Families : Repository<IFamily>
    {
        private Families(IMongoCollection<IFamily> collection) : base(collection) { }

        public static Families CreateRepository(IMongoDatabase database, string name)
        {
            return new Families(database.GetCollection<IFamily>(name));
        }
    }
}
