using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this uint value)
            where TStrict : struct, IStrictUInt<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this uint? value)
            where TStrict : struct, IStrictUInt<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
