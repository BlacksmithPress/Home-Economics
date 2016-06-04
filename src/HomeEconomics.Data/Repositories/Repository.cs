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
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            _collection.InsertOne(entity);
            return entity;
        }

        public EntityType Retrieve(string id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<EntityType> RetrieveAll()
        {
            return _collection.AsQueryable();
        }

        public EntityType Update(EntityType entity)
        {
            if (entity.Id != Guid.Empty)
                Delete(entity.Id.ToString());

            return Create(entity);
        }

        public void Delete(string id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            _collection.DeleteOne(filter);
        }

        public void Clear()
        {
            _collection.Database.DropCollection(_collection.CollectionNamespace.CollectionName);
        }
    }
}
