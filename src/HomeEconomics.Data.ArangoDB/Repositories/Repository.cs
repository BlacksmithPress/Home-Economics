using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Arango.Client;
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
        private Dictionary<string, InterfaceType> _collection = new Dictionary<string, InterfaceType>();

        public Repository(ADatabase database, ContainerBuilder builder, string name = null)
        {
            if (string.IsNullOrEmpty(name))
                name = DetermineCollectionName(typeof(InterfaceType));

            _database = database;
            var result = _database.Collection.Get(name);
            if (result.Success)
            {
                _collection.Clear();
                foreach (var key in result.Value.Keys)
                {
                    try
                    {
                        var value = (InterfaceType) result.Value[key];
                        _collection.Add(key, value);
                    }
                    catch
                    {
                        ;
                    }
                }
            }

            builder.RegisterType<EntityType>().As<InterfaceType>();
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
            if (entity.Id == Guid.Empty)
                entity.Id = Guid.NewGuid();

            _collection.Add(entity.Id.ToString(), entity);
            return entity;
        }

        public InterfaceType Retrieve(Guid id)
        {
            return _collection[id.ToString()];
        }

        public InterfaceType Update(InterfaceType entity)
        {
            if (entity.Id != Guid.Empty)
                Delete(entity.Id);

            return Create(entity);
        }

        public void Delete(Guid id)
        {
            if (_collection.ContainsKey(id.ToString()))
                _collection.Remove(id.ToString());
        }

        public void Clear()
        {
            _collection.Clear();
        }
    }
}
