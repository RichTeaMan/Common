using System.Collections.Generic;

namespace RichTea.Common.Tests.Objects.ObjectAppenders
{
    public class ListContainer
    {
        public string Name { get; set; }

        public List<string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<ListContainer>(this)
                .Append(Name)
                .Append(Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            var other = that as ListContainer;
            return new EqualsBuilder<ListContainer>(this, that)
                .Append(Name, other?.Name)
                .Append(Items, other?.Items)
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
