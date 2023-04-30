namespace StrictlyTyped
{
    public static partial class Extensions
    {
        /// <summary>
        /// Maps a strict type as though it were the wrapped type
        /// </summary>
        /// <typeparam name="TResult">The result of the Func</typeparam>
        /// <typeparam name="TBase">The base of the strict type</typeparam>
        /// <param name="value">The value to map</param>
        /// <param name="map">The Func to apply to the wrapped value</param>
        /// <returns>The result of the map Func</returns>
        public static TResult Map<TResult, TBase>(this IStrictType<TBase> value, Func<TBase, TResult> map) =>
            map(value.Value);

        /// <summary>
        /// Maps a strict type as though it were the wrapped type and converts the result to another strict type
        /// </summary>
        /// <typeparam name="TBase">The base of the strict type</typeparam>
        /// <typeparam name="TBaseResult">The result of the map Func</typeparam>
        /// <typeparam name="TResult">The strict type to convert the result to</typeparam>
        /// <param name="value">The value to map</param>
        /// <param name="map">The Func to apply to the wrapped value</param>
        /// <returns>The strict type that wraps the result</returns>
        public static TResult Map<TBase, TBaseResult, TResult>(this IStrictType<TBase> value, Func<TBase, TBaseResult> map)
            where TResult : struct, IStrictType<TResult, TBaseResult> =>
            TResult.From(map(value.Value));
    }
}
