namespace HomeEconomics.Types.Rewards
{
    public interface IReward : IEntity
    {
        decimal Quantity { get; set; }
        Enumerations.UnitsOfMeasure.Reward UnitOfMeasure { get; set; }
    }
}