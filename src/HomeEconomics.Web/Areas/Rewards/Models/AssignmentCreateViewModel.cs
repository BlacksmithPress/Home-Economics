using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using HomeEconomics.Data.Entities.Rewards;

namespace HomeEconomics.Web.Areas.Rewards.Models
{
    public class AssignmentCreateViewModel
    {
        public Assignment Assignment { get; set; }
        public IEnumerable<SelectListItem> Activities { get; set; }
        public IEnumerable<SelectListItem> People { get; set; }
        public IEnumerable<SelectListItem> Rewards { get; set; }
    }
}
