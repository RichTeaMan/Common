using System.Collections.Generic;

namespace Common.Test.Objects
{
    public class ObjectDictionaryContainer
    {
        public string Name { get; set; }

        public Dictionary<string, object> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<ObjectDictionaryContainer>(this)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<ObjectDictionaryContainer>(this, that)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .Equals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<ObjectDictionaryContainer>(this)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .HashCode;
        }
    }
}
