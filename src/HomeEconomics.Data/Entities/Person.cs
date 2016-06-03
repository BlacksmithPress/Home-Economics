using System;
using System.Collections.Generic;
using HomeEconomics.Types;
using HomeEconomics.Types.Enumerations;
using NodaTime;

namespace HomeEconomics.Data.Entities
{
    public class Person : Entity, IPerson
    {
        private readonly List<IFamily> _families = new List<IFamily>();
        public string[] Names { get; set; }
        public Sex Sex { get; set; }
        public DateTimeOffset Birthdate { get; set; }
        public IEnumerable<IFamily> Families => _families;
    }
}
