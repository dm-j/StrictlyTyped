using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this short value)
            where TStrict : struct, IStrictShort<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this short? value)
            where TStrict : struct, IStrictShort<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
