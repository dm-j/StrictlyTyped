using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this Half value)
            where TStrict : struct, IStrictHalf<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this Half? value)
            where TStrict : struct, IStrictHalf<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
