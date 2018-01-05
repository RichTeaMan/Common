using System.Collections.Generic;

namespace RichTea.Common.Tests.Objects.ObjectAppenders
{
    public class SetContainer
    {
        public string Name { get; set; }

        public ISet<string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<SetContainer>(this)
                .Append(Name)
                .Append(Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            var other = that as SetContainer;
            return new EqualsBuilder<SetContainer>(this, that)
                .Append(Name, other?.Name)
                .Append(Items, other?.Items)
                .AreEqual;
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<SetContainer>(this)
                .Append(Name)
                .Append(Items)
                .HashCode;
        }
    }
}
