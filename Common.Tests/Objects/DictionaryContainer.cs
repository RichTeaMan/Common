using System.Collections.Generic;

namespace RichTea.Common.Tests.Objects
{
    public class DictionaryContainer
    {
        public string Name { get; set; }

        public Dictionary<string, string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<DictionaryContainer>(this)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<DictionaryContainer>(this, that)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .AreEqual;
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
