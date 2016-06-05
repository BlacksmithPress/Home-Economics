using System;
using System.Collections.Generic;

namespace HomeEconomics.Types.People
{
    public interface IFamily : IEntity
    {
        DateTimeOffset Birthdate { get; set; }
        IList<IPerson> Members { get; set; }
    }
}
