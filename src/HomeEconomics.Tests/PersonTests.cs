using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace HomeEconomics.Tests
{
    class PersonTests
    {
        [Test]
        public void Families_Add_CreatesRelationship()
        {
            // arrange isolation

            // arrange test
            var family = Samples.People.Family.LeFebvre;
            var person = Samples.People.Person.Lowell;

            // act
            person.Families.Add(family);

            // assert
            family.Members.ShouldContain(m => m.Id == person.Id);

            // cleanup
        }

        [Test]
        public void Families_Remove_DeletesRelationship()
        {
            // arrange isolation

            // arrange test
            var family = Samples.People.Family.LeFebvre;
            var person = family.Members.First(m => m.Names[0] == "Ken");

            // act
            person.Families.Remove(family);

            // assert
            person.Families.ShouldNotContain(f => f.Id == family.Id);

            // cleanup

        }
    }
}
