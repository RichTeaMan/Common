
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
    }
}
