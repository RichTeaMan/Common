using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichTea.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RichTea.Common.Tests
{
    [TestClass]
    public class RandomLongExtensionTest
    {
        [TestMethod]
        public void NextLongTest()
        {
            Random random = new Random();
            long min = -10568902224567;
            long max = 1277880939201;

            int randomNumbersToGenerate = 10000;

            List<long> randomResult = new List<long>();

            foreach (var i in Enumerable.Range(0, randomNumbersToGenerate))
            {
                long randomLong = random.NextLong(min, max);
                randomResult.Add(randomLong);
            }

            int numbersBelowMin = randomResult.Count(n => n < min);
            int numbersAboveMax = randomResult.Count(n => n >= max);

            Assert.AreEqual(0, numbersBelowMin);
            Assert.AreEqual(0, numbersAboveMax);
        }
    }
}
