﻿using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards.Controllers
{
    public class AssignmentsController : EntityController<Data.Repositories.Assignments, Assignment>
    {
        public AssignmentsController() : base(Database.Instance.Assignments) { }
    }
}
