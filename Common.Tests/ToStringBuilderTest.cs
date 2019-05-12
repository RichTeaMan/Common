using RichTea.Common.Tests.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace RichTea.Common.Tests
{
    [TestClass]
    public class ToStringBuilderTest
    {

        /// <summary>
        /// Tests to string in a basic object.
        /// </summary>
        [TestMethod]
        public void BasicToStringTest()
        {
            // setup
            string firstName = "Timmy";
            string lastName = "Biggles";

            var personA = new Person
            {
                FirstName = firstName,
                LastName = lastName
            };

            // test
            var personAString = personA.ToString();

            // assert
            Assert.AreEqual("Person:{FirstName=Timmy,LastName=Biggles}", personAString);
        }

        /// <summary>
        /// Tests to string in an object with a collection property.
        /// </summary>
        [TestMethod]
        public void CollectionToStringTest()
        {
            // setup
            var dictionaryContainer = new DictionaryContainer()
            {
                Name = "testName",
                Items = new Dictionary<string, string> { { "MemberA", "aaa" } }
            };

            // test
            var dictionaryContainerString = dictionaryContainer.ToString();

            // assert
            Assert.AreEqual("DictionaryContainer:{Name=testName,Items=[ [MemberA, aaa] ]}", dictionaryContainerString);
        }

        /// <summary>
        /// Tests to string append with a non property.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToStringAppendNonProperty()
        {
            // setup
            var dictionaryContainer = new MethodDictionaryContainer();
            var toStringBuilder = new ToStringBuilder<MethodDictionaryContainer>(dictionaryContainer);

            // test
            toStringBuilder.Append<string>(x => x.TestMethod());
        }

        /// <summary>
        /// Tests to string append expression with a null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToStringAppendExpressionNull()
        {
            // setup
            var dictionaryContainer = new DictionaryContainer();
            var toStringBuilder = new ToStringBuilder<DictionaryContainer>(dictionaryContainer);

            // test
            toStringBuilder.Append<string>(null);
        }

        /// <summary>
        /// Tests to string append with a null.
        /// </summary>
        [TestMethod]
        public void ToStringAppendNull()
        {
            // setup
            var dictionaryContainer = new DictionaryContainer();
            var toStringBuilder = new ToStringBuilder<DictionaryContainer>(dictionaryContainer);

            // test
            toStringBuilder.Append(null, "NullName");
            var toString = toStringBuilder.ToString();

            // assert
            Assert.AreEqual("DictionaryContainer:{NullName=null}", toString);
        }
    }

    class MethodDictionaryContainer : DictionaryContainer
    {
        public string TestMethod() { return "test"; }
    }
}
