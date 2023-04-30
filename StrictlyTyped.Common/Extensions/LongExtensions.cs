using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class Extensions
    {
        public static TStrict As<TStrict>(this long value)
            where TStrict : struct, IStrictLong<TStrict> =>
            TStrict.From(value);

        public static TStrict? AsNullable<TStrict>(this long? value)
            where TStrict : struct, IStrictLong<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;

        public static bool TryAs<TStrict>(this long? value, [NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictLong<TStrict>
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

        public static bool TryAsNullable<TStrict>(this long? value, [NotNullWhen(true)] out TStrict result, out IReadOnlySet<string> failures)
            where TStrict : struct, IStrictLong<TStrict>
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

        public static bool TryAs<TStrict>(this long? value, [NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictLong<TStrict> =>
            value.TryAs(out result, out _);


        public static bool TryAsNullable<TStrict>(this long? value, [NotNullWhen(true)] out TStrict result)
            where TStrict : struct, IStrictLong<TStrict> =>
            value.TryAsNullable(out result, out _);
    }
}
