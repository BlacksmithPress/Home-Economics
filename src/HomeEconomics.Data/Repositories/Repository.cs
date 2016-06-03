using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Repository<EntityType> :IRepository<EntityType> where EntityType : IEntity
    {
        private IMongoCollection<EntityType> _collection;

        public Repository(IMongoCollection<EntityType> collection)
        {
            _collection = collection;
        }

        public EntityType Create(EntityType entity)
        {
            _collection.InsertOne(entity);
            var filter = Builders<EntityType>.Filter.Eq("Name", entity.Name);
            return _collection.Find(filter).FirstOrDefault();
        }

        public EntityType Retrieve(string id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public EntityType Update(EntityType entity)
        {
            if (!string.IsNullOrEmpty(entity.Id))
                Delete(entity.Id);

            return Create(entity);
        }

        public void Delete(string id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            _collection.DeleteOne(filter);
        }
    }
}
