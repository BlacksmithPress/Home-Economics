using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Types
{
    public interface IEntity
    {
        string Id { get; set; }
        string Name { get; set; }
    }
}
