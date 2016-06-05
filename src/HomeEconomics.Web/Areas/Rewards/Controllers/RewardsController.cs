using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class RewardsController : EntityController<Data.Repositories.Rewards, Reward>
    {
        public RewardsController() : base(Database.Instance.Rewards) { }
    }
}
