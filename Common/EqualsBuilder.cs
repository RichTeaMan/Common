using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace RichTea.Common
{
    /// <summary>
    /// A generic class for handling equals methods.
    /// </summary>
    /// <typeparam name="T">The type being compared.</typeparam>
    public class EqualsBuilder<T>
    {
        /// <summary>
        /// Left object.
        /// </summary>
        private readonly T left;

        /// <summary>
        /// Right object.
        /// </summary>
        private readonly object right;

        /// <summary>
        /// Gets if the objects are equal. If false no further comparison should be required.
        /// </summary>
        public bool AreEqual { get; protected set; } = true;

        /// <summary>
        /// Equals builder constructor. Should be supplied with the two objects being compared.
        /// Field comparisons should be chained with the Append and AppendBase methods.
        /// </summary>
        /// <param name="left">Object being compared.</param>
        /// <param name="right">Object being compared against.</param>
        public EqualsBuilder(T left, object right)
        {
            this.left = left;
            this.right = right;

            if (ReferenceEquals(left, right))
            {
                AreEqual = true;
                return;
            }

            if (left == null)
            {
                AreEqual = false;
                return;
            }

            if (right == null)
            {
                AreEqual = false;
                return;
            }

            if (left.GetType() != right.GetType())
            {
                AreEqual = false;
                return;
            }

        }

        /// <summary>
        /// Appends if base object is equal. This should be called with the result of base.Equals.
        /// </summary>
        /// <param name="baseEqual">If base object is equal.</param>
        /// <returns>Equals builder.</returns>
        public EqualsBuilder<T> AppendBase(bool baseEqual)
        {
            AreEqual = AreEqual && baseEqual;
            return this;
        }

        /// <summary>
        /// Appends a field to the equals builder. Both parameters should refer to the same field.
        /// 
        /// This method can handle nulls and collections.
        /// </summary>
        /// <param name="leftValue">Left value.</param>
        /// <param name="rightValue">Right value.</param>
        /// <returns>Equals builder.</returns>
        public EqualsBuilder<T> Append(object leftValue, object rightValue)
        {
            if (!AreEqual)
            {
                return this;
            }

            if (leftValue == null && rightValue == null)
            {
                AreEqual = true;
                return this;
            }

            if (leftValue != null && rightValue == null)
            {
                AreEqual = false;
                return this;
            }

            if (leftValue == null && rightValue != null)
            {
                AreEqual = false;
                return this;
            }

            var leftIEnumerable = leftValue as IEnumerable<object>;
            var rightIEnumerable = rightValue as IEnumerable<object>;
            if (null != leftIEnumerable && null != rightIEnumerable)
            {
                AreEqual &= leftIEnumerable.SequenceEqual(rightIEnumerable);
                return this;
            }

            var leftIDictionary = leftValue as IDictionary;
            var rightIDictionary = rightValue as IDictionary;
            if (null != leftIDictionary && null != rightIDictionary)
            {
                if (leftIDictionary.Count == rightIDictionary.Count)
                {
                    foreach (var key in leftIDictionary.Keys)
                    {
                        if (rightIDictionary.Contains(key))
                        {
                            Append(leftIDictionary[key], rightIDictionary[key]);
                            if (!AreEqual)
                            {
                                return this;
                            }
                        }
                        else
                        {
                            AreEqual = false;
                            return this;
                        }
                    }
                }
                else
                {
                    AreEqual = false;
                }
                return this;
            }

            var leftICollection = leftValue as ICollection;
            var rightICollection = rightValue as ICollection;
            if (null != leftICollection && null != rightICollection)
            {
                if (leftICollection.Count == rightICollection.Count)
                {
                    var leftEnumerator = leftICollection.GetEnumerator();
                    var rightEnumerator = rightICollection.GetEnumerator();

                    while (leftEnumerator.MoveNext() && rightEnumerator.MoveNext())
                    {
                        Append(leftEnumerator.Current, rightEnumerator.Current);
                        if (!AreEqual)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    AreEqual = false;
                }
                return this;
            }

            AreEqual = leftValue.Equals(rightValue);
            return this;
        }

        /// <summary>
        /// Appends an expression to the equals builder. This expression is then used on both left and right values
        /// to find a field value to be compared.
        /// 
        /// This method can handle expressions that return nulls and collections. Note that this method is considerably
        /// slower than the Append(object, object) override. That method should be used if higher performance is required,
        /// </summary>
        /// <param name="propertyOrField">Expression that returns a proeprty or field.</param>
        /// <returns>Equals builder.</returns>
        public EqualsBuilder<T> Append<TProperty>(Expression<Func<T, TProperty>> propertyOrField)
        {
            if (!AreEqual)
            {
                return this;
            }

            if (left == null || right == null)
            {
                return this;
            }

            var expression = propertyOrField.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("Expecting Property or Field Expression of an object");
            }

            Func<T, TProperty> func = propertyOrField.Compile();
            TProperty leftValue = func(left);
            TProperty rightValue = func((T)right);

            Append(leftValue, rightValue);
            return this;
        }

    }
}
