# ToStringBuilder

This is class for easily overriding a ToString method.

## Examples

```C#
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
}
```

Alternatively, members can be used directly instead of with lambdas. Note that using ToStringBuilder this way will not include member names:

```C#
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

}
```

## Remarks

This method will make a string of all given fields values and their names, if available. Elements in collections will also be added to the string.
