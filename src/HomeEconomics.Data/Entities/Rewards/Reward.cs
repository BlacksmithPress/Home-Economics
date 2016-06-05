using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Reward :Entity, IReward
    {
        public decimal Quantity { get; set; }
        public Types.Enumerations.UnitsOfMeasure.Reward UnitOfMeasure { get; set; }
    }
}
