using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodaTime;

namespace HomeEconomics.Types
{
    public interface IFamily : IEntity
    {
        DateTimeOffset Birthdate { get; set; }
        IList<IPerson> Members { get; set; }
    }
}
