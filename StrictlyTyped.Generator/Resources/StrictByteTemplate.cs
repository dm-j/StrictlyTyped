/// <summary>
/// Represents a Strictly-typed struct for a unsigned byte value
/// </summary>
/// <remarks>
/// This struct is immutable and can be used for performance-sensitive scenarios that require
/// type safety and minimal allocations. It implements the <see cref="global::StrictlyTyped.IStrictByte{T}"/> interface
/// for Strict typing and can be used with the <see cref="global::StrictlyTyped"/> library.
/// </remarks>
[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct ZYX : global::StrictlyTyped.IStrictByte<ZYX>
{
    /// <summary>
    /// Gets the <see cref="global::System.Byte"/> value of the <see cref="ZYX"/> struct.
    /// </summary>
    public required readonly global::System.Byte Value { get; init; }

    private readonly static ZYX _one = new((global::System.Byte)1);
    /// <summary>
    /// Gets a <see cref="ZYX"/> instance representing the <see cref="global::System.Byte"/> value of 1.
    /// </summary>
    public static ZYX One => _one;

    private readonly static ZYX _zero = new((global::System.Byte)0);
    /// <summary>
    /// Gets a <see cref="ZYX"/> instance representing the <see cref="global::System.Byte"/> value of 0.
    /// </summary>
    public static ZYX Zero => _zero;

    /// <summary>
    /// Implicitly converts a <see cref="ZYX"/> to a <see cref="global::System.Byte"/>.
    /// </summary>
    /// <param name="value">The <see cref="ZYX"/> to convert.</param>
    /// <returns>The <see cref="global::System.Byte"/> equivalent to <paramref name="value"/>.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Byte(ZYX value) =>
        value.Value;

    /// <summary>
    /// Implicitly converts a <see cref="global::System.Byte"/> to a <see cref="ZYX"/>.
    /// </summary>
    /// <param name="value">The <see cref="global::System.Byte"/> to convert.</param>
    /// <returns>The <see cref="ZYX"/> equivalent to <paramref name="value"/>.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX(global::System.Byte value) =>
        new(value);

    /// <summary>
    /// Implicitly converts a nullable <see cref="global::System.Byte"/> to a nullable <see cref="ZYX"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="global::System.Byte"/> to convert.</param>
    /// <returns>The nullable <see cref="ZYX"/> equivalent to <paramref name="value"/>.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator ZYX?(global::System.Byte? value) =>
        value.HasValue ? new(value.Value) : null;

    /// <summary>
    /// Implicitly converts a nullable <see cref="ZYX"/> to a nullable <see cref="global::System.Byte"/>.
    /// </summary>
    /// <param name="value">The nullable <see cref="ZYX"/> to convert.</param>
    /// <returns>The nullable <see cref="global::System.Byte"/> equivalent to <paramref name="value"/>.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.Byte?(ZYX? value) =>
        value.HasValue ? value.Value.Value : null;

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
    /// Initializes a new instance of the <see cref="ZYX"/> struct with the value of <paramref name="value"/>.
    /// </summary>
    /// <param name="value">The value to use as the underlying value of the <see cref="ZYX"/> struct.</param>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.Byte value)
    {
        Value = value;
    }

    public override global::System.Int32 GetHashCode() =>
        Value.GetHashCode();

    /// <summary>
    /// Determines whether this instance is equal to another instance of the <see cref="ZYX"/> class.
    /// </summary>
    /// <param name="other">The <see cref="ZYX"/> instance to compare with this instance.</param>
    /// <returns>
    /// <see langword="true"/> if the specified <see cref="ZYX"/> instance is equal to this instance; otherwise, <see langword="true"/>.
    /// </returns>
    /// <remarks>
    /// The value returned by this method can be customized by overriding the
    /// <see cref="_overrideEquals"/> method.
    /// </remarks>
    public bool Equals(ZYX? other)
    {
        bool result = Value.Equals(other?.Value);
        _overrideEquals(other, ref result);
        return result;
    }

    /// <summary>
    /// Creates a new instance of the <see cref="ZYX"/> class with the specified value.
    /// </summary>
    /// <param name="value">A <see cref="global::System.Byte"/> value to be assigned to the new instance.</param>
    /// <returns>A new instance of the <see cref="ZYX"/> class with the specified value.</returns>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    public static ZYX Create(global::System.Byte value) =>
        new(value);

    /// <summary>
    /// Converts the <see cref="global::System.String"/> representation of a <see cref="ZYX"/> value to its corresponding <see cref="ZYX"/> object.
    /// </summary>
    /// <param name="s">The <see cref="global::System.String"/> to parse.</param>
    /// <returns>A new <see cref="ZYX"/> object that represents the value parsed from <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String? s) =>
        new(global::System.Byte.Parse(s!));

    /// <summary>
    /// Converts the <see cref="global::System.ReadOnlySpan{global::System.Char}"/> representation of a <see cref="ZYX"/> value to its corresponding <see cref="ZYX"/> object.
    /// </summary>
    /// <param name="s">The <see cref="global::System.ReadOnlySpan{global::System.Char}"/> to parse.</param>
    /// <returns>A new <see cref="ZYX"/> object that represents the value parsed from <paramref name="s"/>.</returns>
    /// <exception cref="global::System.ArgumentNullException">Thrown when <paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="global::System.FormatException">Thrown when <paramref name="s"/> is not in the correct format.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider) =>
        new(global::System.Byte.Parse(s, provider));

    /// <summary>
    /// Converts the <see cref="global::System.String"/> representation of a value in a specified culture-specific format to its <see cref="ZYX"/> equivalent.
    /// </summary>
    /// <param name="s">A <see cref="global::System.String"/> that contains the number to convert.</param>
    /// <param name="provider">An object that provides culture-specific formatting information.</param>
    /// <returns>A <see cref="ZYX"/> equivalent to the value contained in <paramref name="s"/>.</returns>
    /// <exception cref="System.ArgumentNullException"><paramref name="s"/> is <see langword="null"/>.</exception>
    /// <exception cref="System.FormatException"><paramref name="s"/> is not in the correct format.</exception>
    /// <remarks>
    /// No validation or preprocessing is performed.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String s, global::System.IFormatProvider? provider) =>
        new(global::System.Byte.Parse(s, provider));

    /// <summary>
    /// Tries to convert the <see cref="global::System.String"/> representation of a <see cref="ZYX"/> value to its <see cref="ZYX"/> equivalent. A return value indicates
    /// whether the conversion succeeded.
    /// </summary>
    /// <param name="s">A <see cref="global::System.String"/> containing the characters to convert.</param>
    /// <param name="result">When this method returns, contains the <see cref="ZYX"/> equivalent of the <see cref="global::System.String"/> contained in <paramref name="s"/>, if the conversion succeeded, or <see langword="null"/> if the conversion failed. The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or contains a <see cref="global::System.String"/> that is not a valid <see cref="ZYX"/> value. This parameter is passed uninitialized.</param>
    /// <returns><see langword="true"/> if the <see cref="global::System.String"/> was converted successfully; otherwise, <see langword="false"/>.</returns>
    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result) =>
        TryParse(s, null, out result);

    /// <summary>
    /// Compares this instance to a specified object and returns an indication of their relative values.
    /// </summary>
    /// <param name="obj">An object to compare, or null.</param>
    /// <returns>A signed integer that indicates the relative values of this instance and <paramref name="obj"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="obj"/> is not a <see cref="ZYX"/> object.</exception>
    /// <remarks>
    /// The value returned by this method can be customized by overriding the <see cref="_overrideCompareTo"/> method.
    /// </remarks>
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
    /// Compares this instance to a specified <see cref="ZYX"/> and returns an indication of their relative values.
    /// </summary>
    /// <param name="obj">An object to compare, or <see langword="null"/>.</param>
    /// <returns>A signed integer that indicates the relative values of this instance and <paramref name="obj"/>.</returns>
    /// <exception cref="ArgumentException"><paramref name="obj"/> is not a <see cref="ZYX"/> object.</exception>
    /// <remarks>
    /// The value returned by this method can be customized by overriding the <see cref="_overrideCompareTo"/> method.
    /// </remarks>
    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(ZYX other)
    {
        var result = Value.CompareTo(other.Value);
        _overrideCompareTo(other, ref result);
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
    public string ToString(global::System.String? format, global::System.IFormatProvider? formatProvider) =>
    Value.ToString(format, formatProvider);

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
    public static ZYX From(global::System.Byte value)
    {
        _preprocess(ref value);
        return new(value);
    }

    /// <summary>
    /// This method is called before parsing or creating a new instance to preprocess the input value. In this case,
    /// this method does nothing.
    /// </summary>
    /// <param name="result">The input value to be preprocessed.</param>
    static partial void _preprocess(ref global::System.Byte result);

    /// <summary>
    /// If implemented, the result of calling CompareTo on the wrapped value will be modified by this method
    /// </summary>
    /// <param name="result">The value which will be returned by CompareTo</param>
    partial void _overrideEquals(ZYX? obj, ref global::System.Boolean result);

    /// <summary>
    /// If implemented, the result of calling ToString on the wrapped value will be modified by this method
    /// </summary>
    /// <param name="result">The value which will be returned by ToString</param>
    static partial void _overrideToString(global::System.Byte value, ref global::System.String result);

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

    public static global::System.Boolean TryFrom(global::System.Byte value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result, out global::System.Collections.Generic.IReadOnlySet<global::System.String> failures)
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

    public static global::System.Boolean TryFrom(global::System.Byte value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX result) =>
        TryFrom(value, out result, out _);

    public static global::System.Boolean TryFrom(global::System.Byte value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX? result, out IReadOnlySet<string> failures)
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

    public static global::System.Boolean TryFrom(global::System.Byte value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out ZYX? result) =>
        TryFrom(value, out result, out _);

    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Collections.Generic.IReadOnlyList<global::System.String> Validate()
    {
        global::System.Collections.Generic.HashSet<global::System.String> errors = new();

        _validate(ref errors);

        return global::System.Linq.Enumerable.ToList(errors).AsReadOnly();
    }

    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.ReadOnlySpan<char> s, global::System.Globalization.NumberStyles style, global::System.IFormatProvider? provider) =>
        new(global::System.Byte.Parse(s, style, provider));

    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX Parse(global::System.String s, global::System.Globalization.NumberStyles style, IFormatProvider? provider) =>
        new(global::System.Byte.Parse(s, style, provider));

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
    {
        if (global::System.Byte.TryParse(s, provider, out var r))
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

    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX result)
    {
        if (global::System.Byte.TryParse(s, provider, out var r))
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

    public TResult Map<TResult>(global::System.Func<global::System.Byte, TResult> map) =>
        map(Value);

    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.Byte, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.From(map(Value));

    private class Converter : global::System.ComponentModel.TypeConverter
    {
        private static readonly global::System.ComponentModel.TypeConverter _baseConverter;

        static Converter()
        {
            _baseConverter = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::System.Byte));
        }

        private readonly global::System.Type[] _knownTypes = new[]
        {
            typeof(ZYX),
            typeof(global::System.String),
            typeof(global::System.Byte),
        };

        public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type sourceType) =>
            _knownTypes.Contains(sourceType) ||
            (_baseConverter.CanConvertFrom(sourceType) && _baseConverter.CanConvertTo(typeof(global::System.Byte)));

        public override global::System.Boolean CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? destinationType) =>
            destinationType == typeof(ZYX);

        public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object value)
        {
            return value switch
            {
                null => null,
                ZYX v => v,
                global::System.Byte v => new ZYX(v),
                global::System.String v => Parse(v),
                var v when _baseConverter.CanConvertFrom(v.GetType()) && _baseConverter.CanConvertTo(typeof(global::System.Byte)) =>
                new ZYX((global::System.Byte)_baseConverter.ConvertTo(context, culture, v, typeof(global::System.Byte))!),
                _ => throw new global::System.InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to {nameof(ZYX)}>"),
            };
        }

        public override global::System.Object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type destinationType)
        {
            if (destinationType == typeof(global::System.String))
            {
                if (value is ZYX Strict)
                    return Strict.Value.ToString();

                return _baseConverter.ConvertToString(value);
            }

            if (destinationType != typeof(ZYX))
                throw new InvalidCastException($"Cannot convert to Type {destinationType.FullName ?? "<null>"}");

            return ConvertFrom(context, culture, value!);
        }
    }

    /// <summary>
    /// A JsonConverter for System.Text.Json which converts ZYX transparently to and from Json representations
    /// </summary>
    public class SystemJsonConverter : global::System.Text.Json.Serialization.JsonConverter<ZYX>
    {
        public override ZYX Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
        {
            return new(reader.GetByte());
        }

        public override void Write(global::System.Text.Json.Utf8JsonWriter writer, ZYX value, global::System.Text.Json.JsonSerializerOptions options)
        {
            writer.WriteRawValue(global::System.Text.Json.JsonSerializer.Serialize(value.Value));
        }
    }


#if (USE_EF_CORE)
    public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ZYX, global::System.Byte>
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
        public override ZYX ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, ZYX existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer) =>
            Parse(reader.Value!.ToString());

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, ZYX value, Newtonsoft.Json.JsonSerializer serializer) =>
            global::Newtonsoft.Json.Linq.JToken.FromObject(((ZYX)value).Value).WriteTo(writer);
    }
#endif
}