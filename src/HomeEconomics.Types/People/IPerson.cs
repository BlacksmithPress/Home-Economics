using System;
using System.Collections.Generic;
using HomeEconomics.Types.Enumerations;

namespace HomeEconomics.Types.People
{
    public interface IPerson : IEntity
    {
        string[] Names { get; set; }
        Sex Sex { get; set; }
        DateTimeOffset Birthdate { get; set; }
        IList<IFamily> Families { get; set; }
    }
}
