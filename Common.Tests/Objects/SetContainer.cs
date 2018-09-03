using System.Collections.Generic;

namespace RichTea.Common.Tests.Objects
{
    public class SetContainer
    {
        public string Name { get; set; }

        public ISet<string> Items { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<SetContainer>(this)
                .Append(x => x.Name)
                .Append(x => x.Items)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<SetContainer>(this, that)
                .Append(x => x.Name)
                .Append(x => x.Items)
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
