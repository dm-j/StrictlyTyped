[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct STRICT_TYPE : global::StrictlyTyped.IStrictBool<STRICT_TYPE>
{
    /// <summary>
    /// Gets the <see cref="global::System.Boolean"/> value of the <see cref="STRICT_TYPE"/> struct.
    /// </summary>
    [global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute]
    public required readonly global::System.Boolean Value { get; init; }

    /// <summary>
    /// Gets the value of the <see langword="true"/> instance of <see cref="STRICT_TYPE"/>.
    /// </summary>
    public static STRICT_TYPE True => _true;
    private static readonly STRICT_TYPE _true = new(true);

    /// <summary>
    /// Gets the value of the <see langword="false"/> instance of <see cref="STRICT_TYPE"/>.
    /// </summary>
    public static STRICT_TYPE False => _false;
    private static readonly STRICT_TYPE _false = new(false);

    /// <summary>
    /// Gets a value indicating whether the current <see cref="STRICT_TYPE"/> object represents a <see langword="true"/> value.
    /// </summary>
    public bool IsTrue => Value;

    /// <summary>
    /// Gets a value indicating whether the current <see cref="STRICT_TYPE"/> object represents a <see langword="false"/> value.
    /// </summary>
    public bool IsFalse => !Value;

    /// <summary>
    /// Implicitly converts a <see cref="STRICT_TYPE"/> to a <see cref="global::System.Boolean"/>.
    /// </summary>
    /// <param name="value">The <see cref="STRICT_TYPE"/> to convert.</param>
    /// <returns>The <see cref="global::System.Boolean"/> equivalent to the <see cref="STRICT_TYPE"/>.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Boolean(STRICT_TYPE value) =>
        value.Value;

    /// <summary>
    /// Implicitly converts a <see cref="global::System.Boolean"/> to a <see cref="STRICT_TYPE"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> to convert.</param>
    /// <returns>The <see cref="STRICT_TYPE"/> equivalent to the <see cref="global::System.Boolean"/>.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator STRICT_TYPE(global::System.Boolean value) =>
        new(value);

    /// <summary>
    /// Implicitly converts a nullable <see cref="STRICT_TYPE"/> to a nullable <see cref="global::System.Boolean"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="STRICT_TYPE"/> to convert.</param>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Boolean?(STRICT_TYPE? value) =>
        value.HasValue ? value.Value.Value : null;

    /// <summary>
    /// Implicitly converts a nullable <see cref="global::System.Boolean"/> to a <see cref="STRICT_TYPE"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="global::System.Boolean"/> to convert.</param>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator STRICT_TYPE?(global::System.Boolean? value) =>
        value.HasValue ? new(value.Value) : null;

    /// <summary>
    /// Initializes a new instance of the <see cref="STRICT_TYPE"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value to use as the underlying value of the <see cref="STRICT_TYPE"/> struct.</param>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public STRICT_TYPE([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] global::System.Boolean value)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether this instance and another specified <see cref="STRICT_TYPE"/> object have the
    /// same value.
    /// </summary>
    /// <param name="other">The <see cref="STRICT_TYPE"/> object to compare to this instance.</param>
    /// <returns>
    /// <see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as
    /// the value of this instance; otherwise, <see langword="false"/>.
    /// </returns>
    [global::System.Diagnostics.Contracts.Pure]
    public bool Equals(STRICT_TYPE? other)
    {
        bool result = Value.Equals(other?.Value);
        return result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="STRICT_TYPE"/> class with the specified value.
    /// </summary>
    /// <param name="value">A boolean value to be assigned to the new instance.</param>
    /// <returns>A new instance of the <see cref="STRICT_TYPE"/> class with the specified value.</returns>
    public static STRICT_TYPE Create(global::System.Boolean value) =>
        new(value);

    /// <summary>
    /// Converts the <see cref="global::System.String"/> representation of a <see cref="STRICT_TYPE"/> value to its corresponding <see cref="STRICT_TYPE"/> object.
    /// </summary>
    /// <param name="s">The <see cref="global::System.String"/> to parse.</param>
    /// <returns>A new <see cref="STRICT_TYPE"/> object that represents the value parsed from the input <see cref="global::System.String"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.String? s) =>
        new(global::System.Boolean.Parse(s!));

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<char> s, global::System.IFormatProvider? _, out STRICT_TYPE result)
    {
        if (global::System.Boolean.TryParse(s, out var r))
        {
            result = new(r);
            return true;
        }
        result = default;
        return false;
    }

    /// <summary>
    /// Converts the specified <see cref="global::System.ReadOnlySpan{global::System.Char}"/> of characters to an instance of the <see cref="STRICT_TYPE"/> struct.
    /// </summary>
    /// <param name="s">The <see cref="global::System.ReadOnlySpan{global::System.Char}"/> of characters to parse.</param>
    /// <returns>An instance of the <see cref="STRICT_TYPE"/> struct that represents the parsed value.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.ReadOnlySpan<global::System.Char> s) =>
        new(global::System.Boolean.Parse(s));

    /// <summary>
    /// Converts the string representation of a <see cref="global::System.Boolean"/> value to its <see cref="STRICT_TYPE"/> equivalent.
    /// A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A string containing a <see cref="global::System.Boolean"/> value to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="STRICT_TYPE"/> equivalent of the boolean value contained in <paramref name="s"/>, 
    /// if the conversion succeeded, or the default value of <see cref="STRICT_TYPE"/> if the conversion failed. 
    /// The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or is not a valid <see cref="global::System.Boolean"/> value.</param>
    /// <returns>
    /// <see langword="true"/> if the conversion succeeded; otherwise, <see langword="false"/>.
    /// </returns>
    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result) =>
        TryParse(s, null, out result);

    /// <summary>
    /// Compares this instance to a specified object and returns an indication of their relative values.
    /// </summary>
    /// <param name="obj">An object to compare, or <see langword="null"/>.</param>
    /// <returns>A signed integer that indicates the relative values of this instance and the <paramref name="obj"/> parameter.</returns>
    /// <exception cref="global::System.ArgumentException">Thrown when the <paramref name="obj"/> parameter is not of type <see cref="STRICT_TYPE"/>.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(global::System.Object? obj)
    {
        return obj switch
        {
            null => 1,
            STRICT_TYPE v => CompareTo(v),
            _ => throw new global::System.ArgumentException("Object must be of type STRICT_TYPE.", nameof(obj)),
        };
    }

    /// <summary>
    /// Compares this instance to a specified instance of <see cref="STRICT_TYPE"/> and returns an indication of their relative values.
    /// </summary>
    /// <param name="other">An instance of <see cref="STRICT_TYPE"/> to compare</param>
    /// <returns>A <see cref="global::System.Int32"/> that indicates the relative values of this instance and the <paramref name="other"/> parameter.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(STRICT_TYPE other)
    {
        var result = Value.CompareTo(other.Value);
        return result;
    }

    /// <summary>
    /// Returns a <see cref="global::System.String"/> representation of the current instance.
    /// </summary>
    /// <remarks>
    /// The <see cref="global::System.String"/> returned by this method can be customized by overriding the
    /// <see cref="_overrideToString"/> method.
    /// </remarks>
    /// <returns>A <see cref="global::System.String"/> representation of the current instance.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.String ToString()
    {
        global::System.String s = Value.ToString();
        _overrideToString(Value, ref s);
        return s;
    }

    /// <summary>
    /// Tries to format the value of the current instance into the provided <see cref="global::System.ReadOnlySpan{global::System.Char}"/>.
    /// </summary>
    /// <param name="destination">
    /// When this method returns, contains the formatted value of the current instance.
    /// </param>
    /// <param name="charsWritten">
    /// When this method returns, contains the number of characters written to the <paramref name="destination"/> <see cref="global::System.ReadOnlySpan{global::System.Char}"/>.
    /// </param>
    /// <param name="_">
    /// This parameter is ignored.
    /// </param>
    /// <returns>
    /// <see langword="true"> if the format operation was successful; otherwise, <see langword="false">.
    /// </returns>
    public global::System.Boolean TryFormat(global::System.Span<global::System.Char> destination, out global::System.Int32 charsWritten, global::System.ReadOnlySpan<global::System.Char> _) =>
        Value.TryFormat(destination, out charsWritten);

    /// <summary>
    /// Converts the specified <see cref="global::System.Boolean"/> value to the equivalent instance of <see cref="STRICT_TYPE"/>.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value to convert.</param>
    /// <returns>An instance of <see cref="STRICT_TYPE"/> that represents the converted <see cref="global::System.Boolean"/> value.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE From(global::System.Boolean value)
    {
        return new(value);
    }

    /// <summary>
    /// This method is a partial method that can be overriden to customize the behavior of the <see cref="ToString"/> method. 
    /// If overriden, it sets the string representation of the <see cref="STRICT_TYPE"/> instance created from a <see cref="global::System.Boolean" /> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value used to create the  instance.</param>
    /// <param name="result">A reference to the string that will be used as the result of <see cref="ToString"/> method.</param>
    static partial void _overrideToString(global::System.Boolean value, ref global::System.String result);

    /// <summary>
    /// Tries to create a new instance of the <see cref="STRICT_TYPE"/> struct from a <see cref="global::System.Boolean"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value to convert into a <see cref="STRICT_TYPE"/> instance.</param>
    /// <param name="result">When this method returns, contains the <see cref="STRICT_TYPE"/> instance equivalent to the <paramref name="value"/>, if the conversion succeeded. Otherwise, the default value of <see cref="STRICT_TYPE"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"> if the conversion succeeded; otherwise, <see langword="false">.</returns>
    public static global::System.Boolean TryFrom(global::System.Boolean value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result)
    {
        var created = From(value);

        result = created;
        return true;
    }

    /// <summary>
    /// Converts the span of characters representing a <see cref="global::System.Boolean"/> value to its <see cref="STRICT_TYPE"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> to parse.</param>
    /// <param name="_">An unused <see cref="global::System.IFormatProvider"/> instance.</param>
    /// <returns>A new <see cref="STRICT_TYPE"/> object that corresponds to the <see cref="global::System.Boolean"/> value represented by <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">The format of <paramref name="s"/> is invalid.</exception>
    public static STRICT_TYPE Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? _) =>
        Create(global::System.Boolean.Parse(s));

    /// <summary>
    /// Converts the span of characters representing a <see cref="global::System.Boolean"/> value to its <see cref="STRICT_TYPE"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="global::System.String"/> to parse.</param>
    /// <param name="_">An unused <see cref="global::System.IFormatProvider"/> instance.</param>
    /// <returns>A new <see cref="STRICT_TYPE"/> object that corresponds to the <see cref="global::System.Boolean"/> value represented by <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">The format of <paramref name="s"/> is invalid.</exception>
    public static STRICT_TYPE Parse(global::System.String s, global::System.IFormatProvider? _) =>
        Create(global::System.Boolean.Parse(s));

    /// <summary>
    /// Tries to convert the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> representation of a <see cref="STRICT_TYPE"/> value to its <see cref="STRICT_TYPE"/> equivalent. A return value indicates
    /// whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> containing the characters to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="STRICT_TYPE"/> equivalent of the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> contained in <paramref name="s"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or contains a <see cref="global::System.String"/> that is not a valid <see cref="STRICT_TYPE"/> value. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result)
    {
        if (global::System.Boolean.TryParse(s, out var r))
        {
            result = From(r);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Tries to convert the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> representation of a <see cref="STRICT_TYPE"/> value to its <see cref="STRICT_TYPE"/> equivalent. A return value indicates
    /// whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> containing the characters to convert.</param>
    /// <param name="_">An object that supplies culture-specific formatting information. This parameter is ignored.</param>
    /// <param name="result">When this method returns, contains the <see cref="STRICT_TYPE"/> equivalent of the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> contained in <paramref name="s"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or contains a <see cref="global::System.String"/> that is not a valid <see cref="STRICT_TYPE"/> value. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? _, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result)
    {
        if (global::System.Boolean.TryParse(s, out var r))
        {
            result = From(r);
            return true;
        }

        result = default;
        return false;
    }

    /// <summary>
    /// Attempts to create a new instance of <see cref="STRICT_TYPE"/> from the specified <see cref="global::System.Boolean"/> <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="STRICT_TYPE"/> instance equivalent to the specified <paramref name="value"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if <paramref name="value"/> is not a valid representation of a <see cref="STRICT_TYPE"/> instance. This parameter is treated as uninitialized.</param>
    /// <param name="failures">When this method returns, contains a set of strings representing any failures encountered during the conversion. This parameter is treated as uninitialized.</param>
    /// <returns><see langword="true"/> if the conversion succeeded; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// This method returns <see langword="false"/> if the <paramref name="value"/> parameter is <see langword="null"/> or not a value which can be parsed to a <see cref="global::System.Boolean"/>. 
    /// <para>
    /// If the conversion fails, the <paramref name="result"/> parameter is set to <see langword="null"/> and the <paramref name="failures"/> parameter contains a set of strings representing any failures encountered during the conversion. Each string in the set provides information about a single failure.
    /// </para>
    /// </remarks>
    public static bool TryFrom(bool value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result, out IReadOnlySet<global::System.String> failures)
    {
        result = From(value);
        failures = new HashSet<global::System.String>();
        return true;
    }

    /// <summary>
    /// Applies the specified mapping function to the underlying <see cref="global::System.Boolean"/> value of the current <see cref="STRICT_TYPE"/> instance and returns the result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="map"/>.</typeparam>
    /// <param name="map">The mapping function to apply.</param>
    /// <returns>The result of applying <paramref name="map"/> to the underlying <see cref="global::System.Boolean"/> value of the current <see cref="STRICT_TYPE"/> instance.</returns>
    /// <remarks>
    /// This method is useful for transforming the underlying <see cref="global::System.Boolean"/> value of the current <see cref="STRICT_TYPE"/> instance into a value of a different type.
    /// </remarks>
    public TResult Map<TResult>(global::System.Func<global::System.Boolean, TResult> map) =>
        map(Value);

    /// <summary>
    /// Applies a mapping function to the underlying <see cref="global::System.Boolean"/> value, returning the result as a new strictly-typed value.
    /// </summary>
    /// <typeparam name="TResult">The type of the result of <paramref name="map"/>.</typeparam>
    /// <typeparam name="TStrictResult">The type of the result as a new strictly-typed value.</typeparam>
    /// <param name="map">The mapping function to apply to the underlying value.</param>
    /// <returns>A new strictly-typed value representing the result of <paramref name="map"/>.</returns>
    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.Boolean, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.Create(map(Value));

    public global::System.Boolean Validate(out global::System.Collections.Generic.IReadOnlyCollection<global::System.String> errors)
    {
        errors = new List<global::System.String>().AsReadOnly();

        return true;
    }

    public global::System.Boolean Validate() =>
        true;

    /// <summary>
    /// TypeConverter which converts to and from objects of type STRICT_TYPE
    /// </summary>
    private class Converter : global::StrictlyTyped.StrictTypeConverter<STRICT_TYPE, global::System.Boolean> { }

    /// <summary>
    /// A JsonConverter for System.Text.Json which converts STRICT_TYPE transparently to and from Json representations
    /// </summary>
    private sealed class SystemJsonConverter : global::StrictlyTyped.StrictSystemJsonConverter<STRICT_TYPE, global::System.Boolean> { }

#if (USE_EF_CORE)
    private class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<STRICT_TYPE, global::System.Boolean>
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
    private class NewtonsoftJsonConverter : global::Newtonsoft.Json.JsonConverter<STRICT_TYPE>
    {
        private readonly global::Newtonsoft.Json.JsonSerializer _baseSerializer = new();
        public override STRICT_TYPE ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, STRICT_TYPE existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
            new (_baseSerializer.Deserialize<global::System.Boolean>(reader));

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, STRICT_TYPE value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            _baseSerializer.Serialize(writer, value.Value);
    }
#endif
}