using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Types
{
    public interface IEntity
    {
        Guid Id { get; set; }
        string Name { get; set; }
    }
}
