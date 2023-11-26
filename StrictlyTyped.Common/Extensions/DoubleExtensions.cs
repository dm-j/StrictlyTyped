using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this double value)
            where TStrict : struct, IStrictDouble<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this double? value)
            where TStrict : struct, IStrictDouble<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
