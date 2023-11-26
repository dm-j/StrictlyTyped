using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this ulong value)
            where TStrict : struct, IStrictULong<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this ulong? value)
            where TStrict : struct, IStrictULong<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
