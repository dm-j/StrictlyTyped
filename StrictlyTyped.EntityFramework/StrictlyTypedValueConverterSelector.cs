using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Concurrent;

namespace StrictlyTyped.EntityFramework;

public static class DbContextConfigurationExtensions
{
    public static void AddStrictTypeConverters(this DbContextOptionsBuilder options) =>
        options.ReplaceService<IValueConverterSelector, StrictTypeConverter>();
}

public class StrictTypeConverter : ValueConverterSelector
{
    // The dictionary in the base type is private, so we need our own one here.
    private readonly ConcurrentDictionary<(Type ModelClrType, Type ProviderClrType), ValueConverterInfo> _converters
        = new ();

    public StrictTypeConverter(ValueConverterSelectorDependencies dependencies) 
        : base(dependencies)
    { }

    public override IEnumerable<ValueConverterInfo> Select(Type modelClrType, Type? providerClrType = null)
    {
        var baseConverters = base.Select(modelClrType, providerClrType);

        foreach (var converter in baseConverters)
        {
            yield return converter;
        }

        var underlyingModelType = modelClrType is null ? default! : Nullable.GetUnderlyingType(modelClrType) ?? modelClrType;
        var underlyingProviderType = providerClrType is null ? default! : Nullable.GetUnderlyingType(providerClrType) ?? providerClrType;

        if (underlyingModelType.IsAssignableTo(typeof(IStrictType)))
        {
            var converterType = underlyingModelType.GetNestedType("EFConverter");

            if (converterType is not null)
            {
                var baseType = 
                    underlyingModelType
                        .GetInterfaces()
                        .Where(intType => intType.IsGenericType && intType.GetGenericTypeDefinition() == typeof(IStrictType<>))
                        .Select(intType => intType.GetGenericArguments()[0])
                        .Single();
                yield return _converters.GetOrAdd(
                    (underlyingModelType, baseType),
                    k => new ValueConverterInfo(modelClrType!, baseType, info => (ValueConverter)Activator.CreateInstance(converterType!, info.MappingHints)!)
                );
            }
        }
    }
}
