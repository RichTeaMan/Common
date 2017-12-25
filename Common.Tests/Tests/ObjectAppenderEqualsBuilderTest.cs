using Common.Test.Objects.ObjectAppenders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Common.Test
{
    [TestClass]
    public class ObjectAppenderEqualsBuilderTest
    {

        /// <summary>
        /// Tests if equals can handle nulls.
        /// </summary>
        [TestMethod]
        public void ObjectAppenderNullEqualsTest()
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
        public void ObjectAppenderReferenceEqualsTest()
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
        public void ObjectAppenderBasicEqualsTest()
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
        public void ObjectAppenderBasicNotEqualsTest()
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
        public void ObjectAppenderListEqualsTest()
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
        public void ObjectAppenderListNotEqualsTest()
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
        public void ObjectAppenderSetEqualsTest()
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
        public void ObjectAppenderSetNotEqualsTest()
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
        public void ObjectAppenderDictionaryEqualsTest()
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
        /// Tests if the object with a dictionary is equal. Importantly, the value type is an int but the
        /// dictionary is only typed to an object.
        /// </summary>
        [TestMethod]
        public void ObjectAppenderDictionaryEqualsWithDeferencingTest()
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
        public void ObjectAppenderDictionaryNotEqualsTest()
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

        /// <summary>
        /// Tests if the object with a dictionary is equal. The value is an array.
        /// </summary>
        [TestMethod]
        public void ObjectAppenderDictionaryEqualsWithArraysTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", new int[] {909 } }
            };

            string nameB = "Timmy";
            var itemsB = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", new int[] {909 } }
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
        /// Tests if the object with a dictionary is not equal. The value is an array.
        /// </summary>
        [TestMethod]
        public void ObjectAppenderDictionaryNotEqualsWithArraysTest()
        {
            // setup
            string nameA = "Timmy";
            var itemsA = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", new int[] {907 } }
            };

            string nameB = "Timmy";
            var itemsB = new Dictionary<string, object>
            {
                { "a", "apple" },
                { "b", new int[] {909 } }
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
            Assert.IsFalse(equal);
        }
    }
}
