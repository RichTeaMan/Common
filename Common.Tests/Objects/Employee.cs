namespace Common.Tests.Objects
{
    public class Employee : Person
    {
        public string JobTitle { get; set; }

        public override string ToString()
        {
            return new ToStringBuilder<Employee>(this)
                .Append(x => x.JobTitle)
                .ToString();
        }

        public override bool Equals(object that)
        {
            return new EqualsBuilder<Employee>(this, that)
                .AppendBase(base.Equals(that))
                .Append(x => x.JobTitle)
                .Equals();
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder<Employee>(this)
                .Append(JobTitle)
                .HashCode;
        }
    }
}
