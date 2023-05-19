[global::System.Diagnostics.DebuggerDisplay("{Value}")]
[global::System.ComponentModel.TypeConverter(typeof(Converter))]
[global::System.Text.Json.Serialization.JsonConverter(typeof(SystemJsonConverter))]
#if (USE_NEWTONSOFT_JSON)
[global::Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJsonConverter))]
#endif
public readonly partial record struct STRICT_TYPE : global::StrictlyTyped.IStrictBASE_TYPE_INFORMAL_NAME<STRICT_TYPE>
{
#region Value

    [global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute]
    public required readonly global::System.BASE_TYPE_FORMAL_NAME Value { get; init; }

#endregion Value

#region Creation

    [global::System.Diagnostics.CodeAnalysis.SetsRequiredMembersAttribute]
    public STRICT_TYPE([global::System.Diagnostics.CodeAnalysis.DisallowNullAttribute] global::System.BASE_TYPE_FORMAL_NAME value)
    {
        Value = value;
    }

    public static STRICT_TYPE Create(global::System.BASE_TYPE_FORMAL_NAME value) =>
        new(value);

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE From(global::System.BASE_TYPE_FORMAL_NAME value)
    {
        _preprocess(ref value);
        return new(value);
    }

    public static global::System.Boolean TryFrom(global::System.BASE_TYPE_FORMAL_NAME value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result, out global::System.Collections.Generic.IReadOnlySet<global::System.String> failures)
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

    public static global::System.Boolean TryFrom(global::System.BASE_TYPE_FORMAL_NAME value, [global::System.Diagnostics.CodeAnalysis.MaybeNull, global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE result) =>
        TryFrom(value, out result, out _);

    public static global::System.Boolean TryFrom(global::System.BASE_TYPE_FORMAL_NAME value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE? result, out IReadOnlySet<string> failures)
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

    public static global::System.Boolean TryFrom(global::System.BASE_TYPE_FORMAL_NAME value, [global::System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out STRICT_TYPE? result) =>
        TryFrom(value, out result, out _);

#endregion Creation

#region Cast operators

    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.BASE_TYPE_FORMAL_NAME(STRICT_TYPE value) =>
        value.Value;

    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator STRICT_TYPE(global::System.BASE_TYPE_FORMAL_NAME value) =>
        new(value);

    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator global::System.BASE_TYPE_FORMAL_NAME?(STRICT_TYPE? value) =>
        value.HasValue ? value.Value.Value : null;

    [global::System.Diagnostics.Contracts.Pure]
    public static implicit operator STRICT_TYPE?(global::System.BASE_TYPE_FORMAL_NAME? value) =>
        value.HasValue ? new(value.Value) : null;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator >(STRICT_TYPE left, STRICT_TYPE right) =>
        left.CompareTo(right) > 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator >=(STRICT_TYPE left, STRICT_TYPE right) =>
        left.CompareTo(right) >= 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator <(STRICT_TYPE left, STRICT_TYPE right) =>
        left.CompareTo(right) < 0;

    [global::System.Diagnostics.Contracts.Pure]
    public static global::System.Boolean operator <=(STRICT_TYPE left, STRICT_TYPE right) =>
        left.CompareTo(right) <= 0;

    #endregion Cast operators

#region Validate

    public global::System.Boolean Validate(out global::System.Collections.Generic.IReadOnlyCollection<global::System.String> errors)
    {
        global::System.Collections.Generic.HashSet<global::System.String> problems = new();

        _validate(ref problems);

        errors = global::System.Linq.Enumerable.ToList(problems).AsReadOnly();

        return !errors.Any();
    }

    public global::System.Boolean Validate() =>
        Validate(out _);

#endregion Validate

#region Parsing

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.String? s) =>
        new(global::System.BASE_TYPE_FORMAL_NAME.Parse(s!));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider) =>
        new(global::System.BASE_TYPE_FORMAL_NAME.Parse(s, provider));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.String s, global::System.IFormatProvider? provider) =>
        new(global::System.BASE_TYPE_FORMAL_NAME.Parse(s, provider));

    public static global::System.Boolean TryParse(global::System.String? s, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result) =>
        TryParse(s, null, out result);
    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.ReadOnlySpan<char> s, global::System.Globalization.NumberStyles style, global::System.IFormatProvider? provider) =>
    new(global::System.BASE_TYPE_FORMAL_NAME.Parse(s, style, provider));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE Parse(global::System.String s, global::System.Globalization.NumberStyles style, IFormatProvider? provider) =>
        new(global::System.BASE_TYPE_FORMAL_NAME.Parse(s, style, provider));

    public static global::System.Boolean TryParse(global::System.ReadOnlySpan<global::System.Char> s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result)
    {
        if (global::System.BASE_TYPE_FORMAL_NAME.TryParse(s, provider, out var r))
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

    public static global::System.Boolean TryParse(global::System.String? s, global::System.IFormatProvider? provider, [global::System.Diagnostics.CodeAnalysis.MaybeNullWhen(false)] out STRICT_TYPE result)
    {
        if (global::System.BASE_TYPE_FORMAL_NAME.TryParse(s, provider, out var r))
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

#endregion Parsing

#region Interfaces

    public override global::System.Int32 GetHashCode() =>
        Value.GetHashCode();

    public bool Equals(STRICT_TYPE? other)
    {
        bool result = Value.Equals(other?.Value);
        _overrideEquals(other, ref result);
        return result;
    }

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

    [global::System.Diagnostics.Contracts.Pure]
    public global::System.Int32 CompareTo(STRICT_TYPE other)
    {
        var result = Value.CompareTo(other.Value);
        _overrideCompareTo(other, ref result);
        return result;
    }

#endregion Interfaces

#region Constant Values

    public static STRICT_TYPE NegativeOne => _negativeOne;
    private readonly static STRICT_TYPE _negativeOne = new(-(global::System.BASE_TYPE_FORMAL_NAME)1);

    public static STRICT_TYPE One => _one;
    private readonly static STRICT_TYPE _one = new((global::System.BASE_TYPE_FORMAL_NAME)1);

    public static STRICT_TYPE Zero => _zero;
    private readonly static STRICT_TYPE _zero = new((global::System.BASE_TYPE_FORMAL_NAME)0);

#endregion Constant Values

#region Unary operators

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE operator -(STRICT_TYPE value) =>
        From((global::System.BASE_TYPE_FORMAL_NAME)(-value.Value));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE operator +(STRICT_TYPE value) =>
        From((global::System.BASE_TYPE_FORMAL_NAME)(+value.Value));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE operator ++(STRICT_TYPE value) =>
        From((global::System.BASE_TYPE_FORMAL_NAME)(value.Value + (global::System.BASE_TYPE_FORMAL_NAME)1));

    [global::System.Diagnostics.Contracts.Pure]
    public static STRICT_TYPE operator --(STRICT_TYPE value) =>
        From((global::System.BASE_TYPE_FORMAL_NAME)(value.Value - (global::System.BASE_TYPE_FORMAL_NAME)1));

#endregion Unary operators

#region ToString and Format

    [global::System.Diagnostics.Contracts.Pure]
    public string ToString(global::System.String? format, global::System.IFormatProvider? formatProvider) =>
        Value.ToString(format, formatProvider);

    [global::System.Diagnostics.Contracts.Pure]
    public override global::System.String ToString()
    {
        global::System.String s = Value.ToString();
        _overrideToString(Value, ref s);
        return s;
    }

    public global::System.Boolean TryFormat(global::System.Span<global::System.Char> destination, out global::System.Int32 charsWritten, global::System.ReadOnlySpan<global::System.Char> format, global::System.IFormatProvider? _) =>
        Value.TryFormat(destination, out charsWritten, format);

#endregion ToString and Format

#region Map

    public TResult Map<TResult>(global::System.Func<global::System.BASE_TYPE_FORMAL_NAME, TResult> map) =>
        map(Value);

    public TStrictResult Map<TResult, TStrictResult>(global::System.Func<global::System.BASE_TYPE_FORMAL_NAME, TResult> map) where TStrictResult : struct, global::StrictlyTyped.IStrictType<TStrictResult, TResult> =>
        TStrictResult.From(map(Value));

#endregion Map

#region Converters

    private class Converter : global::StrictlyTyped.StrictTypeConverter<STRICT_TYPE, global::System.BASE_TYPE_FORMAL_NAME> { }

    private sealed class SystemJsonConverter : global::StrictlyTyped.StrictSystemJsonConverter<STRICT_TYPE, global::System.BASE_TYPE_FORMAL_NAME> { }

#if (USE_EF_CORE)
    private class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<STRICT_TYPE, global::System.BASE_TYPE_FORMAL_NAME>
    {
        public EFConverter(global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ConverterMappingHints mappingHints = default!)
            : base(id => id.Value, value => Create(value), mappingHints)
        { }
    }
#endif

#if (USE_NEWTONSOFT_JSON)
    private class NewtonsoftJsonConverter : global::Newtonsoft.Json.JsonConverter<STRICT_TYPE>
    {
        private readonly global::Newtonsoft.Json.JsonSerializer _baseSerializer = new();
        public override STRICT_TYPE ReadJson(global::Newtonsoft.Json.JsonReader reader, global::System.Type objectType, STRICT_TYPE existingValue, global::System.Boolean hasExistingValue, global::Newtonsoft.Json.JsonSerializer serializer) =>
            new (_baseSerializer.Deserialize<global::System.BASE_TYPE_FORMAL_NAME>(reader));

        public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, STRICT_TYPE value, global::Newtonsoft.Json.JsonSerializer serializer) =>
            _baseSerializer.Serialize(writer, value.Value);
    }
#endif

#endregion Converters

#region Partial methods

    static partial void _preprocess(ref global::System.BASE_TYPE_FORMAL_NAME result);

    partial void _overrideEquals(STRICT_TYPE? obj, ref global::System.Boolean result);

    static partial void _overrideToString(global::System.BASE_TYPE_FORMAL_NAME value, ref global::System.String result);

    partial void _overrideCompareTo(global::System.Object? obj, ref global::System.Int32 result);

    partial void _validate(ref global::System.Collections.Generic.HashSet<global::System.String> errors);

#endregion Partial methods
}