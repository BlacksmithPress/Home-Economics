using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Reward :Entity, IReward
    {
        public decimal Quantity { get; set; }
        public Types.Enumerations.UnitsOfMeasure.Reward UnitOfMeasure { get; set; }
    }
}
