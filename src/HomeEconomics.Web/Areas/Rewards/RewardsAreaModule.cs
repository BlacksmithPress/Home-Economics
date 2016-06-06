using Autofac;
using Autofac.Integration.Mvc;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Controllers;
using HomeEconomics.Web.Models;

namespace HomeEconomics.Web.Areas.Rewards
{
    public class RewardsAreaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssignmentCreateViewModel>().As<CreateViewModel<Assignment>>();
            builder.RegisterType<AssignmentUpdateViewModel>().As<UpdateViewModel<Assignment>>();
        }
    }
}