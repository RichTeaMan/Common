using Common.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.Test
{
    [TestClass]
    public class EqualsBuilderTest
    {

        /// <summary>
        /// Tests if equals can handle nulls.
        /// </summary>
        [TestMethod]
        public void NullEqualsTest()
        {
            // setup
            string firstName = "Timmy";
            string lastName = "Biggles";

            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            // test
            var equal = person.Equals(null);

            // assert
            Assert.IsFalse(equal);
        }

        /// <summary>
        /// Tests if the object reference is equal.
        /// </summary>
        [TestMethod]
        public void ReferenceEqualsTest()
        {
            // setup
            string firstName = "Timmy";
            string lastName = "Biggles";

            var person = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            // test
            var equal = person.Equals(person);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object is equal.
        /// </summary>
        [TestMethod]
        public void BasicEqualsTest()
        {
            // setup
            string firstName = "Timmy";
            string lastName = "Biggles";

            var personA = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            var personB = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            // test
            var equal = personA.Equals(personB);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object is not equal.
        /// </summary>
        [TestMethod]
        public void BasicNotEqualsTest()
        {
            // setup
            string firstNameA = "Timmy";
            string lastNameA = "Biggles";

            string firstNameB = "Tommy";
            string lastNameB = "Biggles";

            var personA = new Person
            {
                FirstName = firstNameA,
                LastName = lastNameA
            };

            var personB = new Person
            {
                FirstName = firstNameB,
                LastName = lastNameB
            };

            // test
            var equal = personA.Equals(personB);

            // assert
            Assert.IsFalse(equal);
        }
    }
}
