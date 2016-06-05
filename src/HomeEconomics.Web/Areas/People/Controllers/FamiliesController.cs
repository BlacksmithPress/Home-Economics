using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;

namespace HomeEconomics.Web.Areas.People.Controllers
{
    public class FamiliesController : EntityController<Data.Repositories.Families, Family>
    {
        public FamiliesController() : base(Database.Instance.Families) { }
    }
}
