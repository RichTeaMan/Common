using System;
using System.Collections;
using System.Collections.Generic;

namespace RichTea.Common
{
    /// <summary>
    /// A generic class for handling get hash code methods.
    /// </summary>
    /// <typeparam name="T">The type being hashed.</typeparam>
    public class HashCodeBuilder<T> : HashCodeBuilder
    {
        /// <summary>
        /// Hash code builder constructor. Should be suppplied with the object being hashed then
        /// fields to add ot the hash should be chained with the Append method.
        /// </summary>
        public HashCodeBuilder(T target)
        {
        }
    }

    /// <summary>
    /// A generic class for handling get hash code methods.
    /// </summary>
    public class HashCodeBuilder
    {

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        public int HashCode { get; private set; } = 17;

        /// <summary>
        /// Appends a field to the hash code builder.
        /// 
        /// This method can handle nulls and collections.
        /// </summary>
        /// <param name="property">Property to hash.</param>
        /// <returns>Hash code builder.</returns>
        public HashCodeBuilder Append(object property)
        {
            if (property is IEnumerable<object> enumerable)
            {
                foreach (var value in enumerable)
                {
                    Append(value);
                }
                return this;
            }

            if (property is IDictionary dictionary)
            {
                foreach (var key in dictionary.Keys)
                {
                    Append(key);
                    Append(dictionary[key]);
                }
                return this;
            }

            if (property is ICollection collection)
            {
                var leftEnumerator = collection.GetEnumerator();

                while (leftEnumerator.MoveNext())
                {
                    Append(leftEnumerator.Current);
                }
                return this;
            }

            HashCode = 31 * HashCode + ((property == null) ? 0 : property.GetHashCode());
            return this;
        }


    }
}
