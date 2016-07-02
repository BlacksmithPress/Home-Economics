using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using HomeEconomics.Types;
using Inflector;
using MongoDB.Driver;

namespace HomeEconomics.Data.MongoDB.Repositories
{
    public class Repository<InterfaceType, EntityType> : IRepository<InterfaceType> 
        where EntityType : InterfaceType
        where InterfaceType : IEntity
    {
        private IMongoCollection<InterfaceType> _collection;

        public Repository(IMongoDatabase database, ContainerBuilder builder, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = DetermineCollectionName(typeof(InterfaceType));

            _collection = database.GetCollection<InterfaceType>(name);
            builder.RegisterType<EntityType>().As<InterfaceType>();
            builder.RegisterInstance(_collection).As<IMongoCollection<InterfaceType>>();
        }

        private static string DetermineCollectionName(Type type)
        {
            return type.Name.Pluralize();
        }

        public IEnumerable<InterfaceType> Documents { get { return (IEnumerable<InterfaceType>) _collection.AsQueryable().ToList(); } }

        public InterfaceType Create(InterfaceType entity)
        {
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            _collection.InsertOne(entity);
            return entity;
        }

        public InterfaceType Retrieve(Guid id)
        {
            var filter = Builders<InterfaceType>.Filter.Eq("Id", id);
            return _collection.Find(filter).FirstOrDefault();
        }

        public InterfaceType Update(InterfaceType entity)
        {
            if (entity.Id != Guid.Empty)
                Delete(entity.Id);

            return Create(entity);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<InterfaceType>.Filter.Eq("Id", id);
            _collection.DeleteOne(filter);
        }

        public void Clear()
        {
            _collection.Database.DropCollection(_collection.CollectionNamespace.CollectionName);
        }
    }
}
