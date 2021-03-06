﻿using System.Collections.Generic;

namespace RichTea.Common.Tests.Objects.ObjectAppenders
{
    public class ObjectDictionaryContainer
    {
        public string Name { get; set; }

        public Dictionary<string, object> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<ObjectDictionaryContainer>(this)
                .Append(Name)
                .Append(Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            var other = that as ObjectDictionaryContainer;
            return new EqualsBuilder<ObjectDictionaryContainer>(this, that)
                .Append(Name, other?.Name)
                .Append(Items, other?.Items)
                .AreEqual;
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                .Append(Name)
                .Append(Items)
                .HashCode;
        }
    }
}
