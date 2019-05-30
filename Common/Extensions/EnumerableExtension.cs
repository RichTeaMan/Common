using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RichTea.Common.Extensions
{
    public static class EnumerableExtension
    {
        /// <summary>
        /// Randomises the order of a given collection.
        /// </summary>
        /// <typeparam name="T">Element type of collection.</typeparam>
        /// <param name="collection">Collection to randomise.</param>
        /// <returns>Randomised collection.</returns>
        public static IEnumerable<T> RandomiseOrder<T>(this IEnumerable<T> collection)
        {
            var random = new Random();
            var randomCollection = collection.RandomiseOrder(random);
            foreach(var randomElement in randomCollection)
            {
                yield return randomElement;
            }
        }

        /// <summary>
        /// Randomises the order of a given collection.
        /// </summary>
        /// <typeparam name="T">Element type of collection.</typeparam>
        /// <param name="collection">Collection to randomise.</param>
        /// <param name="random">Random generator to use.</param>
        /// <returns>Randomised collection.</returns>
        public static IEnumerable<T> RandomiseOrder<T>(this IEnumerable<T> collection, Random random)
        {
            var linkedList = new LinkedList<T>(collection);

            while (linkedList.Any())
            {
                int index = random.Next(linkedList.Count);
                var elementAt = linkedList.ElementAt(index);
                yield return elementAt;
                linkedList.Remove(elementAt);
            }
        }
    }
}
