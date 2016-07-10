using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arango.Client;
using HomeEconomics.Data;
using HomeEconomics.Data.ArangoDB;
using HomeEconomics.Tests.Samples.People;
using NUnit.Framework;
using Shouldly;

namespace HomeEconomics.Tests.ArangoDB
{
    [TestFixture]
    public class DirectTests
    {
        [Test]
        public void ConnectToDatabase()
        {
            ASettings.AddConnection("System", "localhost", 8529, false, "_system", "root", "");
            ASettings.AddConnection("Testing", "localhost", 8529, false, "Testing", "kenlefeb", "Tishri19");
            var system = new ADatabase("System");
            var createDatabaseResult = system.Create("Testing", new List<AUser>
            {
                new AUser {Username = "kenlefeb", Password = "Tishri19", Active = true}
            });
            createDatabaseResult.Success.ShouldBeTrue();

            var database = new ADatabase("Testing");
            var createCollectionResult = database.Collection
                .KeyGeneratorType(AKeyGeneratorType.Autoincrement)
                .WaitForSync(true)
                .Create("People");
            createCollectionResult.Success.ShouldBeTrue();

            var person = Person.Ken.ToJson();
            var createDocumentResult = database.Document
                .WaitForSync(true)
                .Create("People", person);
            createDocumentResult.Success.ShouldBeTrue();


            var deleteCollectionResult = database.Collection.Delete("People");
            deleteCollectionResult.Success.ShouldBeTrue();

            var deleteDatabaseResult = system.Drop("Testing");
            deleteDatabaseResult.Success.ShouldBeTrue();
        }

        [Test]
        public void GetPerson()
        {
            var id = "People/64508";
            ASettings.AddConnection("home-economics", "localhost", 8529, false, "home-economics");
            var database = new ADatabase("home-economics");
            var person = database.Document.Get<Data.Entities.People.Person>(id);
            person.ShouldNotBeNull();
        }
    }
}
