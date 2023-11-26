using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static class String
    {
        public static int Compare<TStrict>(TStrict? left, TStrict? right, StringComparison comparison) where TStrict : struct, IStrictString<TStrict>
        {
            return System.String.Compare(left?.Value, right?.Value, comparison);
        }

        public static int Compare<TLeft, TRight>(TLeft? left, TRight? right, StringComparison comparison) 
            where TLeft : struct, IStrictString<TLeft>
            where TRight : struct, IStrictString<TRight>
        {
            return System.String.Compare(left?.Value, right?.Value, comparison);
        }
    }

    public static partial class Extensions
    {
        /// <summary>
        /// Creates a nullable strictly typed value from a nullable string
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The (nullable) converted value</returns>
        public static TStrict As<TStrict>([NotNullIfNotNull(nameof(value))] this string value)
            where TStrict : struct, IStrictString<TStrict> =>
            TStrict.From(value);

        /// <summary>
        /// Creates a nullable strictly typed value from a nullable string
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The (nullable) converted value</returns>
        public static TStrict? AsNullable<TStrict>([NotNullIfNotNull(nameof(value))] this string? value)
            where TStrict : struct, IStrictString<TStrict> =>
            value is null ? null : TStrict.From(value);
    }
}
