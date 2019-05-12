using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichTea.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RichTea.Common.Tests
{
    [TestClass]
    public class RandomDoubleExtensionTest
    {
        [TestMethod]
        public void NextDoubleTest()
        {
            Random random = new Random();
            double min = -10.5;
            double max = 12.7;

            int randomNumbersToGenerate = 10000;

            List<double> randomResult = new List<double>();

            foreach (var i in Enumerable.Range(0, randomNumbersToGenerate))
            {
                double randomDouble = random.NextDouble(min, max);
                randomResult.Add(randomDouble);
            }

            int numbersBelowMin = randomResult.Count(n => n < min);
            int numbersAboveMax = randomResult.Count(n => n >= max);

            Assert.AreEqual(0, numbersBelowMin);
            Assert.AreEqual(0, numbersAboveMax);
        }

        [TestMethod]
        public void NextDoubleInRangeTest()
        {
            Random random = new Random();
            double range = 16.7;
            double min = -range;
            double max = range;

            int randomNumbersToGenerate = 10000;

            List<double> randomResult = new List<double>();

            foreach (var i in Enumerable.Range(0, randomNumbersToGenerate))
            {
                double randomDouble = random.NextDoubleInRange(range);
                randomResult.Add(randomDouble);
            }

            int numbersBelowMin = randomResult.Count(n => n < min);
            int numbersAboveMax = randomResult.Count(n => n >= max);

            Assert.AreEqual(0, numbersBelowMin);
            Assert.AreEqual(0, numbersAboveMax);
        }

        [TestMethod]
        public void NextDoubleInRangeWithStartTest()
        {
            Random random = new Random();
            double start = 9.8;
            double range = 16.7;
            double min = start - range;
            double max = start + range;

            int randomNumbersToGenerate = 10000;

            List<double> randomResult = new List<double>();

            foreach (var i in Enumerable.Range(0, randomNumbersToGenerate))
            {
                double randomDouble = random.NextDoubleInRange(start, range);
                randomResult.Add(randomDouble);
            }

            int numbersBelowMin = randomResult.Count(n => n < min);
            int numbersAboveMax = randomResult.Count(n => n >= max);

            Assert.AreEqual(0, numbersBelowMin);
            Assert.AreEqual(0, numbersAboveMax);
        }
    }
}
