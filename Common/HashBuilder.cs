﻿using System;
using System.Linq.Expressions;

namespace Common
{
    /// <summary>
    /// Inspired code from https://dhavaldalal.wordpress.com/2012/03/16/equals-hashcode-and-tostring-build/
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HashCodeBuilder<T>
    {
        private readonly T target;
        private int hashCode = 17;

        public HashCodeBuilder(T target)
        {
            this.target = target;
        }

        public HashCodeBuilder<T> Append(object property)
        {
            hashCode += 31 * hashCode + ((property == null) ? 0 : property.GetHashCode());
            return this;
        }

        public HashCodeBuilder<T> Append<TProperty>(Expression<Func<T, TProperty>> propertyOrField)
        {
            var expression = propertyOrField.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("Expecting Property or Field Expression of an object");
            }

            var func = propertyOrField.Compile();
            var value = func(target);
            Append(value);
            return this;
        }

        public int HashCode
        {
            get
            {
                return hashCode;
            }
        }
    }
}
