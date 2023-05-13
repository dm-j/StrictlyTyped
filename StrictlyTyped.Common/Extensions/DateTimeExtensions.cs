using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict, TTimeZone>(this DateTime value)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict, TTimeZone>(this DateTime? value)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone =>
            value.HasValue ? TStrict.From(value.Value) : null;

        public static bool TryAs<TStrict, TTimeZone>(this DateTime value, [NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone
        {
            var success = TStrict.TryFrom(value, out var r, out failures);

            result = success ? r : default;

            return success;
        }

        public static bool TryAs<TStrict, TTimeZone>(this DateTime value, [NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone =>
            value.TryAs<TStrict, TTimeZone>(out result, out _);

        public static bool TryAs<TStrict, TTimeZone>(this DateTime? value, [NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone
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

        public static bool TryAsNullable<TStrict, TTimeZone>(this DateTime? value, [NotNullWhen(true)] out TStrict? result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone
        {
            if (value is null)
            {
                result = default!;
                failures = EmptyStringSet.Instance;
                return true;
            }

            var success = TStrict.TryFrom(value.Value, out var r, out failures);

            result = success ? r : default;

            return success;
        }

        public static bool TryAs<TStrict, TTimeZone>(this DateTime? value, [NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone =>
            value.TryAs<TStrict, TTimeZone>(out result, out _);


        public static bool TryAsNullable<TStrict, TTimeZone>(this DateTime? value, [NotNullWhen(true)] out TStrict? result)
            where TStrict : struct, IStrictDateTime<TStrict, TTimeZone>
            where TTimeZone : IStrictTimeZone =>
            value.TryAsNullable<TStrict, TTimeZone>(out result, out _);
    }
}
