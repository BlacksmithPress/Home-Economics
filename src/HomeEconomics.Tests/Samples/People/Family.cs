using System;
using HomeEconomics.Types.People;

namespace HomeEconomics.Tests.Samples.People
{
    public static class Family
    {
        public static Data.Entities.People.Family LeFebvre { get; } = new Data.Entities.People.Family
        {
            Name = "LeFebvre",
            Birthdate = DateTimeOffset.Parse("1996-11-30T15:00:00.000-05:00"),
            Members = new IPerson[] { Person.Ken, Person.Wendee, Person.Ethan, Person.Joshua, Person.Sophie, Person.Ellie },
        };
    }
}