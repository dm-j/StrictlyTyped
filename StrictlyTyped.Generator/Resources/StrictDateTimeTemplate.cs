[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter<TTimeZone>))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter<TTimeZone>))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter<TTimeZone>))]
#endif
public readonly partial record struct ZYX<TTimeZone> : global::StrictlyTyped.IStrictDateTime<ZYX<TTimeZone>, TTimeZone> where TTimeZone : global::StrictlyTyped.IStrictTimeZone
{
    public required readonly global::System.DateTime Value { get; init; }

    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.DateTime value)
    {
        Value = new global::System.DateTime(value.Ticks, 
            TTimeZone.TimeZone == global::System.TimeZoneInfo.Utc ? global::System.DateTimeKind.Utc : global::System.DateTimeKind.Unspecified);
    }

    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public ZYX(global::System.Int32 year, global::System.Int32 month, global::System.Int32 day, global::System.Int32 hour, global::System.Int32 minute, global::System.Int32 second)
    {
        Value = new global::System.DateTime(year, month, day, hour, minute, second, 
            TTimeZone.TimeZone == global::System.TimeZoneInfo.Utc ? global::System.DateTimeKind.Utc : global::System.DateTimeKind.Unspecified);
    }

    public ZYX<TNewTimeZone> InTimeZone<TNewTimeZone>() where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone
    {
        return new(global::System.TimeZoneInfo.ConvertTime(Value, TTimeZone.TimeZone, TNewTimeZone.TimeZone));
    }

    public static implicit operator ZYX<TTimeZone>(global::System.DateTime value) =>
        new(value);

    public static implicit operator global::System.DateTime(ZYX<TTimeZone> value) =>
        value.Value;

    public static implicit operator ZYX<TTimeZone>?(global::System.DateTime? value) =>
        value.HasValue ? new(value.Value) : null;

    public static implicit operator global::System.DateTime?(ZYX<TTimeZone>? value) =>
        value.HasValue ? value.Value.Value : null;

    public static implicit operator ZYX<TTimeZone>(global::System.DateOnly value) =>
        value.ToDateTime(global::System.TimeOnly.MinValue);

    public static implicit operator global::System.DateOnly(ZYX<TTimeZone> value) =>
        global::System.DateOnly.FromDateTime(value.Value);

    public static implicit operator ZYX<TTimeZone>?(global::System.DateOnly? value) =>
        value.HasValue ? new(value.Value.ToDateTime(global::System.TimeOnly.MinValue)) : null;

    public static implicit operator DateOnly?(ZYX<TTimeZone>? value) =>
        value.HasValue ? global::System.DateOnly.FromDateTime(value.Value.Value) : null;

    public static bool operator ==(ZYX<TTimeZone> left, global::System.DateTime right) =>
        left.Value.Equals(right);

    public static bool operator !=(ZYX<TTimeZone> left, global::System.DateTime right) =>
        !(left == right);

    public static bool operator ==(global::System.DateTime left, ZYX<TTimeZone> right) =>
        right == left;

    public static bool operator !=(global::System.DateTime left, ZYX<TTimeZone> right) =>
        !(right == left);

    public static ZYX<TTimeZone> Create(global::System.DateTime value) =>
        new(value);

    public static ZYX<TTimeZone> From(global::System.DateTime value)
    {
        _preprocess(ref value);
        return new(value);
    }

    public static global::System.Boolean TryFrom(global::System.DateTime value, out ZYX<TTimeZone> result, out IReadOnlySet<global::System.String> failures)
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

    public static global::System.Boolean TryFrom(global::System.DateTime value, out ZYX<TTimeZone> result) =>
        TryFrom(value, out result, out _);

    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Collections.Generic.IReadOnlyList<global::System.String> Validate()
    {
        global::System.Collections.Generic.HashSet<global::System.String> errors = new();

        _validate(ref errors);

        return global::System.Linq.Enumerable.ToList(errors).AsReadOnly();
    }

    public global::System.DateOnly DateOnly() => 
        DateOnly<TTimeZone>();

    public global::System.DateOnly DateOnly<TNewTimeZone>() where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone => 
        global::System.DateOnly.FromDateTime(InTimeZone<TNewTimeZone>());

    public TStrictDate ToDate<TStrictDate>() where TStrictDate : struct, global::StrictlyTyped.IStrictDateOnly<TStrictDate> =>
        global::System.DateOnly.FromDateTime(Value);

    public TStrictDate ToDate<TStrictDate, TNewTimeZone>() where TStrictDate : struct, global::StrictlyTyped.IStrictDateOnly<TStrictDate> where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone =>
        global::System.DateOnly.FromDateTime(InTimeZone<TNewTimeZone>());

    public override global::System.Int32 GetHashCode() =>
        Value.GetHashCode();

    public global::System.Boolean Equals<TOtherTimeZone>(ZYX<TOtherTimeZone> other) where TOtherTimeZone : global::StrictlyTyped.IStrictTimeZone =>
        other.InTimeZone<TTimeZone>().Equals(this);

    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.String ToString()
    {
        global::System.String s = Value.ToString();
        _overrideToString(Value, ref s);
        return s;
    }

    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(global::System.Object? obj)
    {
        var result = obj switch
        {
            null => 1,
            ZYX<TTimeZone> v => CompareTo(v),
            _ => throw new ArgumentException($"Value cannot be compared to ZYX<{typeof(TTimeZone).Name}>", nameof(obj)),
        };

        _overrideCompareTo(obj, ref result);
        return result;
    }

    public global::System.Int32 CompareTo(ZYX<TTimeZone> other)
    {
        return Value.CompareTo(other.Value);
    }

    public global::System.String ToString(global::System.String  format, global::System.IFormatProvider formatProvider) => 
        Value.ToString(format, formatProvider);

    static partial void _preprocess(ref global::System.DateTime value);

    partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> failures);

    static partial void _overrideToString(global::System.DateTime dateTime, ref global::System.String value);
    static partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX<TTimeZone> Parse(global::System.String? s) =>
        new(global::System.DateTime.Parse(s!));

    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX<TTimeZone> Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider) =>
        From(global::System.DateTime.Parse(s, provider));

    [global::System.Diagnostics.Contracts.Pure]
    public static ZYX<TTimeZone> Parse(global::System.String s, global::System.IFormatProvider? provider) =>
        From(global::System.DateTime.Parse(s, provider));

    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX<TTimeZone> result) =>
        TryParse(s, null, out result);

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX<TTimeZone> result)
    {
        if (global::System.DateTime.TryParse(s, provider, out global::System.DateTime r))
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

    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out ZYX<TTimeZone> result)
    {
        if (global::System.DateTime.TryParse(s, provider, out global::System.DateTime r))
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

    public TResult Map<TResult>(global::System.Func<global::System.DateTime, TResult> map) =>
        map(Value);

    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.DateTime, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.From(map(Value));
}

file class Converter<TTimeZone> : global::System.ComponentModel.TypeConverter where TTimeZone : global::StrictlyTyped.IStrictTimeZone
{
    private static readonly global::System.ComponentModel.TypeConverter _baseConverter;

    static Converter()
    {
        _baseConverter = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::System.DateOnly));
    }

    private readonly global::System.Type[] _knownTypes = new[]
    {
            typeof(ZYX<TTimeZone>),
            typeof(global::System.String),
            typeof(global::System.DateOnly),
            typeof(global::System.DateTime),
        };

    public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type sourceType) =>
        _knownTypes.Contains(sourceType) ||
        (_baseConverter.CanConvertFrom(sourceType) && (_baseConverter.CanConvertTo(typeof(global::System.DateOnly)) || _baseConverter.CanConvertTo(typeof(global::System.DateTime))));

    public override global::System.Boolean CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? destinationType) =>
        destinationType == typeof(ZYX<TTimeZone>);

    public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object value)
    {
        return value switch
        {
            null => null,
            ZYX<TTimeZone> v => v,
            global::System.DateOnly v => new ZYX<TTimeZone>(v),
            global::System.DateTime v => new ZYX<TTimeZone>(global::System.DateOnly.FromDateTime(v)),
            global::System.String v => ZYX<TTimeZone>.Parse(v),
            var v when _baseConverter.CanConvertFrom(v.GetType()) && _baseConverter.CanConvertTo(typeof(global::System.DateOnly)) =>
                new ZYX<TTimeZone>((global::System.DateOnly)_baseConverter.ConvertTo(context, culture, v, typeof(global::System.DateOnly))!),
            var v when _baseConverter.CanConvertFrom(v.GetType()) && _baseConverter.CanConvertTo(typeof(global::System.DateTime)) =>
                new ZYX<TTimeZone>(global::System.DateOnly.FromDateTime((global::System.DateTime)_baseConverter.ConvertTo(context, culture, v, typeof(global::System.DateTime))!)),
            _ => throw new global::System.InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to {nameof(ZYX<TTimeZone>)}>"),
        };
    }

    public override global::System.Object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type destinationType)
    {
        if (destinationType == typeof(global::System.String))
        {
            if (value is ZYX<TTimeZone> Strict)
                return Strict.Value.ToString();

            return _baseConverter.ConvertToString(value);
        }

        if (destinationType != typeof(ZYX<TTimeZone>))
            throw new InvalidCastException($"Cannot convert to Type {destinationType.FullName ?? "<null>"}");

        return ConvertFrom(context, culture, value!);
    }
}

/// <summary>
/// A JsonConverter for System.Text.Json which converts ZYX transparently to and from Json representations
/// </summary>
file class SystemJsonConverter : global::System.Text.Json.Serialization.JsonConverter<ZYX<TTimeZone>>
{
    public override ZYX<TTimeZone> Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
    {
        return new(reader.GetDateTime());
    }

    public override void Write(global::System.Text.Json.Utf8JsonWriter writer, ZYX<TTimeZone> value, global::System.Text.Json.JsonSerializerOptions options)
    {
        writer.WriteRawValue(global::System.Text.Json.JsonSerializer.Serialize(value.Value));
    }
}

#if (USE_EF_CORE)
public class EFConverter<TTimeZone> : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ZYX<TTimeZone>, global::System.DateTime>
    where TTimeZone : IStrictTimeZone
{
    public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
        : base(id => id.Value, value => ZYX<TTimeZone>.Creates(value), mappingHints)
    { }
}
#endif

#if (USE_NEWTONSOFT_JSON)
/// <summary>
/// A JsonConverter for Newtonsoft.Json which converts <see cref="ZYX{TTimeZone}" transparently to and from Json representations
/// </summary>
file class NewtonsoftJsonConverter<TTimeZone> : global::Newtonsoft.Json.JsonConverter<ZYX<TTimeZone>>
{
    public override ZYX<TTimeZone> ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, ZYX<TTimeZone> existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer) =>
        Create(global::System.DateTime.Parse(reader.Value!.ToString()));

    public override void WriteJson(Newtonsoft.Json.JsonWriter writer, ZYX<TDateTime> value, Newtonsoft.Json.JsonSerializer serializer) =>
        global::Newtonsoft.Json.Linq.JToken.FromObject(((ZYX<TTimeZone>)value)).WriteTo(writer);
}
#endif
