namespace StrictlyTyped
{
    public static partial class Extensions
    {
        /// <summary>
        /// Creates a strictly-typed value from a <see cref="bool"/>
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The converted value</returns>
        public static TStrict As<TStrict>(this bool value)
            where TStrict : struct, IStrictBool<TStrict> =>
            TStrict.From(value);

        /// <summary>
        /// Creates a strictly typed value from a nullable <see cref="bool"/>
        /// </summary>
        /// <typeparam name="TStrict">Destination type</typeparam>
        /// <param name="value">The value to attempt to convert</param>
        /// <returns>The converted value</returns>
        public static TStrict? AsNullable<TStrict>(this bool? value)
            where TStrict : struct, IStrictBool<TStrict> =>
            value.HasValue ? TStrict.From(value.Value) : null;
    }
}
