using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Types;
using HomeEconomics.Types.Enumerations;

namespace HomeEconomics.Tests.Resources
{
    public static class Sample
    {
        public static class Family
        {
            public static Data.Entities.Family LeFebvre { get; } = new Data.Entities.Family
            {
                Id = Guid.NewGuid(),
                Name = "LeFebvre",
                Birthdate = DateTimeOffset.Parse("1996-11-30T15:00:00.000-05:00"),
                Members = new IPerson[] { Person.Ken, Sample.Person.Wendee, Sample.Person.Ethan, Sample.Person.Joshua, Sample.Person.Sophie, Sample.Person.Ellie },
            };
        }

        public static class Person
        {
            public static Data.Entities.Person Ken { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Ken LeFebvre",
                Names = new string[] { "Ken", "Leon", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("1966-10-03T00:00:00.000-05:00"),
                Sex = Sex.Male,
            };
            public static Data.Entities.Person Wendee { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Wendee LeFebvre",
                Names = new string[] { "Wendee", "Denise", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("1975-10-21T00:00:00.000-05:00"),
                Sex = Sex.Female,
            };
            public static Data.Entities.Person Ethan { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Ethan LeFebvre",
                Names = new string[] { "Ethan", "Andrew", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("2000-07-22T00:00:00.000-05:00"),
                Sex = Sex.Male,
            };
            public static Data.Entities.Person Joshua { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Joshua LeFebvre",
                Names = new string[] { "Joshua", "Nathan", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("2003-03-29T00:00:00.000-05:00"),
                Sex = Sex.Male,
            };
            public static Data.Entities.Person Sophie { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Sophie LeFebvre",
                Names = new string[] { "Sophie", "Hannah", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("2010-10-27T00:00:00.000-05:00"),
                Sex = Sex.Female,
            };
            public static Data.Entities.Person Ellie { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Ellie LeFebvre",
                Names = new string[] { "Ellie", "Gwen", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("2012-12-05T00:00:00.000-05:00"),
                Sex = Sex.Female,
            };
            public static Data.Entities.Person Lowell { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Lowell LeFebvre",
                Names = new string[] { "Lowell", "Leon", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("1936-07-02T00:00:00.000-05:00"),
                Sex = Sex.Male,
            };
            public static Data.Entities.Person Nancy { get; } = new Data.Entities.Person
            {
                Id = Guid.NewGuid(),
                Name = "Nancy LeFebvre",
                Names = new string[] { "Nancy", "Carolyn", "LeFebvre" },
                Birthdate = DateTimeOffset.Parse("1942-07-19T00:00:00.000-05:00"),
                Sex = Sex.Female,
            };
        }
    }
}
