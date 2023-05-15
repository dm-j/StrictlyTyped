using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrictlyTyped
{
    public interface IStrictWrap<TSelf, TWrapped> : IStrictType<TSelf, TWrapped> where TSelf : IStrictWrap<TSelf, TWrapped>
    {
        static abstract implicit operator TSelf?(TWrapped? value);
        static abstract implicit operator TWrapped?(TSelf? value);
    }

    public record struct CBA;

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
    public readonly partial record struct ZYX : global::StrictlyTyped.IStrictWrap<ZYX, global::StrictlyTyped.CBA>
    {
        private static readonly bool _isStruct = Nullable.GetUnderlyingType(typeof(CBA)) is not null;

        [DisallowNull]
        public readonly CBA Value { get; init; }

        public ZYX([DisallowNull] CBA value)
        {
            global::System.ArgumentNullException.ThrowIfNull(value);
            Value = value;
        }

        public static implicit operator ZYX?(CBA? value) =>
            value is null ? null : new(value.Value);


        public static implicit operator CBA?(ZYX? value) =>
            value is null ? null : value.Value.Value;

        public static implicit operator ZYX(CBA value) =>
            new(value);

        public static implicit operator CBA(ZYX value) =>
            value.Value;

        public static ZYX From(CBA value)
        {
            throw new NotImplementedException();
        }

        public static bool TryFrom(CBA value, [MaybeNull, NotNullWhen(true)] out ZYX result, out IReadOnlySet<string> failures)
        {
            throw new NotImplementedException();
        }

        public static bool TryFrom(CBA value, [MaybeNull, NotNullWhen(true)] out ZYX result)
        {
            throw new NotImplementedException();
        }

        public static ZYX Create(CBA value)
        {
            throw new NotImplementedException();
        }

        public TResult Map<TResult>(Func<CBA, TResult> map)
        {
            throw new NotImplementedException();
        }

        public TStrictResult Map<TResult, TStrictResult>(Func<CBA, TResult> map) where TStrictResult : struct, IStrictType<TStrictResult, TResult>
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// TypeConverter which converts to and from objects of type ZYX
        /// </summary>
        private class Converter : global::StrictlyTyped.StrictTypeConverter<ZYX, CBA> { }

        /// <summary>
        /// A JsonConverter for System.Text.Json which converts ZYX transparently to and from Json representations
        /// </summary>
        private sealed class SystemJsonConverter : global::StrictlyTyped.StrictSystemJsonConverter<ZYX, CBA> { }

#if (USE_EF_CORE)
        public class EFConverter : global::Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<ZYX, CBA>
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
                new (_baseSerializer.Deserialize<CBA>(reader));

            public override void WriteJson(global::Newtonsoft.Json.JsonWriter writer, ZYX value, global::Newtonsoft.Json.JsonSerializer serializer) =>
                _baseSerializer.Serialize(writer, value.Value);
        }
#endif
    }
}
