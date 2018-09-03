namespace RichTea.Common.Tests.Objects.ObjectAppenders
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
            return base.Equals(that) &&
             new EqualsBuilder<Employee>(this, that)
                .Append(x => x.JobTitle)
                .AreEqual;
        }

        public override int GetHashCode()
        {
            return new HashCodeBuilder()
                .Append(JobTitle)
                .HashCode;
        }
    }
}
