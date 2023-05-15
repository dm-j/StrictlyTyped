using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrictlyTyped
{
    public abstract class StrictSystemJsonConverter<TStrict, TBase> : JsonConverter<TStrict> where TStrict : struct, IStrictType<TStrict, TBase>
    {
        public override TStrict Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            TStrict.Create((TBase)JsonSerializer.Deserialize(ref reader, typeof(TBase), options)!);

        public override void Write(Utf8JsonWriter writer, TStrict value, JsonSerializerOptions options) => 
            JsonSerializer.Serialize(writer, value.Value, options);

        public override bool CanConvert(Type typeToConvert) => 
            typeof(TStrict) == typeToConvert;
    }
}
