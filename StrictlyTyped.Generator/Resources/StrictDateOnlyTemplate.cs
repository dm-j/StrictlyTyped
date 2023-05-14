/// <summary>
/// Represents a Strictly-typed record struct for a DateOnly value
/// </summary>
/// <remarks>
/// This struct is immutable and can be used for performance-sensitive scenarios that require
/// type safety and minimal allocations. It implements the <see cref="global::StrictlyTyped.IStrictDateOnly{T}"/> interface
/// for Strict typing and can be used with the <see cref="global::StrictlyTyped"/> library.
/// </remarks>
[global::System.Diagnostics.DebuggerDisplay("{Value.Year}/{Value.Month}/{Value.Day}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct ZYX : global::StrictlyTyped.IStrictDateOnly<ZYX>
{
    /// <summary>
    /// Gets the value of the ZYX struct.
    /// </summary>
    public required readonly global::System.DateOnly Value { get; init; }

    /// <summary>
    /// Converts a <see cref="ZYX"/> value to an <see cref="global::System.DateOnly"/> value.
    /// </summary>
    /// <param name="value">The <see cref="ZYX"/> value to convert.</param>
    /// <returns>The <see cref="global::System.DateOnly"/> value that represents the converted <see cref="ZYX"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.DateOnly(ZYX value) =>
        value.Value;

    /// <summary>
    /// Converts an <see cref="global::System.DateOnly"/> value to a <see cref="ZYX"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateOnly"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX"/> value that represents the converted <see cref="global::System.DateOnly"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX(global::System.DateOnly value) =>
        new(value);

    /// <summary>
    /// Converts a <see cref="global::System.DateOnly"/> value to a <see cref="ZYX"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateOnly"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX"/> value that represents the converted <see cref="global::System.DateOnly"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.DateOnly?(ZYX? value) =>
        value.HasValue ? value.Value.Value : null;

    /// <summary>
    /// Converts a <see cref="global::System.DateOnly?"/> value to a <see cref="ZYX?"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateOnly"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX?"/> value that represents the converted <see cref="global::System.DateOnly"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX?(global::System.DateOnly? value) =>
        value.HasValue ? new(value.Value) : null;

    /// <summary>
    /// Converts an <see cref="global::System.DateTime"/> value to a <see cref="ZYX"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateTime"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX"/> value that represents the converted <see cref="global::System.DateTime"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX(global::System.DateTime value) =>
        new(value);

    /// <summary>
    /// Converts an <see cref="ZYX"/> value to a <see cref="global::System.DateTime"/> value.
    /// </summary>
    /// <param name="value">The <see cref="ZYX"/> value to convert.</param>
    /// <returns>A new <see cref="global::System.DateTime"/> value that represents the converted <see cref="ZYX"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.DateTime(ZYX value) =>
        value.ToDateTime();

    /// <summary>
    /// Converts a <see cref="global::System.DateTime"/> value to a <see cref="ZYX"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateTime"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX"/> value that represents the converted <see cref="global::System.DateTime"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.DateTime?(ZYX? value) =>
        value.HasValue ? value.Value.Value.ToDateTime(global::System.TimeOnly.MinValue) : null;

    /// <summary>
    /// Converts a <see cref="global::System.DateTime?"/> value to a <see cref="ZYX?"/> value.
    /// </summary>
    /// <param name="value">The <see cref="global::System.DateTime"/> value to convert.</param>
    /// <returns>A new <see cref="ZYX?"/> value that represents the converted <see cref="global::System.DateTime"/> value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX?(global::System.DateTime? value) =>
        value.HasValue ? new(value.Value) : null;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator >(ZYX left, ZYX right) =>
        left.CompareTo(right) > 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator >=(ZYX left, ZYX right) =>
        left.CompareTo(right) >= 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator <(ZYX left, ZYX right) =>
        left.CompareTo(right) < 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator <=(ZYX left, ZYX right) =>
        left.CompareTo(right) <= 0;

    /// <summary>
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.DateOnly value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the specified value.
    /// </summary>
    /// <param name="value">The value to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.DateTime value)
    {
        Value = global::System.DateOnly.FromDateTime(value);
    }

    /// <summary>
    /// Creates a new DateTime which represents this <see cref="ZYX"/>. 
    /// </summary>
    /// <param name="time">The time to use with the DateTime. If <see langword="null"/> it will return as close as possible to the date.</param>
    /// <returns>A DateTime representing this <see cref="ZYX"/></returns>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.DateTime ToDateTime(global::System.TimeOnly? time = null) =>
        Value.ToDateTime(time ?? global::System.TimeOnly.MinValue);

    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.Int32 GetHashCode() =>
        Value.GetHashCode();

    /// <summary>
    /// Determines whether this instance and another specified <see cref="ZYX"/> object have the same value.
    /// </summary>
    /// <param name="other">The <see cref="ZYX"/> object to compare to this instance.</param>
    /// <returns><see langword="true"/> if the value of the <paramref name="other"/> parameter is the same as the value of this instance; otherwise, <see langword="false"/>.</returns>
    /// <remarks>This method can be overridden by implementing partial method <see cref="_overrideEquals"/></remarks>
    public bool Equals(ZYX? other)
    {
        bool result = Value.Equals(other?.Value);
        _overrideEquals(other, ref result);
        return result;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the specified value.
    /// </summary>
    /// <param name="value">Thevalue to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    public static ZYX Create(global::System.DateOnly value) =>
        new(value);

    /// <summary>
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the specified value.
    /// </summary>
    /// <param name="value">Thevalue to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    public static ZYX Create(global::System.DateTime value) =>
        new(global::System.DateOnly.FromDateTime(value));

    /// <summary>
    /// Parses the string representation of a ZYX value.
    /// </summary>
    /// <param name="s">The string representation of the value to parse.</param>
    /// <returns>A new instance of the <see cref="ZYX"/> struct that represents the parsed value.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="s"/> is null.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String? s) =>
        global::System.DateOnly.TryParse(s!, out var v) ? new(v) : new(global::System.DateTime.Parse(s));

    /// <summary>
    /// Converts the span representation of a ZYX value to its <see cref="ZYX"/> equivalent.
    /// </summary>
    /// <param name="s">The span containing the characters to convert.</param>
    /// <returns>A new instance of <see cref="ZYX"/> equivalent to the value represented in <paramref name="s"/>.</returns>
    /// <exception cref="System.FormatException">Thrown when the string representation of the value is not in the correct format.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider) =>
        global::System.DateOnly.TryParse(s, out var v) ? new(v) : new(global::System.DateTime.Parse(s, provider));

    /// <summary>
    /// Converts the string representation of a value in a specified culture-specific format to its <see cref="ZYX"/> equivalent.
    /// </summary>
    /// <param name="s">A string that contains the number to convert.</param>
    /// <param name="provider">An object that provides culture-specific formatting information.</param>
    /// <returns>A <see cref="ZYX"/> equivalent to the value contained in <paramref name="s"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="System.FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String s, global::System.IFormatProvider? provider) =>
        global::System.DateOnly.TryParse(s, out var v) ? new(v) : new(global::System.DateTime.Parse(s));

    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result) =>
        TryParse(s, null, out result);

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
            ZYX v => CompareTo(v),
            _ => 1,
        };

        _overrideCompareTo(obj, ref result);
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
    public global::System.Int32 CompareTo(ZYX other)
    {
        var result = Value.CompareTo(other.Value);
        _overrideCompareTo(other, ref result);
        return result;
    }

    [global::System.Diagnostics.Contracts.Pure]
    public string ToString(global::System.String? format, global::System.IFormatProvider? formatProvider) =>
        Value.ToString(format, formatProvider);

    [global::System.Diagnostics.Contracts.Pure]
    public string ToShortDateString() =>
        Value.ToShortDateString();

    /// <summary>
    /// Returns the string representation of this <see cref="ZYX"/> instance, using the default format specifier.
    /// </summary>
    /// <returns>A string representation of the value of this <see cref="ZYX"/> instance.</returns>
    /// <remarks>
    /// This can be overridden by implementing the partial method <see cref="_overrideToString"/>
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.String ToString()
    {
        global::System.String s = Value.ToString();
        _overrideToString(Value, ref s);
        return s;
    }

    public global::System.Boolean TryFormat(global::System.Span<global::System.Char> destination, out global::System.Int32 charsWritten, global::System.ReadOnlySpan<global::System.Char> format, global::System.IFormatProvider? _) =>
        Value.TryFormat(destination, out charsWritten, format);

    /// <summary>
    /// Creates a new instance of the <see cref="ZYX"/> struct from a value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>A new instance of <see cref="ZYX"/> initialized to <paramref name="value"/></returns>
    /// <remarks>
    /// Preprocess <paramref name="value"/> before creating by implementing <see cref="_preprocess"/>
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX From(global::System.DateOnly value)
    {
        _preprocess(ref value);
        return new(value);
    }

    /// <summary>
    /// Creates a new instance of the <see cref="Test1"/> struct from a value.
    /// </summary>
    /// <param name="value">The value to convert.</param>
    /// <returns>A new instance of <see cref="Test1"/> initialized to <paramref name="value"/></returns>
    /// <remarks>
    /// Preprocess <paramref name="value"/> before creating by implementing <see cref="_preprocess"/>
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX From(global::System.DateTime value)
    {
        var v = global::System.DateOnly.FromDateTime(value);
        _preprocess(ref v);
        return new(v);
    }

    static partial void _preprocess(ref global::System.DateOnly result);

    partial void _overrideEquals(ZYX? obj, ref global::System.Boolean result);

    static partial void _overrideToString(global::System.DateOnly value, ref global::System.String result);

    partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

    partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> errors);

    public static global::System.Boolean TryFrom(global::System.DateOnly value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result, out global::System.Collections.Generic.IReadOnlySet<global::System.String> failures)
    {
        global::System.Collections.Generic.HashSet<global::System.String> validationFailures = new();

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

    public static global::System.Boolean TryFrom(global::System.DateOnly value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result) =>
        TryFrom(value, out result, out _);

    public static global::System.Boolean TryFrom(global::System.DateOnly value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX? result, out IReadOnlySet<string> failures)
    {
        global::System.Collections.Generic.HashSet<global::System.String> validationFailures = new();

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

    public static global::System.Boolean TryFrom(global::System.DateOnly value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX? result) =>
        TryFrom(value, out result, out _);

    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Collections.Generic.IReadOnlyList<global::System.String> Validate()
    {
        global::System.Collections.Generic.HashSet<global::System.String> errors = new();

        _validate(ref errors);

        return global::System.Linq.Enumerable.ToList(errors).AsReadOnly();
    }

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
    {
        if (global::System.DateOnly.TryParse(s, provider, out var r))
        {
            global::System.Collections.Generic.HashSet<global::System.String> errors = new();
            var created = From(r);

            created._validate(ref errors);

            if (errors.Count > 0)
            {
                result = default;
                return false;
            }

            result = created;
            return true;
        }
        else if (global::System.DateTime.TryParse(s, provider, out var r1))
        {
            global::System.Collections.Generic.HashSet<global::System.String> errors = new();
            var created = From(r1);

            created._validate(ref errors);

            if (errors.Count > 0)
            {
                result = default;
                return false;
            }

            result = created;
            return true;
        }

            result = default;
        return false;
    }

    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
    {
        if (global::System.DateOnly.TryParse(s, provider, out var r))
        {
            global::System.Collections.Generic.HashSet<global::System.String> errors = new();

            var created = From(r);

            created._validate(ref errors);

            if (errors.Count > 0)
            {
                result = default;
                return false;
            }

            result = created;
            return true;
        }

        result = default;
        return false;
    }

    public TResult Map<TResult>(global::System.Func<global::System.DateOnly, TResult> map) =>
        map(Value);

    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.DateOnly, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.From(map(Value));

    /// <summary>
    /// TypeConverter which converts to and from objects of type ZYX
    /// </summary>
    private class Converter : global::System.ComponentModel.TypeConverter
    {
        private static readonly global::System.ComponentModel.TypeConverter _baseConverter;

        static Converter()
        {
            _baseConverter = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::System.DateOnly));
        }

        public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type sourceType) =>
            _baseConverter.CanConvertFrom(context, sourceType) || sourceType == typeof(ZYX);

        public override global::System.Boolean CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? destinationType) =>
            _baseConverter.CanConvertTo(context, destinationType) || destinationType == typeof(ZYX);

        public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object value) =>
            new ZYX((global::System.DateOnly)_baseConverter.ConvertFrom(context, culture, value));

        public override global::System.Object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type destinationType)
        {
            var sourceType = value.GetType();
            if (value is null)
                return null;
            else if (sourceType == typeof(ZYX))
                return (ZYX)value;
            else if (_baseConverter.CanConvertFrom(sourceType) && _baseConverter.CanConvertTo(destinationType))
                return ZYX.Create((global::System.DateOnly)_baseConverter.ConvertTo(value, typeof(global::System.DateOnly)));
            throw new global::System.InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to {nameof(ZYX)}>");
        }
    }

    /// <summary>
    /// A JsonConverter for System.Text.Json which converts ZYX transparently to and from Json representations
    /// </summary>
    public class SystemJsonConverter : global::System.Text.Json.Serialization.JsonConverter<ZYX>
    {
        private readonly global::System.Text.Json.Serialization.JsonConverter<global::System.DateOnly> _valueConverter;

        public SystemJsonConverter(global::System.Text.Json.JsonSerializerOptions options)
        {
            _valueConverter = (global::System.Text.Json.Serialization.JsonConverter<global::System.DateOnly>)options.GetConverter(typeof(global::System.DateOnly));
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
    public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ZYX, global::System.DateTime>
    {
        public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
            : base(id => id.Value.ToDateTime(global::System.TimeOnly.MinValue), value => Create(value), mappingHints)
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
            new (_baseSerializer.Deserialize<global::System.DateOnly>(reader));

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, ZYX<TTimeZone> value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            _baseSerializer.Serialize(writer, value.Value);
    }
#endif
}