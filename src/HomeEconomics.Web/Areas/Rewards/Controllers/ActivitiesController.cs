using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class ActivitiesController : EntityController<Data.Repositories.Activities, Activity>
    {
        public ActivitiesController() : base(Database.Instance.Activities) { }
    }
}
