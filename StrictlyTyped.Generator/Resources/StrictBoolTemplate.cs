using System;
/// <summary>
/// Represents a strictly-typed record struct for a <see cref="global::System.Boolean"/> value
/// </summary>
/// <remarks>
/// This struct is immutable and can be used for performance-sensitive scenarios that require type
/// safety and minimal allocations. It implements the <see cref="global::StrictlyTyped.IStrictBool{T}"/>
/// interface for strict typing and can be used with the <see cref="global::StrictlyTyped"/> library.
/// </remarks>
[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct ZYX : global::StrictlyTyped.IStrictBool<ZYX>
{
    /// <summary>
    /// Gets the <see cref="global::System.Boolean"/> value of the <see cref="ZYX"/> struct.
    /// </summary>
    public required readonly global::System.Boolean Value { get; init; }

    /// <summary>
    /// Gets the value of the <see langword="true"/> instance of <see cref="ZYX"/>.
    /// </summary>
    public static ZYX True => _true;
    private static readonly ZYX _true = new(true);

    /// <summary>
    /// Gets the value of the <see langword="false"/> instance of <see cref="ZYX"/>.
    /// </summary>
    public static ZYX False => _false;
    private static readonly ZYX _false = new(false);

    /// <summary>
    /// Gets a value indicating whether the current <see cref="ZYX"/> object represents a <see langword="true"/> value.
    /// </summary>
    public bool IsTrue => Value;

    /// <summary>
    /// Gets a value indicating whether the current <see cref="ZYX"/> object represents a <see langword="false"/> value.
    /// </summary>
    public bool IsFalse => !Value;

    /// <summary>
    /// Implicitly converts a <see cref="ZYX"/> to a <see cref="global::System.Boolean"/>.
    /// </summary>
    /// <param name="value">The <see cref="ZYX"/> to convert.</param>
    /// <returns>The <see cref="global::System.Boolean"/> equivalent to the <see cref="ZYX"/>.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Boolean(ZYX value) =>
        value.Value;

    /// <summary>
    /// Implicitly converts a <see cref="global::System.Boolean"/> to a <see cref="ZYX"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> to convert.</param>
    /// <returns>The <see cref="ZYX"/> equivalent to the <see cref="global::System.Boolean"/>.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX(global::System.Boolean value) =>
        new(value);

    /// <summary>
    /// Implicitly converts a nullable <see cref="ZYX"/> to a nullable <see cref="global::System.Boolean"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="ZYX"/> to convert.</param>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Boolean?(ZYX? value) =>
        value.HasValue ? value.Value.Value : null;

    /// <summary>
    /// Implicitly converts a nullable <see cref="global::System.Boolean"/> to a <see cref="ZYX"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="global::System.Boolean"/> to convert.</param>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX?(global::System.Boolean? value) =>
        value.HasValue ? new(value.Value) : null;

    /// <summary>
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.Boolean value)
    {
        Value = value;
    }

    /// <summary>
    /// Determines whether this instance and another specified <see cref="ZYX"/> object have the
    /// same value.
    /// </summary>
    /// <param name="other">The <see cref="ZYX"/> object to compare to this instance.</param>
    /// <returns>
    /// <see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as
    /// the value of this instance; otherwise, <see langword="false"/>.
    /// </returns>
    [global::System.Diagnostics.Contracts.Pure]
    public bool Equals(ZYX? other)
    {
        bool result = Value.Equals(other?.Value);
        return result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ZYX"/> class with the specified value.
    /// </summary>
    /// <param name="value">A boolean value to be assigned to the new instance.</param>
    /// <returns>A new instance of the <see cref="ZYX"/> class with the specified value.</returns>
    public static ZYX Create(global::System.Boolean value) =>
        new(value);

    /// <summary>
    /// Converts the <see cref="global::System.String"/> representation of a <see cref="ZYX"/> value to its corresponding <see cref="ZYX"/> object.
    /// </summary>
    /// <param name="s">The <see cref="global::System.String"/> to parse.</param>
    /// <returns>A new <see cref="ZYX"/> object that represents the value parsed from the input <see cref="global::System.String"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String? s) =>
        new(global::System.Boolean.Parse(s!));

    /// <summary>
    /// Converts the specified <see cref="global::System.ReadOnlySpan{global::System.Char}"/> of characters to an instance of the <see cref="ZYX"/> struct.
    /// </summary>
    /// <param name="s">The <see cref="global::System.ReadOnlySpan{global::System.Char}"/> of characters to parse.</param>
    /// <returns>An instance of the <see cref="ZYX"/> struct that represents the parsed value.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.ReadOnlySpan<global::System.Char> s) =>
        new(global::System.Boolean.Parse(s));

    /// <summary>
    /// Converts the string representation of a <see cref="global::System.Boolean"/> value to its <see cref="ZYX"/> equivalent.
    /// A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="s">A string containing a <see cref="global::System.Boolean"/> value to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> equivalent of the boolean value contained in <paramref name="s"/>, 
    /// if the conversion succeeded, or the default value of <see cref="ZYX"/> if the conversion failed. 
    /// The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or is not a valid <see cref="global::System.Boolean"/> value.</param>
    /// <returns>
    /// <see langword="true"/> if the conversion succeeded; otherwise, <see langword="false"/>.
    /// </returns>
    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result) =>
        TryParse(s, null, out result);

    /// <summary>
    /// Compares this instance to a specified object and returns an indication of their relative values.
    /// </summary>
    /// <param name="obj">An object to compare, or <see langword="null"/>.</param>
    /// <returns>A signed integer that indicates the relative values of this instance and the <paramref name="obj"/> parameter.</returns>
    /// <exception cref="global::System.ArgumentException">Thrown when the <paramref name="obj"/> parameter is not of type <see cref="ZYX"/>.</exception>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(global::System.Object? obj)
    {
        return obj switch
        {
            null => 1,
            ZYX v => CompareTo(v),
            _ => throw new global::System.ArgumentException("Object must be of type ZYX.", nameof(obj)),
        };
    }

    /// <summary>
    /// Compares this instance to a specified instance of <see cref="ZYX"/> and returns an indication of their relative values.
    /// </summary>
    /// <param name="other">An instance of <see cref="ZYX"/> to compare</param>
    /// <returns>A <see cref="global::System.Int32"/> that indicates the relative values of this instance and the <paramref name="other"/> parameter.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(ZYX other)
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
    /// Converts the specified <see cref="global::System.Boolean"/> value to the equivalent instance of <see cref="ZYX"/>.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value to convert.</param>
    /// <returns>An instance of <see cref="ZYX"/> that represents the converted <see cref="global::System.Boolean"/> value.</returns>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX From(global::System.Boolean value)
    {
        return new(value);
    }

    /// <summary>
    /// This method is a partial method that can be overriden to customize the behavior of the <see cref="ToString"/> method. 
    /// If overriden, it sets the string representation of the <see cref="ZYX"/> instance created from a <see cref="global::System.Boolean" /> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value used to create the  instance.</param>
    /// <param name="result">A reference to the string that will be used as the result of <see cref="ToString"/> method.</param>
    static partial void _overrideToString(global::System.Boolean value, ref global::System.String result);

    /// <summary>
    /// Tries to create a new instance of the <see cref="ZYX"/> struct from a <see cref="global::System.Boolean"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> value to convert into a <see cref="ZYX"/> instance.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> instance equivalent to the <paramref name="value"/>, if the conversion succeeded. Otherwise, the default value of <see cref="ZYX"/>. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"> if the conversion succeeded; otherwise, <see langword="false">.</returns>
    public static global::System.Boolean TryFrom(global::System.Boolean value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result)
    {
        var created = From(value);

        result = created;
        return true;
    }

    /// <summary>
    /// Converts the span of characters representing a <see cref="global::System.Boolean"/> value to its <see cref="ZYX"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> to parse.</param>
    /// <param name="_">An unused <see cref="global::System.IFormatProvider"/> instance.</param>
    /// <returns>A new <see cref="ZYX"/> object that corresponds to the <see cref="global::System.Boolean"/> value represented by <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">The format of <paramref name="s"/> is invalid.</exception>
    public static ZYX Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? _) =>
        Create(global::System.Boolean.Parse(s));

    /// <summary>
    /// Converts the span of characters representing a <see cref="global::System.Boolean"/> value to its <see cref="ZYX"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="global::System.String"/> to parse.</param>
    /// <param name="_">An unused <see cref="global::System.IFormatProvider"/> instance.</param>
    /// <returns>A new <see cref="ZYX"/> object that corresponds to the <see cref="global::System.Boolean"/> value represented by <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">The format of <paramref name="s"/> is invalid.</exception>
    public static ZYX Parse(global::System.String s, global::System.IFormatProvider? _) =>
        Create(global::System.Boolean.Parse(s));

    /// <summary>
    /// Tries to convert the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> representation of a <see cref="ZYX"/> value to its <see cref="ZYX"/> equivalent. A return value indicates
    /// whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> containing the characters to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> equivalent of the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> contained in <paramref name="s"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or contains a <see cref="global::System.String"/> that is not a valid <see cref="ZYX"/> value. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
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
    /// Tries to convert the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> representation of a <see cref="ZYX"/> value to its <see cref="ZYX"/> equivalent. A return value indicates
    /// whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="global::System.ReadOnlySpan{global::System.Char}"/> containing the characters to convert.</param>
    /// <param name="_">An object that supplies culture-specific formatting information. This parameter is ignored.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> equivalent of the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> contained in <paramref name="s"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or contains a <see cref="global::System.String"/> that is not a valid <see cref="ZYX"/> value. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? _, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
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
    /// Attempts to create a new instance of <see cref="ZYX"/> from the specified <see cref="global::System.Boolean"/> <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Boolean"/> to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> instance equivalent to the specified <paramref name="value"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if <paramref name="value"/> is not a valid representation of a <see cref="ZYX"/> instance. This parameter is treated as uninitialized.</param>
    /// <param name="failures">When this method returns, contains a set of strings representing any failures encountered during the conversion. This parameter is treated as uninitialized.</param>
    /// <returns><see langword="true"/> if the conversion succeeded; otherwise, <see langword="false"/>.</returns>
    /// <remarks>
    /// This method returns <see langword="false"/> if the <paramref name="value"/> parameter is <see langword="null"/> or not a value which can be parsed to a <see cref="global::System.Boolean"/>. 
    /// <para>
    /// If the conversion fails, the <paramref name="result"/> parameter is set to <see langword="null"/> and the <paramref name="failures"/> parameter contains a set of strings representing any failures encountered during the conversion. Each string in the set provides information about a single failure.
    /// </para>
    /// </remarks>
    public static bool TryFrom(bool value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result, out IReadOnlySet<global::System.String> failures)
    {
        result = From(value);
        failures = new HashSet<global::System.String>();
        return true;
    }

    /// <summary>
    /// Applies the specified mapping function to the underlying <see cref="global::System.Boolean"/> value of the current <see cref="ZYX"/> instance and returns the result.
    /// </summary>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="map"/>.</typeparam>
    /// <param name="map">The mapping function to apply.</param>
    /// <returns>The result of applying <paramref name="map"/> to the underlying <see cref="global::System.Boolean"/> value of the current <see cref="ZYX"/> instance.</returns>
    /// <remarks>
    /// This method is useful for transforming the underlying <see cref="global::System.Boolean"/> value of the current <see cref="ZYX"/> instance into a value of a different type.
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

    /// <summary>
    /// TypeConverter which converts to and from objects of type ZYX
    /// </summary>
    private class Converter : global::System.ComponentModel.TypeConverter
    {
        private static readonly global::System.ComponentModel.TypeConverter _baseConverter;

        static Converter()
        {
            _baseConverter = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::System.Boolean));
        }

        public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type sourceType) =>
            _baseConverter.CanConvertFrom(context, sourceType) || sourceType == typeof(ZYX);

        public override global::System.Boolean CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? destinationType) =>
            _baseConverter.CanConvertTo(context, destinationType) || destinationType == typeof(ZYX);

        public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object value) =>
            new ZYX((global::System.Boolean?)_baseConverter.ConvertFrom(context, culture, value));

        public override global::System.Object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type destinationType)
        {
            var sourceType = value.GetType();
            if (value is null)
                return null;
            else if (sourceType == typeof(ZYX))
                return (ZYX)value;
            else if (_baseConverter.CanConvertFrom(sourceType) && _baseConverter.CanConvertTo(destinationType))
                return ZYX.Create((global::System.Boolean)_baseConverter.ConvertTo(value, typeof(global::System.Boolean)));
            throw new global::System.InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to {nameof(ZYX)}>");
        }
    }

    /// <summary>
    /// A JsonConverter for System.Text.Json which converts ZYX transparently to and from Json representations
    /// </summary>
    public class SystemJsonConverter : global::System.Text.Json.Serialization.JsonConverter<ZYX>
    {
        private readonly global::System.Text.Json.Serialization.JsonConverter<global::System.Boolean> _valueConverter;

        public SystemJsonConverter(global::System.Text.Json.JsonSerializerOptions options)
        {
            _valueConverter = (global::System.Text.Json.Serialization.JsonConverter<global::System.Boolean>)options.GetConverter(typeof(global::System.Boolean));
        }

        public override ZYX Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return ZYX.Create(_valueConverter.Read(ref reader, typeToConvert, options));
        }

        public override void Write(global::System.Text.Json.Utf8JsonWriter writer, ZYX value, global::System.Text.Json.JsonSerializerOptions options)
        {
            _valueConverter.Write(writer, value.Value, options);
        }
    }

#if (USE_EF_CORE)
    public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ZYX, global::System.Boolean>
    {
        public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
            : base(id => id.Value, value => Create(value), mappingHints)
        { }
    }
#endif

#if (USE_NEWTONSOFT_JSON)
    /// <summary>
    /// A JsonConverter for Newtonsoft.Json which converts ZYX transparently to and from Json representations
    /// </summary>
    public class NewtonsoftJsonConverter : global::Newtonsoft.Json.JsonConverter<ZYX>
    {
        private readonly global::Newtonsoft.Json.JsonSerializer _baseSerializer = new();
        public override ZYX ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, ZYX existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
            new (_baseSerializer.Deserialize<global::System.Boolean>(reader));

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, ZYX<TTimeZone> value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            _baseSerializer.Serialize(writer, value.Value);
    }
#endif
}