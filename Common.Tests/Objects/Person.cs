namespace Common.Test.Objects
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<Person>(this)
                .Append(x => x.FirstName)
                .Append(x => x.LastName)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<Person>(this, that)
                .Append(x => x.FirstName)
                .Append(x => x.LastName)
                .Equals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<Person>(this)
                .Append(FirstName)
                .Append(LastName)
                .HashCode;
        }
    }
}
