# HashBuilder

This is class for easily overriding a GetHashCode method.

## Examples

```C#
public class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override int GetHashCode()
    {
        return new HashCodeBuilder<Person>(this)
            .Append(FirstName)
            .Append(LastName)
            .HashCode;
    }
}
```

Note that hash builder does not have a lambda override.

Base classes can also be hashed by using the base get hash code method:

```C#
public class Employee : Person
{
    public string JobTitle { get; set; }

    public override int GetHashCode()
    {
        return new HashCodeBuilder<Employee>(this)
            .Append(base.GetHashCode())
            .Append(JobTitle)
            .HashCode;
    }
}
```

## Remarks

This method will recursively run the GetHashCode method on every supplied field and append that hash. Individual elements in a collection are also hashed.
