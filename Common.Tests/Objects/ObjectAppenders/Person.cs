namespace Common.Tests.Objects.ObjectAppenders
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<Person>(this)
                .Append(FirstName)
                .Append(LastName)
                .ToString();
        }

        public override bool Equals(object that)
        {
            var other = that as Person;
            return new EqualsBuilder<Person>(this, that)
                .Append(FirstName, other?.FirstName)
                .Append(LastName, other?.LastName)
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
