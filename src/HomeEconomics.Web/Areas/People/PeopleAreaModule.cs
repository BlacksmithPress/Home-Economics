using Autofac;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Types.People;
using HomeEconomics.Web.Areas.People.Models;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.People
{
    public class PeopleAreaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonCreateViewModel>().As<CreateViewModel<Person>>();
            builder.RegisterType<PersonCreateViewModel>().As<UpdateViewModel<Person>>();
            builder.RegisterType<FamilyCreateViewModel>().As<CreateViewModel<Family>>();
            builder.RegisterType<FamilyCreateViewModel>().As<UpdateViewModel<Family>>();
        }
    }
}