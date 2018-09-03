using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichTea.Common.Tests.Objects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RichTea.Common.Tests
{
    [TestClass]
    public class HashBuilderTest
    {

        /// <summary>
        /// Tests if the object is equal.
        /// </summary>
        [TestMethod]
        public void BasicGetHashCodeTest()
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
            var personAHash = personA.GetHashCode();
            var personBHash = personB.GetHashCode();

            // assert
            Assert.AreEqual(personAHash, personBHash);
        }

        /// <summary>
        /// Tests if the object is not equal.
        /// </summary>
        [TestMethod]
        public void BasicNotGetHashCodeTest()
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
            var personAHash = personA.GetHashCode();
            var personBHash = personB.GetHashCode();

            // assert
            Assert.AreNotEqual(personAHash, personBHash);
        }

        /// <summary>
        /// Tests if the object with a list is equal.
        /// </summary>
        [TestMethod]
        public void ListGetHashCodeTest()
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
            var listContainerAHash = listContainerA.GetHashCode();
            var listContainerBHash = listContainerB.GetHashCode();

            // assert
            Assert.AreEqual(listContainerAHash, listContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a list is not equal.
        /// </summary>
        [TestMethod]
        public void ListNotGetHashCodeTest()
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
            var listContainerAHash = listContainerA.GetHashCode();
            var listContainerBHash = listContainerB.GetHashCode();

            // assert
            Assert.AreNotEqual(listContainerAHash, listContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a set is equal.
        /// </summary>
        [TestMethod]
        public void SetGetHashCodeTest()
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
            var setContainerAHash = setContainerA.GetHashCode();
            var setContainerBHash = setContainerB.GetHashCode();

            // assert
            Assert.AreEqual(setContainerAHash, setContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a set is not equal.
        /// </summary>
        [TestMethod]
        public void SetNotGetHashCodeTest()
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
            var setContainerAHash = setContainerA.GetHashCode();
            var setContainerBHash = setContainerB.GetHashCode();

            // assert
            Assert.AreNotEqual(setContainerAHash, setContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a dictionary is equal.
        /// </summary>
        [TestMethod]
        public void DictionaryGetHashCodeTest()
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
            var dictionaryContainerAHash = dictionaryContainerA.GetHashCode();
            var dictionaryContainerBHash = dictionaryContainerB.GetHashCode();

            // assert
            Assert.AreEqual(dictionaryContainerAHash, dictionaryContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a dictionary is equal. Importantly, the value type is an int but the
        /// dictionary is only typed to an object.
        /// </summary>
        [TestMethod]
        public void DictionaryGetHashCodeWithDeferencingTest()
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
            var dictionaryContainerAHash = dictionaryContainerA.GetHashCode();
            var dictionaryContainerBHash = dictionaryContainerB.GetHashCode();

            // assert
            Assert.AreEqual(dictionaryContainerAHash, dictionaryContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a dictionary is not equal.
        /// </summary>
        [TestMethod]
        public void DictionaryNotGetHashCodeTest()
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
            var dictionaryContainerAHash = dictionaryContainerA.GetHashCode();
            var dictionaryContainerBHash = dictionaryContainerB.GetHashCode();

            // assert
            Assert.AreNotEqual(dictionaryContainerAHash, dictionaryContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a dictionary is equal. The value is an array.
        /// </summary>
        [TestMethod]
        public void DictionaryGetHashCodeWithArraysTest()
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
            var dictionaryContainerAHash = dictionaryContainerA.GetHashCode();
            var dictionaryContainerBHash = dictionaryContainerB.GetHashCode();

            // assert
            Assert.AreEqual(dictionaryContainerAHash, dictionaryContainerBHash);
        }

        /// <summary>
        /// Tests if the object with a dictionary is not equal. The value is an array.
        /// </summary>
        [TestMethod]
        public void DictionaryNotGetHashCodeWithArraysTest()
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
            var dictionaryContainerAHash = dictionaryContainerA.GetHashCode();
            var dictionaryContainerBHash = dictionaryContainerB.GetHashCode();

            // assert
            Assert.AreNotEqual(dictionaryContainerAHash, dictionaryContainerBHash);
        }

        [TestMethod]
        public void HashCollisionTest()
        {
            Random random = new Random(17);

            int arraySize = 40;
            int arrayCount = 10000;
            var hashes = new List<int>();

            foreach (var i in Enumerable.Range(0, arrayCount))
            {
                var array = Enumerable.Range(0, arraySize).Select(a => random.NextDouble()).ToArray();

                var hash = new HashCodeBuilder().Append(array).HashCode;
                hashes.Add(hash);

                // modifiy just one element and rehash
                array[array.Length - 1] = random.NextDouble();
                var hash2 = new HashCodeBuilder().Append(array).HashCode;
                hashes.Add(hash2);
            }

            int distinctHashCount = hashes.Distinct().Count();

            Assert.AreEqual(arrayCount * 2, distinctHashCount);
        }
    }
}
