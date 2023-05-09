using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace StrictlyTyped.EntityFramework
{
    public class DateOnlyConverter<TStrictDateOnly> : ValueConverter<TStrictDateOnly, DateTime>
        where TStrictDateOnly : struct, IStrictDateOnly<TStrictDateOnly>
    {
        /// <summary>
        /// Creates a new instance of this converter.
        /// </summary>
        public DateOnlyConverter() : base(
                d => d.ToDateTime(TimeOnly.MinValue),
                d => (TStrictDateOnly)TypeDescriptor.GetConverter(typeof(TStrictDateOnly)).ConvertTo(d, typeof(TStrictDateOnly))!)
        { }
    }
}