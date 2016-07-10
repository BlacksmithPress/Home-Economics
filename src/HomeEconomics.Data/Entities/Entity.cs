using System;
using HomeEconomics.Types;
using Newtonsoft.Json;

namespace HomeEconomics.Data.Entities
{
    public abstract class Entity :IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
