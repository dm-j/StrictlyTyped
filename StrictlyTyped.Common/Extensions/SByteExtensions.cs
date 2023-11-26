using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this sbyte value)
            where TStrict : struct, IStrictSByte<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this sbyte? value)
            where TStrict : struct, IStrictSByte<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
