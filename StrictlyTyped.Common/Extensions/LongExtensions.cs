using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this long value)
            where TStrict : struct, IStrictLong<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this long? value)
            where TStrict : struct, IStrictLong<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
