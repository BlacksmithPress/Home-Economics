using System;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data.Entities.Rewards
{
    public class Evaluation : Entity, IEvaluation
    {
        public IAssignment Assignment { get; set; }
        public IPerson Evaluator { get; set; }
        public DateTime Evaluated { get; set; }
        public string Comments { get; set; }
        public IReward Reward { get; set; }
    }
}
