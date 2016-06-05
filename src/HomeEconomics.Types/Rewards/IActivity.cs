using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEconomics.Types.Rewards
{
    public interface IActivity : IEntity
    {
        Enumerations.UnitsOfMeasure.Activity UnitOfMeasure { get; set; }
    }
}
