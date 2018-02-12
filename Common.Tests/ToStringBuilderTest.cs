using RichTea.Common.Tests.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
