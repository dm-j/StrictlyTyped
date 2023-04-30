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

        /// <summary>
        /// Creates a strictly typed value from a string
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <param name="result">out result</param>
        /// <param name="failures">out reasons why conversion failed</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAs<TStrict>(this string value, [MaybeNull, NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictString<TStrict> =>
            TStrict.TryFrom(value, out result, out failures);

        /// <summary>
        /// Creates a strictly typed value from a string
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <param name="result">out result</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAs<TStrict>(this string value, [MaybeNull, NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictString<TStrict> =>
            TStrict.TryFrom(value, out result, out _);

        /// <summary>
        /// Creates a nullable strictly typed value from a nullable Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="result">out result</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAsNullable<TStrict>(this string? value, out TStrict? result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictString<TStrict>
        {
            if (value is null)
            {
                result = default;
                failures = EmptyStringSet.Instance;
                return true;
            }

            var success = TStrict.TryFrom(value, out var r, out failures);

            result = success ? r : default;

            return success;
        }

        /// <summary>
        /// Creates a nullable strictly typed value from a nullable Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="result">out result</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAsNullable<TStrict>(this string? value, out TStrict? result)
            where TStrict : struct, IStrictString<TStrict> =>
            value.TryAsNullable(out result, out _);
    }
}
