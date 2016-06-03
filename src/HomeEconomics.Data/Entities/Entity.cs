using HomeEconomics.Types;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HomeEconomics.Data.Entities
{
    public abstract class Entity :IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
