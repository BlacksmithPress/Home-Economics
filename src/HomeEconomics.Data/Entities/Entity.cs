using System;
using HomeEconomics.Types;

namespace HomeEconomics.Data.Entities
{
    public abstract class Entity :IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
