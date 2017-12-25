﻿using System.Collections.Generic;

namespace Common.Test.Objects.ObjectAppenders
{
    public class DictionaryContainer
    {
        public string Name { get; set; }

        public Dictionary<string, string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<DictionaryContainer>(this)
                .Append(Name)
                .Append(Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            var other = that as DictionaryContainer;
            return new EqualsBuilder<DictionaryContainer>(this, that)
                .Append(Name, other?.Name)
                .Append(Items, other?.Items)
                .Equals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<DictionaryContainer>(this)
                .Append(Name)
                .Append(Items)
                .HashCode;
        }
    }
}
