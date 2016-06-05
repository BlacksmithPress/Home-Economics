using System;
using System.Net;
using System.Web.Mvc;
using HomeEconomics.Data;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.People.Controllers
{
    public class PeopleController : EntityController<Data.Repositories.People, Person>
    {
        public PeopleController() : base(Database.Instance.People) { }
    }
}
