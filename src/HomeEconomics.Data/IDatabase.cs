using HomeEconomics.Types;
using HomeEconomics.Types.People;
using HomeEconomics.Types.Rewards;

namespace HomeEconomics.Data
{
    public interface IDatabase
    {
        IRepository<IFamily> Families { get; set; }
        IRepository<IPerson> People { get; set; }
        IRepository<IAssignment> Assignments { get; set; }
        IRepository<IActivity> Activities { get; set; }
        IRepository<IEvaluation> Evaluations { get; set; }
        IRepository<IReward> Rewards { get; set; }
        void Clear();
    }
}