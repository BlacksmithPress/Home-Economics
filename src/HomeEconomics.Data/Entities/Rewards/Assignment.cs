using System;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Assignment : Entity, IAssignment
    {
        public IPerson Person { get; set; }
        public IActivity Activity { get; set; }
        public IReward Reward { get; set; }
        public DateTime Assigned { get; set; }
    }
}
