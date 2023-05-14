using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrictlyTyped.Internal
{
    public class StrictDateTimeSystemJsonConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsGenericType && typeToConvert.IsAssignableTo(typeof(IStrictType<DateTime>));
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            typeToConvert.GetNestedType("SystemJsonConverter");
        }
    }
}
