using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class EvaluationsController : EntityController<Data.Repositories.Evaluations, Evaluation>
    {
        public EvaluationsController() : base(Database.Instance.Evaluations) { }
    }
}
