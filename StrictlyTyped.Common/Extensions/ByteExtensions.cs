using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this byte value)
            where TStrict : struct, IStrictByte<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this byte? value)
            where TStrict : struct, IStrictByte<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
