using System;
using System.Collections.Generic;
using HomeEconomics.Types;
using NodaTime;

namespace HomeEconomics.Data.Entities
{
    public class Family : Entity, IFamily
    {
        private readonly List<IPerson> _members = new List<IPerson>();
        public DateTimeOffset Birthdate { get; set; }
        public IEnumerable<IPerson> Members => _members;
    }
}