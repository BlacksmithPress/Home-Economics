using System;
using HomeEconomics.Types.People;

namespace HomeEconomics.Types.Rewards
{
    public interface IAssignment : IEntity
    {
        IPerson Person { get; set; }
        IActivity Activity { get; set; }
        IReward Reward { get; set; }
        DateTime Assigned { get; set; }
    }
}