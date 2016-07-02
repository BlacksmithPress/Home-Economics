using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace HomeEconomics.Tests
{
    class FamilyTests
    {

        [Test]
        public void Members_Add_CreatesRelationship()
        {
            // arrange isolation

            // arrange test
            var family = Samples.People.Family.LeFebvre;
            var person = Samples.People.Person.Lowell;

            // act
            family.Members.Add(person);

            // assert
            person.Families.ShouldContain(f => f.Id == family.Id);

            // cleanup
        }

        [Test]
        public void Members_Remove_DeletesRelationship()
        {
            // arrange isolation

            // arrange test
            var family = Samples.People.Family.LeFebvre;
            var person = family.Members.First(m => m.Names[0] == "Ken");

            // act
            family.Members.Remove(person);

            // assert
            person.Families.ShouldNotContain(f => f.Id == family.Id);

            // cleanup

        }

    }
}
