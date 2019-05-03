
using System;

namespace RichTea.Common.Extensions
{
    /// <summary>
    /// Extension methods for the Random class.
    /// </summary>
    public static class RandomExtension
    {
        /// <summary>
        /// Gets a random double between the two specified numbers.
        /// </summary>
        /// <param name="random">Random.</param>
        /// <param name="min">Minimum random number.</param>
        /// <param name="max">Maximum randon number.</param>
        /// <returns>Random number in the given range.</returns>
        public static double NextDouble(this Random random, double min, double max)
        {
            double delta = max - min;
            var next = delta * random.NextDouble();
            var result = next + min;
            return result;
        }

        /// <summary>
        /// Gets a random double from 0 within +/- the supplied range.
        /// </summary>
        /// <param name="random">Random.</param>
        /// <param name="range">The range above and below 0 to generate the number.</param>
        /// <returns>Random number in the given range.</returns>
        public static double NextDoubleInRange(this Random random, double range)
        {
            var result = random.NextDouble(-range, range);
            return result;
        }

        /// <summary>
        /// Gets a random double from the start value within +/- the supplied range.
        /// </summary>
        /// <param name="random">Random.</param>
        /// <param name="start">The number the range is starts from.</param>
        /// <param name="range">The range above and below the start to generate the number.</param>
        /// <returns>Random number in the given range.</returns>
        public static double NextDoubleInRange(this Random random, double start, double range)
        {
            var result = NextDouble(random, start - range, start + range);
            return result;
        }

        /// <summary>
        /// Gets a random long integer.
        /// </summary>
        /// <param name="rnd">Random.</param>
        /// <returns>Random long.</returns>
        public static long RandomLong(this Random rnd)
        {
            byte[] buffer = new byte[8];
            rnd.NextBytes(buffer);
            return BitConverter.ToInt64(buffer, 0);
        }

        /// <summary>
        /// Gets a random long integer between the specified numbers.
        /// </summary>
        /// <param name="random">Random.</param>
        /// <param name="min">Minimum random number.</param>
        /// <param name="max">Maximum randon number.</param>
        /// <returns>Random number in the given range.</returns>
        public static long RandomLong(this Random rnd, long min, long max)
        {
            EnsureMinLEQMax(ref min, ref max);
            long numbersInRange = unchecked(max - min + 1);
            if (numbersInRange < 0)
            {
                throw new ArgumentException("Size of range between min and max must be less than or equal to Int64.MaxValue");
            }

            long randomOffset = RandomLong(rnd);
            if (IsModuloBiased(randomOffset, numbersInRange))
            {
                return RandomLong(rnd, min, max);
            }
            else
            {
                return min + PositiveModuloOrZero(randomOffset, numbersInRange);
            }
        }

        static bool IsModuloBiased(long randomOffset, long numbersInRange)
        {
            long greatestCompleteRange = numbersInRange * (long.MaxValue / numbersInRange);
            return randomOffset > greatestCompleteRange;
        }

        static long PositiveModuloOrZero(long dividend, long divisor)
        {
            long mod;
            Math.DivRem(dividend, divisor, out mod);
            if (mod < 0)
            {
                mod += divisor;
            }
            return mod;
        }

        static void EnsureMinLEQMax(ref long min, ref long max)
        {
            if (min <= max)
            {
                return;
            }
            long temp = min;
            min = max;
            max = temp;
        }
    }
}
