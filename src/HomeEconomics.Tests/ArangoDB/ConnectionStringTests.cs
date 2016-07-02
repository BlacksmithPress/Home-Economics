using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeEconomics.Data.ArangoDB;
using NUnit.Framework;
using Shouldly;

namespace HomeEconomics.Tests.ArangoDB
{
    [TestFixture]
    public class ConnectionStringTests
    {
        [Test]
        public void ConnectionString_ToString_FormatsUri()
        {
            // arrange
            var expected = "arangodb://root@localhost/home-economics";

            // act
            var actual = new ConnectionString
            {
                Alias = "home-economics",
                DatabaseName = "home-economics",
                Host = "localhost",
                IsSecured = true,
                Password = string.Empty,
                Port = 8529,
                Username = "root",
                Provider = "ArangoDB",

            }.ToString();

            // assert
            actual.ShouldBe(expected);
        }

        [Test]
        public void ConnectionString_SunnyDay_ParsesComponents()
        {
            // arrange
            var expected = new ConnectionString
            {
                Alias = "home-economics",
                DatabaseName = "home-economics",
                Host = "localhost",
                IsSecured = true,
                Password = string.Empty,
                Port = 8529,
                Username = "root",
            };

            // act
            var actual = new ConnectionString(new ConnectionStringSettings
            {
                Name = "home-economics",
                ConnectionString = "arangodb://root@localhost/home-economics",
                ProviderName = "ArangoDB",
            });

            // assert
            actual.ShouldBe(expected);
        }
    }
}
