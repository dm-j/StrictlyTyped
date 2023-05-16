//[global::System.Diagnostics.DebuggerDisplay("{Value}")]
//[global::System.ComponentModel.TypeConverter(typeof(Converter))]
//[global::System.Text.Json.Serialization.JsonConverter(typeof(global::StrictlyTyped.Internal.StrictDateTimeSystemJsonConverterFactory))]
//#if (USE_NEWTONSOFT_JSON)
//[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftSTRICT_TYPEJsonConverter))]
//#endif
//public readonly partial record struct STRICT_TYPE<TTimeZone> : global::StrictlyTyped.IStrictDateTime<STRICT_TYPE<TTimeZone>, TTimeZone> where TTimeZone : global::StrictlyTyped.IStrictTimeZone
//{
//    public required readonly global::System.DateTime Value { get; init; }

//    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
//    public STRICT_TYPE(global::System.DateTime value)
//    {
//        Value = new global::System.DateTime(value.Ticks,
//            TTimeZone.TimeZone == global::System.TimeZoneInfo.Utc ? global::System.DateTimeKind.Utc : global::System.DateTimeKind.Unspecified);
//    }

//    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
//    public STRICT_TYPE(global::System.DateOnly value)
//        : this(value.ToDateTime(global::System.TimeOnly.MinValue))
//    {
//    }

//    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
//    public STRICT_TYPE(global::System.Int32 year, global::System.Int32 month, global::System.Int32 day, global::System.Int32 hour, global::System.Int32 minute, global::System.Int32 second)
//    {
//        Value = new global::System.DateTime(year, month, day, hour, minute, second,
//            TTimeZone.TimeZone == global::System.TimeZoneInfo.Utc ? global::System.DateTimeKind.Utc : global::System.DateTimeKind.Unspecified);
//    }

//    public STRICT_TYPE<TNewTimeZone> InTimeZone<TNewTimeZone>() where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone
//    {
//        return new(global::System.TimeZoneInfo.ConvertTime(Value, TTimeZone.TimeZone, TNewTimeZone.TimeZone));
//    }

//    public static implicit operator STRICT_TYPE<TTimeZone>(global::System.DateTime value) =>
//        new(value);

//    public static implicit operator global::System.DateTime(STRICT_TYPE<TTimeZone> value) =>
//        value.Value;

//    public static implicit operator STRICT_TYPE<TTimeZone>?(global::System.DateTime? value) =>
//        value.HasValue ? new(value.Value) : null;

//    public static implicit operator global::System.DateTime?(STRICT_TYPE<TTimeZone>? value) =>
//        value.HasValue ? value.Value.Value : null;

//    public static implicit operator STRICT_TYPE<TTimeZone>(global::System.DateOnly value) =>
//        value.ToDateTime(global::System.TimeOnly.MinValue);

//    public static implicit operator global::System.DateOnly(STRICT_TYPE<TTimeZone> value) =>
//        global::System.DateOnly.FromDateTime(value.Value);

//    public static implicit operator STRICT_TYPE<TTimeZone>?(global::System.DateOnly? value) =>
//        value.HasValue ? new(value.Value) : null;

//    public static implicit operator DateOnly?(STRICT_TYPE<TTimeZone>? value) =>
//        value.HasValue ? global::System.DateOnly.FromDateTime(value.Value.Value) : null;

//    public static bool operator ==(STRICT_TYPE<TTimeZone> left, global::System.DateTime right) =>
//        left.Value.Equals(right);

//    public static bool operator !=(STRICT_TYPE<TTimeZone> left, global::System.DateTime right) =>
//        !(left == right);

//    public static bool operator ==(global::System.DateTime left, STRICT_TYPE<TTimeZone> right) =>
//        right == left;

//    public static bool operator !=(global::System.DateTime left, STRICT_TYPE<TTimeZone> right) =>
//        !(right == left);

//    public static STRICT_TYPE<TTimeZone> Create(global::System.DateTime value) =>
//        new(value);

//    public static STRICT_TYPE<TTimeZone> From(global::System.DateTime value)
//    {
//        _preprocess(ref value);
//        return new(value);
//    }

//    public static global::System.Boolean TryFrom(global::System.DateTime value, out STRICT_TYPE<TTimeZone> result, out IReadOnlySet<global::System.String> failures)
//    {
//        global::System.Collections.Generic.HashSet<global::System.String> validationFailures = new();

//        var created = From(value);

//        created._validate(ref validationFailures);

//        if (validationFailures.Count > 0)
//        {
//            result = default;
//            failures = validationFailures;
//            return false;
//        }

//        result = created;
//        failures = validationFailures;
//        return true;
//    }

//    public static global::System.Boolean TryFrom(global::System.DateTime value, out STRICT_TYPE<TTimeZone> result) =>
//        TryFrom(value, out result, out _);

//    public global::System.Boolean Validate(out global::System.Collections.Generic.IReadOnlyCollection<global::System.String> errors)
//    {
//        global::System.Collections.Generic.HashSet<global::System.String> problems = new();

//        _validate(ref problems);

//        errors = global::System.Linq.Enumerable.ToList(problems).AsReadOnly();

//        return !errors.Any();
//    }

//    public global::System.Boolean Validate() =>
//        Validate(out _);

//    public global::System.DateOnly DateOnly() =>
//        DateOnly<TTimeZone>();

//    public global::System.DateOnly DateOnly<TNewTimeZone>() where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone =>
//        global::System.DateOnly.FromDateTime(InTimeZone<TNewTimeZone>());

//    public TStrictDate ToDate<TStrictDate>() where TStrictDate : struct, global::StrictlyTyped.IStrictDateOnly<TStrictDate> =>
//        global::System.DateOnly.FromDateTime(Value);

//    public TStrictDate ToDate<TStrictDate, TNewTimeZone>() where TStrictDate : struct, global::StrictlyTyped.IStrictDateOnly<TStrictDate> where TNewTimeZone : global::StrictlyTyped.IStrictTimeZone =>
//        global::System.DateOnly.FromDateTime(InTimeZone<TNewTimeZone>());

//    public override global::System.Int32 GetHashCode() =>
//        Value.GetHashCode();

//    public global::System.Boolean Equals<TOtherTimeZone>(STRICT_TYPE<TOtherTimeZone> other) where TOtherTimeZone : global::StrictlyTyped.IStrictTimeZone =>
//        other.InTimeZone<TTimeZone>().Equals(this);

//    [global::System.Diagnostics.Contracts.Pure]
//    public override global::System.String ToString()
//    {
//        global::System.String s = Value.ToString();
//        _overrideToString(Value, ref s);
//        return s;
//    }

//    [global::System.Diagnostics.Contracts.Pure]
//    public global::System.Int32 CompareTo(global::System.Object? obj)
//    {
//        var result = obj switch
//        {
//            null => 1,
//            STRICT_TYPE<TTimeZone> v => CompareTo(v),
//            _ => throw new ArgumentException($"Value cannot be compared to STRICT_TYPE<{typeof(TTimeZone).Name}>", nameof(obj)),
//        };

//        _overrideCompareTo(obj, ref result);
//        return result;
//    }

//    public global::System.Int32 CompareTo(STRICT_TYPE<TTimeZone> other)
//    {
//        return Value.CompareTo(other.Value);
//    }

//    public global::System.String ToString(global::System.String format, global::System.IFormatProvider formatProvider) =>
//        Value.ToString(format, formatProvider);

//    static partial void _preprocess(ref global::System.DateTime value);

//    partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> failures);

//    static partial void _overrideToString(global::System.DateTime dateTime, ref global::System.String value);
//    static partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

//    [global::System.Diagnostics.Contracts.Pure]
//    public static STRICT_TYPE<TTimeZone> Parse(global::System.String? s) =>
//        new(global::System.DateTime.Parse(s!));

//    [global::System.Diagnostics.Contracts.Pure]
//    public static STRICT_TYPE<TTimeZone> Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider) =>
//        From(global::System.DateTime.Parse(s, provider));

//    [global::System.Diagnostics.Contracts.Pure]
//    public static STRICT_TYPE<TTimeZone> Parse(global::System.String s, global::System.IFormatProvider? provider) =>
//        From(global::System.DateTime.Parse(s, provider));

//    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE<TTimeZone> result) =>
//        TryParse(s, null, out result);

//    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE<TTimeZone> result)
//    {
//        if (global::System.DateTime.TryParse(s, provider, out global::System.DateTime r))
//        {
//            global::System.Collections.Generic.HashSet<global::System.String> errors = new();
//            var created = From(r);

//            created._validate(ref errors);

//            if (errors.Count > 0)
//            {
//                result = default;
//                return false;
//            }

//            result = created;
//            return true;
//        }

//        result = default;
//        return false;
//    }

//    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE<TTimeZone> result)
//    {
//        if (global::System.DateTime.TryParse(s, provider, out global::System.DateTime r))
//        {
//            global::System.Collections.Generic.HashSet<global::System.String> errors = new();

//            var created = From(r);

//            created._validate(ref errors);

//            if (errors.Count > 0)
//            {
//                result = default;
//                return false;
//            }

//            result = created;
//            return true;
//        }

//        result = default;
//        return false;
//    }

//    public TResult Map<TResult>(global::System.Func<global::System.DateTime, TResult> map) =>
//        map(Value);

//    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.DateTime, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
//        TStrictResult.From(map(Value));

//#if (USE_NEWTONSOFT_JSON)
//    /// <summary>
//    /// A JsonConverter for Newtonsoft.Json which converts STRICT_TYPE transparently to and from Json representations
//    /// </summary>
//    public sealed class NewtonsoftActualJsonConverter : global::Newtonsoft.Json.JsonConverter<STRICT_TYPE<TTimeZone>>
//    {
//        private readonly global::Newtonsoft.Json.JsonSerializer _baseSerializer = new();

//        public override STRICT_TYPE<TTimeZone> ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, STRICT_TYPE<TTimeZone> existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
//            new(_baseSerializer.Deserialize<global::System.DateTime>(reader));

//        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, STRICT_TYPE<TTimeZone> value, global::Newtonsoft.Json.JsonSerializer serializer) =>
//            _baseSerializer.Serialize(writer, value.Value);
//    }
//#endif
//}

///// <summary>
///// A JsonConverter for System.Text.Json which converts STRICT_TYPE transparently to and from Json representations
///// </summary>
//public sealed class SystemJsonConverter<TTimeZone> : global::System.Text.Json.Serialization.JsonConverter<STRICT_TYPE<TTimeZone>> 
//    where TTimeZone : global::StrictlyTyped.IStrictTimeZone
//{
//    private readonly global::System.Text.Json.Serialization.JsonConverter<DateTime> _valueConverter;

//    public SystemJsonConverter(global::System.Text.Json.JsonSerializerOptions options)
//    {
//        // For performance, use the existing converter.
//        _valueConverter = (global::System.Text.Json.Serialization.JsonConverter<DateTime>)options
//            .GetConverter(typeof(DateTime));
//    }

//    public override STRICT_TYPE<TTimeZone> Read(ref global::System.Text.Json.Utf8JsonReader reader, global::System.Type typeToConvert, global::System.Text.Json.JsonSerializerOptions options)
//    {
//        return _valueConverter.Read(ref reader, typeToConvert, options);
//    }

//    public override void Write(global::System.Text.Json.Utf8JsonWriter writer, STRICT_TYPE<TTimeZone> value, global::System.Text.Json.JsonSerializerOptions options)
//    {
//        _valueConverter.Write(writer, value.Value, options);
//    }
//}

//#if (USE_EF_CORE)
//public sealed class EFConverter<TTimeZone> : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<STRICT_TYPE<TTimeZone>, global::System.DateTime>
//    where TTimeZone : IStrictTimeZone
//{
//    public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
//        : base(id => id.Value, value => STRICT_TYPE<TTimeZone>.Creates(value), mappingHints)
//    { }
//}
//#endif

//#if USE_NEWTONSOFT_JSON
//internal sealed class NewtonsoftSTRICT_TYPEJsonConverter : global::Newtonsoft.Json.JsonConverter
//{
//    private readonly global::Newtonsoft.Json.JsonSerializer _serializer = new();

//    public override global::System.Boolean CanConvert(global::System.Type objectType) =>
//        objectType.IsGenericParameter && objectType.IsAssignableTo(typeof(global::StrictlyTyped.IStrictType<DateTime>));

//    public override global::System.Object? ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, global::System.Object? existingValue, global::Newtonsoft.Json.JsonSerializer serializer)
//    {
//        return objectType.GetMethod("Create")!.Invoke(null, new global::System.Object[] { _serializer.Deserialize<global::System.DateTime>(reader) });
//    }

//    public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, global::System.Object? value, global::Newtonsoft.Json.JsonSerializer serializer)
//    {
//        if (value is null)
//            return;
//        serializer.Serialize(writer, ((global::StrictlyTyped.IStrictType<global::System.DateTime>)value).Value);
//    }
//}
//#endif

///// <summary>
///// TypeConverter which converts to and from objects of type STRICT_TYPE
///// </summary>
//internal class Converter : global::System.ComponentModel.TypeConverter
//{
//    private static readonly global::System.ComponentModel.TypeConverter _baseConverter;
//    private readonly global::System.Type _instanceType;
//    private readonly global::System.Func<object, object> _createFromDateTime;

//    static Converter()
//    {
//        _baseConverter = global::System.ComponentModel.TypeDescriptor.GetConverter(typeof(global::System.DateTime));
//    }

//    public Converter(Type type)
//    {
//        if (!type.IsGenericType)
//        { 
//            throw new global::System.ArgumentException("Incompatible type", nameof(type));
//        }

//        var genericArguments = type.GetGenericArguments();

//        if (type.GetGenericTypeDefinition() == typeof(STRICT_TYPE<>)
//            && genericArguments.Length == 1
//            && genericArguments[0].IsAssignableTo(typeof(global::StrictlyTyped.IStrictTimeZone)))
//        {
//            _instanceType = typeof(STRICT_TYPE<>).MakeGenericType(genericArguments[0]);
//            _createFromDateTime =
//                value => Activator.CreateInstance(_instanceType, new object[] { value, typeof(DateTime) })!;
//            return;
//        }

//        throw new global::System.ArgumentException("Incompatible type", nameof(type));
//    }

//    public override global::System.Boolean CanConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type sourceType) =>
//        _baseConverter.CanConvertFrom(context, sourceType) || sourceType.IsAssignableTo(typeof(global::StrictlyTyped.IStrictType<global::System.DateTime>));

//    public override global::System.Boolean CanConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Type? destinationType) =>
//        _baseConverter.CanConvertTo(context, destinationType) || (destinationType?.IsAssignableTo(typeof(global::StrictlyTyped.IStrictType<global::System.DateTime>)) ?? false);

//    public override global::System.Object? ConvertFrom(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object value) =>
//        _createFromDateTime(_baseConverter.ConvertTo(context, culture, value, typeof(DateTime))!);

//    public override global::System.Object? ConvertTo(global::System.ComponentModel.ITypeDescriptorContext? context, global::System.Globalization.CultureInfo? culture, global::System.Object? value, global::System.Type destinationType)
//    {
//        var sourceType = value?.GetType()!;

//        if (value is null)
//            return null;
//        else if (sourceType == _instanceType)
//            return value;
//        else if (_baseConverter.CanConvertFrom(sourceType) && destinationType == _instanceType)
//            return _createFromDateTime(_baseConverter.ConvertTo(context, culture, value, typeof(DateTime))!);
//        else if (_baseConverter.CanConvertFrom(sourceType) && _baseConverter.CanConvertFrom(destinationType))
//            return _baseConverter.ConvertTo(context, culture, value, destinationType);

//        throw new global::System.InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to STRICT_TYPE");
//    }
//}