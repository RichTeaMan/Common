using System.Collections.Generic;

namespace Common.Tests.Objects
{
    public class ListContainer
    {
        public string Name { get; set; }

        public List<string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<ListContainer>(this)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<ListContainer>(this, that)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .AreEqual;
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<ListContainer>(this)
                .Append(Name)
                .Append(Items)
                .HashCode;
        }
    }
}
