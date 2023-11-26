using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this decimal value)
            where TStrict : struct, IStrictDecimal<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this decimal? value)
            where TStrict : struct, IStrictDecimal<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
