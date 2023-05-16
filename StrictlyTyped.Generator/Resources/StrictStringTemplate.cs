/// <summary>
/// Represents a Strictly-typed record struct for a string value
/// </summary>
/// <remarks>
/// This struct is immutable and can be used for performance-sensitive scenarios that require
/// type safety and minimal allocations. It implements the <see cref="global::StrictlyTyped.IStrictString{T}"/> interface
/// for Strict typing and can be used with the <see cref="global::StrictlyTyped"/> library.
/// </remarks>
[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct STRICT_TYPE : global::StrictlyTyped.IStrictString<STRICT_TYPE>
{
    /// <summary>
    /// Gets the value of the STRICT_TYPE struct.
    /// </summary>
    [global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute]
    public required readonly global::System.String Value { get; init; }

    private static readonly STRICT_TYPE _empty = new(global::System.String.Empty);
    public static STRICT_TYPE Empty => _empty;

    /// <summary>
    /// Converts a <see cref="STRICT_TYPE"/> value to an <see cref="global::System.String"/> value.
    /// </summary>
    /// <param name="value">The <see cref="STRICT_TYPE"/> value to convert.</param>
    /// <returns>The <see cref="global::System.String"/> value that represents the converted <see cref="STRICT_TYPE"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.String(STRICT_TYPE value) =>
        value.Value;

    /// <summary>
    /// Converts an <see cref="global::System.String"/> value to a <see cref="STRICT_TYPE"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.String"/> value to convert.</param>
    /// <returns>A new <see cref="STRICT_TYPE"/> value that represents the converted <see cref="global::System.String"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator STRICT_TYPE(global::System.String value) =>
        new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="STRICT_TYPE"/> struct with the specified value.
    /// </summary>
    /// <param name="value">Thevalue to use as the underlying value of the <see cref="STRICT_TYPE"/> struct.</param>
    /// <exception cref="global::System.ArgumentNullException"><paramref name="value"/> is <see langword="null"/>.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public STRICT_TYPE([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] global::System.String value)
    {
        global::System.ArgumentNullException.ThrowIfNull(value);
        Value = value;
    }

    public static bool operator ==(STRICT_TYPE left, global::System.String? right) =>
        left.Value.ToString() == right;

    public static bool operator !=(STRICT_TYPE left, global::System.String? right) =>
        !(left == right);

    public static bool operator ==(global::System.String? left, STRICT_TYPE right) =>
        right == left;

    public static bool operator !=(global::System.String? left, STRICT_TYPE right) =>
        !(right == left);

    public override global::System.Int32 GetHashCode() =>
        Value.GetHashCode();

    public global::System.Int32 Length => Value.Length;

    /// <summary>
    /// Initializes a new instance of the <see cref="STRICT_TYPE"/> struct with the specified value.
    /// </summary>
    /// <param name="value">Thevalue to use as the underlying value of the <see cref="STRICT_TYPE"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    public static STRICT_TYPE Create(global::System.String value) =>
        new(value);

    /// <summary>
    /// Compares the current instance with another object and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">The object to compare with this instance.</param>
    /// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
    /// <remarks>
    /// <0: the current instance precedes the other object in the sort order.
    /// >0: the current instance follows the other object in the sort order.
    ///  0: the current instance occurs in the same position in the sort order as the other object.
    ///  </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(global::System.Object? obj)
    {
        var result = obj switch
        {
            null => 1,
            STRICT_TYPE v => CompareTo(v),
            _ => 1,
        };
        _overrideCompareTo(obj, ref result);
        return result;
    }

    /// <summary>
    /// Determines whether this instance and another specified <see cref="STRICT_TYPE"/> object have the same value.
    /// </summary>
    /// <param name="other">The <see cref="STRICT_TYPE"/> object to compare to this instance.</param>
    /// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as the value of this instance; otherwise, <see langword="false"/>.</returns>
    public bool Equals(STRICT_TYPE? other, StringComparison comparison)
    {
        bool result = Value.Equals(other?.Value, comparison);
        _overrideEquals(other, ref result);
        return result;
    }

    /// <summary>
    /// Determines whether this instance and another specified <see cref="STRICT_TYPE"/> object have the same value.
    /// </summary>
    /// <param name="other">The <see cref="STRICT_TYPE"/> object to compare to this instance.</param>
    /// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as the value of this instance; otherwise, <see langword="false"/>.</returns>
    /// 
    /// <remarks>This method can be overridden by implementing partial method <see cref="_overrideEquals"/></remarks>
    public bool Equals(STRICT_TYPE? other)
    {
        bool result = Value.Equals(other?.Value);
        _overrideEquals(other, ref result);
        return result;
    }

    /// <summary>
    /// Compares the current instance with another object and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
    /// </summary>
    /// <param name="other">The object to compare with this instance.</param>
    /// <returns>A 32-bit signed integer that indicates the relative order of the objects being compared.</returns>
    /// <remarks>
    /// <0: the current instance precedes the other object in the sort order.
    /// >0: the current instance follows the other object in the sort order.
    ///  0: the current instance occurs in the same position in the sort order as the other object.
    ///  This method can be overridden by implementing <see cref="_overrideCompareTo"/>
    ///  </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(STRICT_TYPE other)
    {
        var result = Value.CompareTo(other.Value);
        _overrideCompareTo(other, ref result);
        return result;
    }

    /// <summary>
    /// Returns the string representation of this <see cref="STRICT_TYPE"/> instance, using the default format specifier.
    /// </summary>
    /// <returns>A string representation of the value of this <see cref="STRICT_TYPE"/> instance.</returns>
    /// <remarks>
    /// This can be overridden by implementing the partial method <see cref="_overrideToString"/>
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.String ToString()
    {
        var s = Value;
        _overrideToString(Value, ref s);
        return s;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="STRICT_TYPE"/> struct from a value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>A new instance of <see cref="STRICT_TYPE"/> initialized to <paramref name="value"/></returns>
    /// <remarks>
    /// Preprocess <paramref name="value"/> before creating by implementing <see cref="_preprocess"/>
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE From(global::System.String value)
    {
        var s = value;
        _preprocess(ref s);
        return new(s);
    }

    /// <summary>
    /// If implemented, the wrapped value will be preprocessed by this method before creation
    /// Preprocessing runs before validation (if implemented)
    /// (note that using the constructor or cast operators will not use this method)
    /// </summary>
    /// <param name="value">The value which is to be preprocessed</param>
    static partial void _preprocess(ref global::System.String result);

    /// <summary>
    /// If implemented, the result of calling CompareTo on the wrapped value will be modified by this method
    /// </summary>
    /// <param name="result">The value which will be returned by CompareTo</param>
    partial void _overrideEquals(STRICT_TYPE? obj, ref global::System.Boolean result);

    /// <summary>
    /// If implemented, the result of calling ToString on the wrapped value will be modified by this method
    /// </summary>
    /// <param name="result">The value which will be returned by ToString</param>
    static partial void _overrideToString(global::System.String value, ref global::System.String result);

    /// <summary>
    /// If implemented, the result of calling CompareTo on the wrapped value will be modified by this method
    /// </summary>
    /// <param name="result">The value which will be returned by CompareTo</param>
    partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

    /// <summary>
    /// If implemented, this method will be used to check that the value is valid.
    /// Validation runs after preprocessing (if implemented)
    /// If errors contains any values validation will be considered to have failed.
    /// (note that using the constructor or cast operators will not use this method)
    /// </summary>
    /// <param name="errors">A set of reasons why the value fails validation</param>
    partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> errors);

    public static global::System.Boolean TryFrom(global::System.String value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result, out global::System.Collections.Generic.IReadOnlySet<global::System.String> failures)
    {
        global::System.Collections.Generic.HashSet<global::System.String> validationFailures = new();

        if (value is null)
        {
            validationFailures.Add($"Cannot create {typeof(STRICT_TYPE).FullName} from <null>");
            failures = validationFailures;
            result = default;
            return false;
        }

        var created = From(value);

        created._validate(ref validationFailures);

        if (validationFailures.Count > 0)
        {
            result = default;
            failures = validationFailures;
            return false;
        }

        result = created;
        failures = validationFailures;
        return true;
    }

    public static global::System.Boolean TryFrom(global::System.String value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result) =>
        TryFrom(value, out result, out _);

    public global::System.Boolean Validate(out global::System.Collections.Generic.IReadOnlyCollection<global::System.String> errors)
    {
        global::System.Collections.Generic.HashSet<global::System.String> problems = new();

        _validate(ref problems);

        errors = global::System.Linq.Enumerable.ToList(problems).AsReadOnly();

        return !errors.Any();
    }

    public global::System.Boolean Validate() =>
        Validate(out _);

    public TResult Map<TResult>(global::System.Func<global::System.String, TResult> map) =>
        map(Value);

    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.String, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.From(map(Value));

    /// <summary>
    /// TypeConverter which converts to and from objects of type STRICT_TYPE
    /// </summary>
    private class Converter : global::StrictlyTyped.StrictTypeConverter<STRICT_TYPE, global::System.String> { }

    /// <summary>
    /// A JsonConverter for System.Text.Json which converts STRICT_TYPE transparently to and from Json representations
    /// </summary>
    private sealed class SystemJsonConverter : global::StrictlyTyped.StrictSystemJsonConverter<STRICT_TYPE, global::System.String> { }

#if (USE_EF_CORE)
    public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<STRICT_TYPE, global::System.String>
    {
        public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
            : base(id => id.Value, value => Create(value), mappingHints)
        { }
    }
#endif

#if (USE_NEWTONSOFT_JSON)
    /// <summary>
    /// A JsonConverter for Newtonsoft.Json which converts STRICT_TYPE transparently to and from Json representations
    /// </summary>
    public class NewtonsoftJsonConverter : global::Newtonsoft.Json.JsonConverter<STRICT_TYPE>
    {
        private readonly global::Newtonsoft.Json.JsonSerializer _baseSerializer = new();
        public override STRICT_TYPE ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, STRICT_TYPE existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
            new (_baseSerializer.Deserialize<global::System.String>(reader)!);

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, STRICT_TYPE value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            _baseSerializer.Serialize(writer, value.Value);
    }
#endif
}