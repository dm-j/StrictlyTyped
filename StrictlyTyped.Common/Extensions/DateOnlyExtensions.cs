using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this DateOnly value)
            where TStrict : struct, IStrictDateOnly<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this DateOnly? value)
            where TStrict : struct, IStrictDateOnly<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
