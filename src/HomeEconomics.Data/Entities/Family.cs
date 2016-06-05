using System;
using System.Collections.Generic;
using HomeEconomics.Types;
using NodaTime;

namespace HomeEconomics.Data.Entities
{
    public class Family : Entity, IFamily
    {
        public DateTimeOffset Birthdate { get; set; }
        public IList<IPerson> Members { get; set; } = new List<IPerson>();
    }
}