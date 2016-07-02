using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Activity : Entity, IActivity
    {
        public Types.Enumerations.UnitsOfMeasure.Activity UnitOfMeasure { get; set; }
    }
}
