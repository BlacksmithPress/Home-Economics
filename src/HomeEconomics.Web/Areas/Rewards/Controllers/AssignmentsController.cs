using System.Linq;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class AssignmentsController : EntityController<Data.Repositories.Assignments, Assignment>
    {
        public AssignmentsController() : base(Database.Instance.Assignments) { }

        public override ActionResult Create()
        {
            var model = new AssignmentCreateViewModel
            {
                Assignment = new Assignment(),
                Activities = Database.Instance.Activities.Documents.Select<Activity, SelectListItem>(a => a.ToSelectListItem()),
                People = Database.Instance.People.Documents.Select<Person, SelectListItem>(a => a.ToSelectListItem()),
                Rewards = Database.Instance.Rewards.Documents.Select<Reward, SelectListItem>(a => a.ToSelectListItem()),
            };
            return View(model);
        }
    }
}
