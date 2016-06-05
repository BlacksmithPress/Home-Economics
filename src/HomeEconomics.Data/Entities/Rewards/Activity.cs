using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Activity : Entity, IActivity
    {
        public Types.Enumerations.UnitsOfMeasure.Activity UnitOfMeasure { get; set; }
    }
}
