using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types.Enumerations;
using NodaTime;

namespace HomeEconomics.Types
{
    public interface IPerson : IEntity
    {
        string[] Names { get; set; }
        Sex Sex { get; set; }
        DateTimeOffset Birthdate { get; set; }
        IList<IFamily> Families { get; set; }
    }
}
