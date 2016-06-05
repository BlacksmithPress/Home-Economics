using System;
using HomeEconomics.Types.People;

namespace HomeEconomics.Types.Rewards
{
    public interface IEvaluation : IEntity
    {
        IAssignment Assignment { get; set; }
        IPerson Evaluator { get; set; }
        DateTime Evaluated { get; set; }
        string Comments { get; set; }
        IReward Reward { get; set; }
    }
}