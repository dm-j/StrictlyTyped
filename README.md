# StrictlyTyped
StrictlyTyped is a C# library that provides a simple and convenient way to strictly type values in your code. It consists of two parts: a package called `StrictlyTyped.Common`, and an incremental source generator called `StrictlyTyped.Generator`.

The `StrictlyTyped.Common` package provides a set of interfaces and marker attributes and extension methods that you can use to create and use your own strictly typed values. The `StrictlyTyped.Generator` package works by analyzing your code while you work and generating partial implementations of stub record structs for you.

When you use StrictlyTyped, you can create strictly typed values in your code that are more expressive and self-documenting than raw primitives. For example, suppose you have a string that represents a last name value. With a raw string, you don't have any information about what the string represents or what values it should contain. If you pass this string around your codebase, it can be difficult to keep track of what it represents and what operations are valid on it.

However, if you use StrictlyTyped, you can define a `LastName` by applying the `[StrictString]` Attribute and using StrictlyTyped.Generator. This will generate a full implementation of an immutable record struct that represents a last name value. This struct is strictly typed, which means that it has a specific type that is separate from other types in your code. This makes it clear what the value represents and what operations are valid on it.

```csharp
[StrictString] public partial record struct FirstName;
[StrictString] public partial record struct LastName;
```
Using this struct, you can create strictly typed values for last names. For example:

```csharp
var lastName = "Smith".As<LastName>();
```
Now, instead of a raw `string` that could contain any value, you have a Strictly typed value that you can pass around your codebase. This helps prevent errors and makes your code easier to read and maintain. For example, if you have a method that takes a `LastName` parameter, you know exactly what kind of value you should pass to that method:

``` csharp
void Greet(FirstName firstName, LastName lastName)
{
    Console.WriteLine($"Hello {firstName} {lastName}");
}

var firstName = "Michael".As<FirstName>();
var lastName = "Smith".As<LastName>();
var email = "x@x"

Print(firstName, lastName); // This is clear and correct

Print(lastName, firstName); // This will cause a compilation error
Print(email, lastName); // This will cause a compilation error
Print("Michael", "Smith"); // This will cause a compilation error
```



In addition to providing strict typing, value types generated by StrictlyTyped also implement type converters and serializers. This means you can transparently use these types at the edges of your application, for example in the action methods of an ASP.NET application.

By using StrictlyTyped, you can make your code more robust and easier to work with, even as it grows and changes over time.
