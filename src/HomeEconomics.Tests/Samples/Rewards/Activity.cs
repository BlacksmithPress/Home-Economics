using System;
using HomeEconomics.Types.People;

namespace HomeEconomics.Tests.Samples.Rewards
{
    public static class Activity
    {
        public static Data.Entities.Rewards.Activity Mowing { get; } = new Data.Entities.Rewards.Activity
        {
            Name = "Mowing the lawn",
            UnitOfMeasure = Types.Enumerations.UnitsOfMeasure.Activity.Week
        };

        public static Data.Entities.Rewards.Activity MakingIce { get; } = new Data.Entities.Rewards.Activity
        {
            Name = "Make ice",
            UnitOfMeasure = Types.Enumerations.UnitsOfMeasure.Activity.Day
        };
    }

    public static class Reward
    {
        public static Data.Entities.Rewards.Reward TwentyDollars { get; } = new Data.Entities.Rewards.Reward
        {
            Name = "$20.00",
            Quantity = 20M,
            UnitOfMeasure = Types.Enumerations.UnitsOfMeasure.Reward.Dollar,
        };

        public static Data.Entities.Rewards.Reward TwentyFiveCents { get; } = new Data.Entities.Rewards.Reward
        {
            Name = "25¢",
            Quantity = 0.25M,
            UnitOfMeasure = Types.Enumerations.UnitsOfMeasure.Reward.Dollar,
        };
    }

    public static class Assignment
    {
        public static Data.Entities.Rewards.Assignment EthanMowing { get; } = new Data.Entities.Rewards.Assignment
        {
            Name = "Ethan mowing the lawn",
            Person = Samples.People.Person.Ethan,
            Activity = Samples.Rewards.Activity.Mowing,
            Assigned = DateTime.UtcNow,
            Reward = Samples.Rewards.Reward.TwentyDollars,
        };

        public static Data.Entities.Rewards.Assignment JoshuaMakingIce { get; } = new Data.Entities.Rewards.Assignment
        {
            Name = "Joshua making ice",
            Person = Samples.People.Person.Joshua,
            Activity = Samples.Rewards.Activity.MakingIce,
            Assigned = DateTime.UtcNow,
            Reward = Samples.Rewards.Reward.TwentyFiveCents,
        };
    }
}