using System.Collections.Generic;
using System.Web.Mvc;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.Rewards.Models
{
    public class EvaluationUpdateViewModel : UpdateViewModel<Evaluation>
    {
        public IEnumerable<SelectListItem> Activities { get; set; }
        public IEnumerable<SelectListItem> People { get; set; }
        public IEnumerable<SelectListItem> Rewards { get; set; }
    }
}