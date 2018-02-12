# EqualsBuilder

This is class for easily overriding an equals method.

## Examples

```C#
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override bool Equals(object that)
    {
        return new EqualsBuilder<Person>(this, that)
            .Append(x => x.FirstName)
            .Append(x => x.LastName)
            .AreEqual;
    }
}
```

Alternatively, a performance gain can be had by not using lambdas:

```C#
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override bool Equals(object that)
    {
        var other = that as Person;
        return new EqualsBuilder<Person>(this, that)
            .Append(FirstName, other?.FirstName)
            .Append(LastName, other?.LastName)
            .AreEqual;
    }

}
```

Base classes can also be tried for equality using the AppendBase method:

```C#
public class Employee : Person
{
    public string JobTitle { get; set; }

    public override bool Equals(object that)
    {
        return new EqualsBuilder<Employee>(this, that)
            .AppendBase(base.Equals(that))
            .Append(x => x.JobTitle)
            .AreEqual;
    }
}
```

## Remarks

This method will recursively run the Equals method on every supplied field and only return true if every part is equal. Individual elements and length are checked in collections.
If the collection implements IList ordering is also checked.

Note that only the Equals method is invoked, never GetHashCode. Consider this if performance is an issue.
