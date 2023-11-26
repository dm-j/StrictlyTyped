using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this float value)
            where TStrict : struct, IStrictFloat<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this float? value)
            where TStrict : struct, IStrictFloat<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
