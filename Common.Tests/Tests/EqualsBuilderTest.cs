using Common.Test.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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

        /// <summary>
        /// Tests if the object with a list is equal.
        /// </summary>
        [TestMethod]
        public void ListEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new List<string>
            {
                "apple",
                "banana"
            };

            string nameB = "Timmy";
            var itemsB = new List<string>
            {
                "apple",
                "banana"
            };

            var listContainerA = new ListContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var listContainerB = new ListContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = listContainerA.Equals(listContainerB);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object with a list is not equal.
        /// </summary>
        [TestMethod]
        public void ListNotEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new List<string>
            {
                "appleA",
                "bananaA"
            };

            string nameB = "Timmy";
            var itemsB = new List<string>
            {
                "appleB",
                "bananaB"
            };

            var listContainerA = new ListContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var listContainerB = new ListContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = listContainerA.Equals(listContainerB);

            // assert
            Assert.IsFalse(equal);
        }

        /// <summary>
        /// Tests if the object with a set is equal.
        /// </summary>
        [TestMethod]
        public void SetEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new HashSet<string>
            {
                "apple",
                "banana"
            };

            string nameB = "Timmy";
            var itemsB = new HashSet<string>
            {
                "apple",
                "banana"
            };

            var setContainerA = new SetContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var setContainerB = new SetContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = setContainerA.Equals(setContainerB);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object with a set is not equal.
        /// </summary>
        [TestMethod]
        public void SetNotEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new HashSet<string>
            {
                "appleA",
                "bananaA"
            };

            string nameB = "Timmy";
            var itemsB = new HashSet<string>
            {
                "appleB",
                "bananaB"
            };

            var setContainerA = new SetContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var setContainerB = new SetContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = setContainerA.Equals(setContainerB);

            // assert
            Assert.IsFalse(equal);
        }

        /// <summary>
        /// Tests if the object with a dictionary is equal.
        /// </summary>
        [TestMethod]
        public void DictionaryEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new Dictionary<string, string>
            {
                { "a", "apple" },
                { "b", "banana" }
            };

            string nameB = "Timmy";
            var itemsB = new Dictionary<string, string>
            {
                { "a", "apple" },
                { "b", "banana" }
            };

            var dictionaryContainerA = new DictionaryContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var dictionaryContainerB = new DictionaryContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = dictionaryContainerA.Equals(dictionaryContainerB);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object with a dictionary is equal.
        /// </summary>
        [TestMethod]
        public void DictionaryEqualsWithDeferencingTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", 32 }
            };

            string nameB = "Timmy";
            var itemsB = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", 32 }
            };

            var dictionaryContainerA = new ObjectDictionaryContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var dictionaryContainerB = new ObjectDictionaryContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = dictionaryContainerA.Equals(dictionaryContainerB);

            // assert
            Assert.IsTrue(equal);
        }

        /// <summary>
        /// Tests if the object with a dictionary is not equal.
        /// </summary>
        [TestMethod]
        public void DictionaryNotEqualsTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new Dictionary<string, string>
            {
                { "a", "appleA" },
                { "b", "bananaA" }
            };

            string nameB = "Timmy";
            var itemsB = new Dictionary<string, string>
            {
                { "aa", "appleB" },
                { "bb", "bananaB" }
            };

            var dictionaryContainerA = new DictionaryContainer
            {
                Name = nameA,
                Items = itemsA
            };

            var dictionaryContainerB = new DictionaryContainer
            {
                Name = nameB,
                Items = itemsB
            };

            // test
            var equal = dictionaryContainerA.Equals(dictionaryContainerB);

            // assert
            Assert.IsFalse(equal);
        }
    }
}
