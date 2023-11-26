/// <summary>
/// Represents a strictly typed structure encapsulating a <see cref="System.Guid"/> value.
/// </summary>
/// <remarks>
/// <c>STRICT_TYPE</c> is a record struct that provides strict typing for a <see cref="System.Guid"/> value, 
/// ensuring type safety and clear semantics in the application. It implements the <see cref="global::StrictlyTyped.IStrictGuid{STRICT_TYPE}"/> 
/// interface, providing a standardized way to work with Guid values within a strict type system.
/// This struct is immutable and provides value equality semantics.
/// </remarks>
/// <seealso cref="global::StrictlyTyped.IStrictGuid{STRICT_TYPE}"/>
/// <example>
/// <code>
/// STRICT_TYPE strictGuid = Guid.NewGuid().As&lt;STRICT_TYPE&gt;();
/// Guid underlyingValue = strictGuid.Value;
/// // Use strictGuid and underlyingValue as needed
/// </code>
/// </example>
[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct STRICT_TYPE : global::StrictlyTyped.IStrictGuid<STRICT_TYPE>
{
    public global::System.Guid Value { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="STRICT_TYPE"/> struct using the specified <see cref="System.Guid"/> value.
    /// </summary>
    /// <remarks>
    /// This constructor creates a <see cref="STRICT_TYPE"/> instance with the provided <see cref="System.Guid"/> value. 
    /// It is a direct way to create a strict type instance from a Guid value.
    /// </remarks>
    /// <param name="value">
    /// The <see cref="System.Guid"/> value to initialize the <see cref="STRICT_TYPE"/> instance with.
    /// </param>
    /// <example>
    /// <code>
    /// Guid guidValue = Guid.NewGuid();
    /// STRICT_TYPE instance = new STRICT_TYPE(guidValue);
    /// // instance is now initialized with guidValue.
    /// </code>
    /// </example>
    public STRICT_TYPE(global::System.Guid value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="STRICT_TYPE"/> struct by parsing the specified string as a <see cref="System.Guid"/>.
    /// </summary>
    /// <remarks>
    /// This constructor parses the provided string to create a <see cref="System.Guid"/> and then initializes the <see cref="STRICT_TYPE"/> instance.
    /// It is useful for cases where the Guid value is represented as a string, such as when reading from text sources.
    /// </remarks>
    /// <param name="value">
    /// The string to parse as a <see cref="System.Guid"/> for initializing the <see cref="STRICT_TYPE"/> instance.
    /// </param>
    /// <exception cref="System.FormatException">
    /// Thrown when the string is not in a format compliant with <see cref="System.Guid"/>.
    /// </exception>
    /// <example>
    /// <code>
    /// string guidString = "d94f1e34-3803-4d23-aa6f-2b8daefdbfbd";
    /// STRICT_TYPE instance = new STRICT_TYPE(guidString);
    /// // instance is now initialized with the Guid parsed from guidString.
    /// </code>
    /// </example>
    public STRICT_TYPE(global::System.String value)
        : this(global::System.Guid.Parse(value))
    { }

    public static STRICT_TYPE From(global::System.Guid value)
    {
        return new STRICT_TYPE(value);
    }

    public global::System.Int32 CompareTo(global::System.Object? obj)
    {
        return Value.CompareTo(obj);
    }

    public global::System.Int32 CompareTo(STRICT_TYPE other)
    {
        return Value.CompareTo(other.Value);
    }

    /// <summary>
    /// Returns a string that represents the current strict type instance.
    /// </summary>
    /// <remarks>
    /// This method overrides <see cref="object.ToString"/> to provide a string representation 
    /// of the instance. It typically returns a string that 
    /// reflects the underlying value in a human-readable format, making it useful for debugging 
    /// and logging purposes.
    /// </remarks>
    /// <returns>
    /// A string representation of the current instance.
    /// </returns>
    /// <example>
    /// <code>
    /// EmployeeId instance = EmployeeId.New();
    /// string stringValue = instance.ToString();
    /// // stringValue is the string representation of instance.
    /// </code>
    /// </example>
    public override global::System.String ToString()
    {
        return Value.ToString();
    }

    public global::System.String ToString([global::System.Diagnostics.CodeAnalysis.StringSyntax("GuidFormat")] global::System.String? format)
    {
        return Value.ToString(format);
    }
    
    public global::System.String ToString([global::System.Diagnostics.CodeAnalysis.StringSyntax("GuidFormat")] global::System.String? format, global::System.IFormatProvider? formatProvider)
    {
        return Value.ToString(format, formatProvider);
    }

    public global::System.Boolean TryFormat(global::System.Span<global::System.Char> destination, out global::System.Int32 charsWritten, global::System.ReadOnlySpan<char> format, global::System.IFormatProvider? _)
    {
        return Value.TryFormat(destination, out charsWritten, format);
    }

    public static STRICT_TYPE Parse(global::System.String s, global::System.IFormatProvider? provider)
    {
        return From(global::System.Guid.Parse(s, provider));
    }

    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, out STRICT_TYPE result)
    {
        if (global::System.Guid.TryParse(s, provider, out var value))
        {
            result = From(value);
            return true;
        }

        result = default!;
        return false;
    }

    public static STRICT_TYPE Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider)
    {
        return From(global::System.Guid.Parse(s, provider));
    }

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, out STRICT_TYPE result)
    {
        if (global::System.Guid.TryParse(s, provider, out var value))
        {
            result = From(value);
            return true;
        }

        result = default!;
        return false;
    }

    public static STRICT_TYPE New()
    {
        return From(global::System.Guid.NewGuid());
    }

    public static STRICT_TYPE Empty { get; } = new(global::System.Guid.Empty);
    
    public static global::System.Boolean TryParse(global::System.String? s, out STRICT_TYPE result)
    {
        if (global::System.Guid.TryParse(s, out var r))
        {
            result = From(r);
            return true;
        }

        result = default!;
        return false;
    }

    public static STRICT_TYPE Parse(global::System.String? s)
    {
        return From(global::System.Guid.Parse(s!));
    }
    
    public static global::System.Boolean operator ==(STRICT_TYPE? left, global::System.Guid? right)
    {
        return !left.HasValue 
            ? !right.HasValue
            : right.HasValue && left.Value.Value == right;
    }

    public static global::System.Boolean operator !=(STRICT_TYPE? left, global::System.Guid? right)
    {
        return !(left == right);
    }

    public static global::System.Boolean operator ==(global::System.Guid? left, STRICT_TYPE? right)
    {
        return !left.HasValue
            ? !right.HasValue
            : right.HasValue && left == right.Value.Value;
    }

    public static global::System.Boolean operator !=(global::System.Guid? left, STRICT_TYPE? right)
    {
        return !(left == right);
    }
    
    private class Converter : global::StrictlyTyped.StrictTypeConverter<STRICT_TYPE, global::System.Guid> { }
    
    private sealed class SystemJsonConverter : global::StrictlyTyped.StrictSystemJsonConverter<STRICT_TYPE, global::System.Guid> { }

#if (USE_EF_CORE)
    public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<STRICT_TYPE, global::System.Guid>
    {
        public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
            : base(id => id.Value, value => new(value), mappingHints)
        { }
    }
#endif

#if (USE_NEWTONSOFT_JSON)
    public class NewtonsoftJsonConverter : global::Newtonsoft.Json.JsonConverter<STRICT_TYPE>
    {
        private static global::Newtonsoft.Json.JsonSerializer? _baseSerializer;
        public override STRICT_TYPE ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, STRICT_TYPE existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
            new ((_baseSerializer ??= new()).Deserialize<global::System.Guid>(reader));

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, STRICT_TYPE value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            (_baseSerializer ??= new()).Serialize(writer, value.Value);
    }
#endif
}