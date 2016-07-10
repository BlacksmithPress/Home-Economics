using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Arango.Client;
using Arango.fastJSON;
using Autofac;
using HomeEconomics.Types;
using Inflector;

namespace HomeEconomics.Data.ArangoDB.Repositories
{
    public class Repository<InterfaceType, EntityType> : IRepository<InterfaceType> 
        where EntityType : InterfaceType
        where InterfaceType : IEntity
    {
        private ADatabase _database;
        private string _collection;

        public Repository(ADatabase database, ContainerBuilder builder, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                _collection = DetermineCollectionName(typeof(InterfaceType));

            _database = database;

            if (HasCollection(_database, _collection))
            {
                var result = _database.Collection.Load(_collection);
                if (!result.Success)
                    throw new InvalidDataException($"Unable to load the {_collection} collection into memory.");
            }
            else
            {
                var result = _database.Collection.Create(_collection);
                if (!result.Success)
                    throw new InvalidDataException($"Unable to create the {_collection} collection.");
            }

            builder.RegisterType<EntityType>().As<InterfaceType>();
        }

        private bool HasCollection(ADatabase database, string name)
        {
            var result = database
                .ExcludeSystem(true)
                .GetAllCollections();

            if (result.Success && result.HasValue)
            {
                foreach (var collection in result.Value)
                {
                    var thisName = collection.String("name");
                    if (string.Compare(thisName, name, StringComparison.CurrentCultureIgnoreCase) == 0)
                        return true;
                }
            }
            return false;
        }

        private static string DetermineCollectionName(Type type)
        {
            var name = type.Name;
            if (name.StartsWith("I") && name.Length > 1)
            {
                var second = name[1];
                if (char.IsUpper(second))
                    name = name.Substring(1);
            }
            return name.Pluralize();
        }

        public IEnumerable<InterfaceType> Documents { get { return (IEnumerable<InterfaceType>) _collection.AsQueryable().ToList(); } }

        public InterfaceType Create(InterfaceType entity)
        {
            var json = JSON.ToJSON(entity);

            var result = _database.Document
                .WaitForSync(true)
                .Create(_collection, json);

            if (!result.Success)
                throw new InvalidDataException($"Exception occurred while attempting to create entity \"{entity.Id}: {entity.Name}\" in {_collection} collection.");

            entity.Id = result.Value.String("_id");    
            return entity;
        }

        public InterfaceType Retrieve(string id)
        {
            var result = _database.Document.Get<EntityType>(id);
            if (result.Success && result.HasValue)
            {
                return result.Value;
            }
            else
                return default(InterfaceType);
        }

        public InterfaceType Update(InterfaceType entity)
        {
            Delete(entity.Id);

            return Create(entity);
        }

        public void Delete(string id)
        {
            var result = _database.Document.Delete(id);
        }

        public void Clear()
        {
            var result = _database.Collection.Truncate(_collection);
        }
    }
}
