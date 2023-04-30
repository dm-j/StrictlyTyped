using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class StrictTypeExtensions
    {
        /// <summary>
        /// Creates a strictly typed value from a Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The converted value</returns>
        public static TStrict As<TStrict>(this Guid value)
            where TStrict : struct, IStrictGuid<TStrict> =>
            TStrict.From(value);

        /// <summary>
        /// Creates a strictly typed value from a Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The converted value</returns>
        public static TStrict? AsNullable<TStrict>(this Guid? value)
            where TStrict : struct, IStrictGuid<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;

        /// <summary>
        /// Creates a nullable strictly typed value from a Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <param name="result">out result</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAs<TStrict>(this Guid value, [MaybeNull, NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictGuid<TStrict> =>
            TStrict.TryFrom(value, out result, out _);

        /// <summary>
        /// Creates a strictly typed value from a Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="result">out result</param>
        /// <param name="failures">out reasons why conversion failed</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAs<TStrict>(this Guid? value, [MaybeNull, NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictGuid<TStrict>
        {
            if (value is null)
            {
                result = default!;
                failures = new[] { $"Cannot create {typeof(TStrict).FullName} from <null>" }.ToHashSet();
                return false;
            }

            var success = TStrict.TryFrom(value.Value, out var r, out failures);

            result = success ? r : default;

            return success;
        }

        /// <summary>
        /// Creates a nullable strictly typed value from a nullable Guid
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to convert</param>
        /// <param name="result">out result</param>
        /// <param name="failures">out reasons why the conversion failed</param>
        /// <returns>Whether or not the conversion succeeded</returns>
        public static bool TryAsNullable<TStrict>(this Guid? value, out TStrict? result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictGuid<TStrict>
        {
            if (value is null)
            {
                result = default;
                failures = EmptyStringSet.Instance;
                return true;
            }

            var success = TStrict.TryFrom(value.Value, out var r, out failures);

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
        public static bool TryAsNullable<TStrict>(this Guid? value, out TStrict? result)
            where TStrict : struct, IStrictGuid<TStrict> =>
            value.TryAsNullable(out result, out _);
    }
}
