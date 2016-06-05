using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Data.Repositories;
using HomeEconomics.Types;
using HomeEconomics.Types.Enumerations;
using MongoDB.Driver;
using NodaTime;
using NUnit.Framework;
using Shouldly;

namespace HomeEconomics.Tests
{
    public class RepositoryTests
    {
        private IContainer _container;

        public RepositoryTests()
        {
            var mongo = new MongoClient(ConfigurationManager.ConnectionStrings["home-economics"].ConnectionString);
            var builder = new ContainerBuilder();
            builder.RegisterModule<Data.Module>();
            _container = builder.Build();
        }

        [Test]
        public void GenericRepository_CreatePersonWithNoId_GeneratesId()
        {
            // arrange isolation
            Database.Instance.Clear();

            // arrange test
            var expected = new Person
            {
                Name = "Kenneth LeFebvre",
                Names = new string[] {"Kenneth", "Leon","LeFebvre"},
                Birthdate = DateTimeOffset.Parse("1966-10-03T00:00:00-05:00"),
                Sex = Sex.Male,
            };

            // act
            var actual = Database.Instance.People.Create(expected);

            // assert
            actual.Id.ShouldNotBeNull();

            // cleanup

        }

    }
}
