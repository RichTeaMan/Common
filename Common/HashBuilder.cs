using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RichTea.Common
{
    /// <summary>
    /// A generic class for handling get hash code methods.
    /// 
    /// Inspired code from https://dhavaldalal.wordpress.com/2012/03/16/equals-hashcode-and-tostring-build/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashCodeBuilder<T>
    {
        /// <summary>
        /// Object being hashed.
        /// </summary>
        private readonly T target;

        /// <summary>
        /// Starting hash.
        /// </summary>
        private int hashCode = 17;

        /// <summary>
        /// Hash code builder constructor. Should be suppplied with the object being hashed then
        /// fields to add ot the hash should be chained with the Append method.
        /// </summary>
        public HashCodeBuilder(T target)
        {
            this.target = target;
        }

        /// <summary>
        /// Appends a field to the hash code builder.
        /// 
        /// This method can handle nulls and collections.
        /// </summary>
        /// <param name="property">Property to hash.</param>
        /// <returns>Hash code builder.</returns>
        public HashCodeBuilder<T> Append(object property)
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

            hashCode += 31 * hashCode + ((property == null) ? 0 : property.GetHashCode());
            return this;
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        public int HashCode
        {
            get
            {
                return hashCode;
            }
        }
    }
}
