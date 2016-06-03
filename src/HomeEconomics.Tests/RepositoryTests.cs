using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using HomeEconomics.Data.Entities;
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
            var people = mongo.GetDatabase("home-economics").GetCollection<IPerson>("People");

            var builder = new ContainerBuilder();
            builder.RegisterType<Person>().As<IPerson>();
            builder.RegisterType<Repository<IPerson>>().As<IRepository<IPerson>>();
            builder.RegisterInstance(people).As<IMongoCollection<IPerson>>();

            _container = builder.Build();
        }

        [Test]
        public void GenericRepository_CreatePersonWithNoId_GeneratesId()
        {
            // arrange isolation

            // arrange test
            var expected = new Person
            {
                Name = "Kenneth LeFebvre",
                Names = new string[] {"Kenneth", "Leon","LeFebvre"},
                Birthdate = DateTimeOffset.Parse("1966-10-03T00:00:00-05:00"),
                Sex = Sex.Male,
            };
            var repository = _container.Resolve<IRepository<IPerson>>();

            // act
            var actual = repository.Create(expected);

            // assert
            actual.Id.ShouldNotBeNullOrEmpty();

            // cleanup

        }

    }
}
