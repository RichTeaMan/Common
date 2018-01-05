using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RichTea.Common
{
    /// <summary>
    /// A generic class for building to strings.
    /// 
    /// Inspired code from https://dhavaldalal.wordpress.com/2012/03/16/equals-hashcode-and-tostring-build/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ToStringBuilder<T>
    {
        private readonly T target;
        private readonly string typeName;
        private const string DELIMITER = "=";
        private IList<string> values = new List<string>();

        /// <summary>
        /// Constructs to string builder.
        /// </summary>
        /// <param name="target">Object to build string for.</param>
        public ToStringBuilder(T target)
        {
            this.target = target;
            typeName = target.GetType().Name;
        }

        /// <summary>
        /// Builds a string for a given property and name. This has no side effects on the builder.
        /// </summary>
        /// <param name="property">Property value.</param>
        /// <param name="propertyName">Property name.</param>
        /// <returns>To string.</returns>
        private string BuildToString(object property, string propertyName)
        {
            string value;

            if (property is ICollection returnCollection)
            {
                List<string> collectionValues = new List<string>();
                var collectionEnumerator = returnCollection.GetEnumerator();

                while (collectionEnumerator.MoveNext())
                {
                    collectionValues.Add(BuildToString(collectionEnumerator.Current, null));
                }

                value = string.Format("[ {0} ]", string.Join(", ", collectionValues));
            }
            else
            {

                value = (property == null) ? "null" : property.ToString();
            }
            return value;
        }

        /// <summary>
        /// Appends a property and optionally a property name to the string builder.
        /// </summary>
        /// <param name="property">Property value.</param>
        /// <param name="propertyName">Property name. Defaults to null.</param>
        /// <returns>To string builder.</returns>
        public ToStringBuilder<T> Append(object property, string propertyName = null)
        {
            string value = BuildToString(property, propertyName);
            values.Add(propertyName + DELIMITER + value);
            return this;
        }

        /// <summary>
        /// Appends a property with an expression. This expression is used to find property value and
        /// its name. Note that this method is considerably slower than Append(object, string).
        /// </summary>
        /// <param name="propertyOrField">Expression for a property value.</param>
        /// <returns>To string builder.</returns>
        public ToStringBuilder<T> Append<TProperty>(Expression<Func<T, TProperty>> propertyOrField)
        {
            var expression = propertyOrField.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("Expecting Property or Field Expression");
            }
            var name = expression.Member.Name;
            var func = propertyOrField.Compile();
            var returnValue = func(target);

            Append(returnValue, name);
            return this;
        }

        /// <summary>
        /// Builds to string from object.
        /// </summary>
        /// <returns>To string.</returns>
        public override string ToString()
        {
            return typeName + ":{" + string.Join(",", values) + "}";
        }
    }
}
