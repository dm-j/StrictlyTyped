using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace StrictlyTyped.Swagger
{
    public static class Extensions
    {
        public static void UseStrictTypesDefinedIn(this SwaggerGenOptions options, Assembly assembly)
        {
            foreach (var type in assembly
                                    .GetTypes()
                                    .Select(
                                        type => (type,
                                                @interface: type
                                            .GetInterfaces()
                                            .Where(i => i.IsGenericType).Select(i => i.Name).Where(i => i.StartsWith("IStrict")).Select(i => i[7..]).ToList()))
                                    .Where(type => type.@interface.Any()))
            {
                var map = _map(options, type.type);

                if (type.@interface.Any(i => i.StartsWith("DateOnly")))
                {
                    map(new OpenApiSchema { Type = "string", Default = new OpenApiDate(DateTime.MinValue) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("String")))
                {
                    map(new OpenApiSchema { Type = "string", Default = new OpenApiString(string.Empty) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Guid")))
                {
                    map(new OpenApiSchema { Type = "string", Format = "uuid", Default = new OpenApiString("00000000-0000-0000-0000-000000000000") });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Int")))
                {
                    map(new OpenApiSchema { Type = "integer", Format = "int32", Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Bool")))
                {
                    map(new OpenApiSchema { Type = "boolean", Default = new OpenApiBoolean(false) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Long")))
                {
                    map(new OpenApiSchema { Type = "integer", Format = "int64", Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Float")))
                {
                    map(new OpenApiSchema { Type = "number", Format = "float", Default = new OpenApiFloat(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Decimal")))
                {
                    map(new OpenApiSchema { Type = "number", Default = new OpenApiFloat(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Double")))
                {
                    map(new OpenApiSchema { Type = "number", Format = "float", Default = new OpenApiFloat(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Byte")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = Byte.MaxValue, Minimum = Byte.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Short")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = Int16.MaxValue, Minimum = Int16.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("UShort")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = UInt16.MaxValue, Minimum = UInt16.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("UInt")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = UInt32.MaxValue, Minimum = UInt32.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("ULong")))
                {
                    map(new OpenApiSchema { Type = "integer", Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("SByte")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = SByte.MaxValue, Minimum = SByte.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("UShort")))
                {
                    map(new OpenApiSchema { Type = "integer", Maximum = UInt16.MaxValue, Minimum = UInt16.MinValue, Default = new OpenApiInteger(0) });
                    continue;
                }

                if (type.@interface.Any(i => i.StartsWith("Half")))
                {
                    map(new OpenApiSchema { Type = "number", Maximum = (decimal?)Half.MaxValue, Minimum = (decimal?)Half.MinValue, Default = new OpenApiFloat(0) });
                    continue;
                }
            }
        }

        private static Action<OpenApiSchema> _map(SwaggerGenOptions options, Type type) =>
            schema => options.MapType(type, () => schema);
    }
}