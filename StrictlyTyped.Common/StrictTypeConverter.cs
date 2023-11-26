using System.ComponentModel;
using System.Globalization;

namespace StrictlyTyped
{
    /// <summary>
    /// TypeConverter which converts to and from objects of type <see cref="TSelf"/>
    /// </summary>
    public abstract class StrictTypeConverter<TSelf, TBase> : TypeConverter where TSelf : struct, IStrictType<TSelf, TBase>
    {
        private readonly TypeConverter _baseConverter = TypeDescriptor.GetConverter(typeof(TBase));

        public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
            _baseConverter.CanConvertFrom(context, sourceType) || sourceType == typeof(TSelf);

        public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
            destinationType == typeof(TSelf) || _baseConverter.CanConvertTo(context, destinationType);

        public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value) =>
            // ReSharper disable once HeapView.BoxingAllocation
            TSelf.From(value is TBase v ? v :(TBase)_baseConverter.ConvertFrom(context, culture, value)!);

        public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
        {
            var sourceType = value?.GetType();
            if (value is null || sourceType is null)
                return default;
            
            if (sourceType == destinationType)
                return value;
            
            if (destinationType == typeof(TSelf))
                // ReSharper disable once HeapView.BoxingAllocation
                return TSelf.From((TBase)_baseConverter.ConvertTo(value, typeof(TBase))!);
            
            if (_baseConverter.CanConvertTo(destinationType))
                return _baseConverter.ConvertTo(value, destinationType);

            throw new InvalidCastException($"Cannot convert {value ?? "<null>"} ({sourceType.Name ?? "<null>"}) to {typeof(TSelf).Name}>");
        }
    }
}
