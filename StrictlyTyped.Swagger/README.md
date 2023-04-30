﻿Strictly Typed
==============

# What is it?

Strictly Typed is a library of interfaces and extensions that allow developers to strictly type simple primitive values. 
Using strictly typed values eliminates certain classes of errors and potential bugs from code. You can't mix up two `Guid`
arguments to a method if they are of different types! You can also implement domain-specific functionality on types, or
allow conversions or other operations, such as making it impossible to add `NumberOfDays` to `NumberOfPlanets` because
those operations are meaningless. Note that if you want that operation, you can add it (by implementing, say, `public static Z operator +(X left, Y right)`).
But by default, that sort of thing just doesn't happen.

This package adds basic support for Swagger, so Swagger can generate API documentation without getting confused by the types.
It is used like this:
``` csharp
builder.Services.AddSwaggerGen(c =>
{
    c.UseStrictTypesDefinedIn(Assembly.GetExecutingAssembly()); // Assuming this is the assembly where the types are generated
    c.EnableAnnotations();
});
```


# What do I do with it?

This library is intended to be used with the Strictly Typed Generator (not included in this package), which generates strictly 
typed immutable value record structs from stubs annotated with marker Attributes.

For example, the Generator will generate an Employee Id type from this stub:

``` csharp
[StrictGuid] public partial record struct EmployeeId;
```

Note that the part you write must be `partial`, the Source Generator will implement the rest.

The namespace will be preserved, as will any enclosing types (`static` or non-`static`). Note that any enclosing types
must also be `partial`, lest you anger Roslyn by causing the Source Generator to generate conflicting non-`partial` types.
like so:

``` csharp
public static partial class Employee
{
    [StrictGuid] public partial record struct Id;
}
```

This will generate a strictly typed `Guid` of type `Employee.Id`.

These types implement a `TypeConverter`, so they will convert transparently to and from primitive types for, say, ASP .Net
model binding for action methods. They also serialize and deserialize to and from Json transparently using `System.Text.Json`,
so if , say, your web client application uses javascript in AJAX it is not necessary to do any conversions. The serialization 
and deserialization will take care of mapping the strict types to the correct primitive types.

# But I want more control over my values!

These strict types use `partial` methods to provide options for manipulating values and validating them. For example, 

``` csharp
[StrictGuid]
public partial record struct HasAnOverriddenToString
{
    static partial void _overrideToString(Guid value, ref string result)
    {
        result = $"Overridden {value}";
    }
}
```

This will cause the `HasAnOverriddenToString`'s ToString() method to return `Overridden 7240837c-757e-4c02-b592-28b7c24132c6` for a value that
contains the `Guid` `7240837c-757e-4c02-b592-28b7c24132c6`.

There are other `partial` methods which can be implemented, depending on the wrapped primitive type. For example, the `StrictGuid` types allow
overrides for the following:

``` csharp
/// <summary>
/// If implemented, the wrapped value will be preprocessed by this method before creation
/// Preprocessing runs before validation (if implemented)
/// </summary>
/// <param name="value">The value which is to be preprocessed</param>
static partial void _preprocess(ref global::System.Guid result);

/// <summary>
/// If implemented, the result of calling CompareTo on the wrapped value will be modified by this method
/// </summary>
/// <param name="result">The value which will be returned by CompareTo</param>
partial void _overrideEquals(AStrictGuid? obj, ref global::System.Boolean result);

/// <summary>
/// If implemented, the result of calling ToString on the wrapped value will be modified by this method
/// </summary>
/// <param name="result">The value which will be returned by ToString</param>
static partial void _overrideToString(global::System.Guid value, ref global::System.String result);

/// <summary>
/// If implemented, the result of calling CompareTo on the wrapped value will be modified by this method
/// </summary>
/// <param name="result">The value which will be returned by CompareTo</param>
partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

/// <summary>
/// If implemented, this method will be used to check that the value is valid.
/// Validation runs after preprocessing (if implemented)
/// If errors contains any values validation will be considered to have failed.
/// (note that using the constructor, Create, or cast operators will not use this method)
/// </summary>
/// <param name="errors">A set of reasons why the value fails validation</param>
partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> errors);
```

# So once I've defined a type, how to I _get_ one of these values?
For `[StrictString] public partial record struct FirstName;`

**No Validation Or Preprocessing**
* Implicit cast (this is the most common one)
``` csharp
FirstName firstName = "Michael";
```
* Explicit cast
``` csharp
FirstName firstName = (FirstName)"Michael";
```
* `As` Extension
``` csharp
FirstName firstName = "Michael".As<FirstName>();
```
* `Create` static method
``` csharp
FirstName firstName = FirstName.Create("Michael");
```
* Constructor
``` csharp
FirstName firstName = new ("Michael");
```
**Preprocessing, No Validation**
* `From` static method
``` csharp
FirstName firstName = FirstName.From("Michael");
```
**Preprocessing and Validation**
* `TryAs` Extension (without validation result `out` parameter)
``` csharp
if ("Michael".TryAs(out FirstName result)) { /* ... */ }
```
* `TryAs` Extension (with validation result `out` parameter)
``` csharp
if ("Michael".TryAs(out FirstName result, out IReadOnlySet<string> failures)) { /* ... */ }
```
* `TryFrom` static method (without validation result `out` parameter)
``` csharp
if (FirstName.TryFrom("Michael", out FirstName result)) { /* ... */ }
```
* `TryFrom` static method (with validation result `out` parameter)
``` csharp
if (FirstName.TryFrom("Michael", out FirstName result, out IReadOnlySet<string> failures)) { /* ... */ }
```

Note that validation can always be performed on any instance by calling `.Validate()`
Yes, that's quite a few ways of getting values. I almost always use implicit cast or a `TryAs` extension, but testing with 
other developers has resulted in the varied ways to create values here. 

# What about JSON support?
These types serialize and deserialize exactly like the types they wrap. There are currently two leading
libraries that handle JSON support for C#.
`System.Text.Json`: This is supported by default.
`Newtsonsoft.Json`: This is supported, but you must add the following build symbol: 
* `USE_NEWTONSOFT_JSON`
You can add a build symbol through the Visual Studio package properties UI, or like this in the `.csproj` 
file.
* `<DefineConstants>$(DefineConstants);USE_NEWTONSOFT_JSON</DefineConstants>`

# Does this work with Swagger?
Yes, there's a separate package that adds support for Swagger (not included in this package).

# Does this work with Entity Framework?
Yes, there's a separate package that adds support for Entity Framework (not included in this package). The 
Source Generator also generates an `EFConverter` which you can enable in the declaring project by adding the 
`USE_EF_CORE` build symbol.

# No really, how do I use this?
Look in the Github repo (url) and you'll find there's an `Example` project that is a slight adaptation of
one of the simple Microsoft WebAPI tutorial projects.

# What is included?

* `StrictBool`
* `StrictByte`
* `StrictDecimal`
* `StrictDouble`
* `StrictFloat`
* `StrictHalf`
* `StrictInt`
* `StrictLong`
* `StrictSByte`
* `StrictShort`
* `StrictString`
* `StrictUInt`
* `StrictULong`
* `StrictUShort`

# What is not included (yet)?

The following are on my to-do list:

* `StrictDateTime`
* `StrictDateOnly`
* `StrictTimeOnly`
* `Strict<T>`

# Acknowledgements
This project has been heavily influenced by the code, articles, books, videos, blog posts, StackOverflow answers, and tutorials by (in no particular order)
* [Vladimir Khorikov](https://enterprisecraftsmanship.com/about)
* [Andrew Lock](https://andrewlock.net/about/)
* [Zoran Horvat](https://codinghelmet.com/articles)

In particular, Andrew Lock's excellent [Strongly Typed IDs](https://github.com/andrewlock/StronglyTypedId) project showed me how to 
solve the problem of Entity Framework forcing evaluation on the server rather than the database. The [blog post series](https://andrewlock.net/using-strongly-typed-entity-ids-to-avoid-primitive-obsession-part-1/) 
accompanying it helped file a lot of rough edges off my source generator project. I doubt I would have been able to finish without such 
a clear guide to making source generators work.

# Get in touch!
Contact the developer, "DMJ", at david.markham.jones@gmail.com