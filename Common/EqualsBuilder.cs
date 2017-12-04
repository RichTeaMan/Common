using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common
{
    /// <summary>
    /// Inspired code from https://dhavaldalal.wordpress.com/2012/03/16/equals-hashcode-and-tostring-build/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EqualsBuilder<T>
    {
        private readonly T left;
        private readonly object right;
        private bool areEqual = true;

        public EqualsBuilder(T left, object right)
        {
            this.left = left;
            this.right = right;

            if (ReferenceEquals(left, right))
            {
                areEqual = true;
                return;
            }

            if (ReferenceEquals(left, null))
            {
                areEqual = false;
                return;
            }

            if (ReferenceEquals(right, null))
            {
                areEqual = false;
                return;
            }

            if (left.GetType() != right.GetType())
            {
                areEqual = false;
                return;
            }
        }

        public EqualsBuilder<T> Append<TProperty>(Expression<Func<T, TProperty>> propertyOrField)
        {
            if (!areEqual)
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

            if (leftValue == null && rightValue == null)
            {
                areEqual = true;
                return this;
            }

            if (leftValue != null && rightValue == null)
            {
                areEqual = false;
                return this;
            }

            if (leftValue == null && rightValue != null)
            {
                areEqual = false;
                return this;
            }

            var leftIEnumerable = leftValue as IEnumerable<object>;
            var rightIEnumerable = rightValue as IEnumerable<object>;
            if (null != leftIEnumerable && null != rightIEnumerable)
            {
                areEqual &= leftIEnumerable.SequenceEqual(rightIEnumerable);
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
                        if (!(rightIDictionary.Contains(key) && leftIDictionary[key] == rightIDictionary[key]))
                        {
                            areEqual = false;
                            return this;
                        }
                    }
                }
                else
                {
                    areEqual = false;
                }
                return this;
            }

            areEqual = leftValue.Equals(rightValue);
            return this;
        }

        public bool Equals()
        {
            return areEqual;
        }
    }
}
