using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Types;
using Inflector;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace HomeEconomics.Data.Repositories
{
    public class Repository<InterfaceType, EntityType> : IRepository<EntityType> 
        where EntityType : InterfaceType
        where InterfaceType : IEntity
    {
        private IMongoCollection<EntityType> _collection;

        public Repository(IMongoDatabase database, ContainerBuilder builder, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = DetermineCollectionName(typeof(EntityType));

            _collection = database.GetCollection<EntityType>(name);
            builder.RegisterType<EntityType>().As<InterfaceType>();
            builder.RegisterInstance(_collection).As<IMongoCollection<EntityType>>();
        }

        private static string DetermineCollectionName(Type type)
        {
            return type.Name.Pluralize();
        }

        public IQueryable<EntityType> Documents { get { return _collection.AsQueryable(); } }

        public EntityType Create(EntityType entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            _collection.InsertOne(entity);
            return entity;
        }

        public EntityType Retrieve(Guid id)
        {
            var filter = Builders<EntityType>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public EntityType Update(EntityType entity)
        {
            if (entity.Id != Guid.Empty)
                Delete(entity.Id);

            return Create(entity);
        }

        public void Delete(Guid id)
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
