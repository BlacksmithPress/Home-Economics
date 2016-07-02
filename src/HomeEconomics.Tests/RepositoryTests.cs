﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data;
using HomeEconomics.Data.MongoDB;
using HomeEconomics.Data.Entities.People;
using HomeEconomics.Types;
using HomeEconomics.Types.Enumerations;
using MongoDB.Driver;
using NodaTime;
using NUnit.Framework;
using Shouldly;
using Module = HomeEconomics.Data.MongoDB.Module;

namespace HomeEconomics.Tests
{
    public class RepositoryTests
    {
        private IContainer _container;

        public RepositoryTests()
        {
            var mongo = new MongoClient(ConfigurationManager.ConnectionStrings["home-economics"].ConnectionString);
            var builder = new ContainerBuilder();
            builder.RegisterModule<Module>();
            _container = builder.Build();
        }

        [Test]
        public void People_CreatePersonWithNoId_GeneratesId()
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

        [Test]
        public void People_Retrieve_DeserializesWithoutException()
        {
            // arrange isolation

            // arrange test
            var expected = Samples.People.Person.Ken;
            Database.Instance.People.Create(expected);

            // act
            var actual = Database.Instance.People.Retrieve(expected.Id);

            // assert
            actual.ShouldNotBeNull();

            // cleanup

        }

    }
}
