using System;
using HomeEconomics.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace HomeEconomics.Data.Entities
{
    public abstract class Entity :IEntity
    {
        [BsonId(IdGenerator = typeof(GuidGenerator))]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
