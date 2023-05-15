using System.ComponentModel;
using System.Globalization;

namespace StrictlyTyped
{
    /// <summary>
    /// TypeConverter which converts to and from objects of type <see cref="TSelf"/>
    /// </summary>
    public abstract class StrictTypeConverter<TSelf, TBase> : TypeConverter where TSelf : struct, IStrictType<TSelf, TBase>
    {
        private static readonly TypeConverter _baseConverter;

        static StrictTypeConverter()
        {
            _baseConverter = TypeDescriptor.GetConverter(typeof(TBase));
        }

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
            _baseConverter.CanConvertFrom(context, sourceType) || sourceType == typeof(TSelf);

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
            destinationType == typeof(TSelf) || _baseConverter.CanConvertTo(context, destinationType);

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
            TSelf.Create(value is TBase v ? v :(TBase)_baseConverter.ConvertFrom(context, culture, value)!);

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var sourceType = value?.GetType();
            if (value is null || sourceType is null)
                return default;
            
            if (sourceType == destinationType)
                return value;

            if (!_baseConverter.CanConvertFrom(sourceType))
                throw new InvalidCastException($"Cannot convert from {sourceType.GetType().Name}");

            if (destinationType == typeof(TSelf))
                return TSelf.Create((TBase)_baseConverter.ConvertTo(value, typeof(TBase))!);

            if (_baseConverter.CanConvertTo(destinationType))
                return _baseConverter.ConvertTo(value, destinationType);

            throw new InvalidCastException($"Cannot convert {value ?? "<null>"} ({value?.GetType().Name ?? "<null>"}) to {typeof(TSelf).Name}>");
        }
    }
}
