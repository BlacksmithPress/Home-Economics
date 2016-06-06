using Autofac;
using Autofac.Integration.Mvc;
using HomeEconomics.Data.Entities.Rewards;
using HomeEconomics.Web.Areas.Rewards.Models;
using HomeEconomics.Web.Controllers;

namespace HomeEconomics.Web.Areas.Rewards
{
    public class RewardsAreaModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AssignmentCreateViewModel>().As<ICreateViewModel<Assignment>>();
        }
    }
}