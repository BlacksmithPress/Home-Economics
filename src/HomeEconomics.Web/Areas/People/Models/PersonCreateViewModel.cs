using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types.People;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.People.Models
{
    public class PersonCreateViewModel : CreateViewModel<Person> { }
    public class PersonUpdateViewModel : UpdateViewModel<Person> { }
    public class FamilyCreateViewModel : CreateViewModel<Family> { }
    public class FamilyUpdateViewModel : UpdateViewModel<Family> { }
}
