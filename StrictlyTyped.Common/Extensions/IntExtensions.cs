using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this int value)
            where TStrict : struct, IStrictInt<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this int? value)
            where TStrict : struct, IStrictInt<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
