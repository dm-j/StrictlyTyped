namespace StrictlyTyped
{
    public static partial class Extensions
    {
        /// <summary>
        /// Transforms the value of the specified strict type instance using the provided mapping function.
        /// </summary>
        /// <remarks>
        /// This extension method applies the given function to the value of the strict type instance, 
        /// producing a result of type <typeparamref name="TResult"/>. It offers a versatile way to 
        /// perform transformations or calculations based on the value encapsulated within the strict type.
        /// </remarks>
        /// <typeparam name="TResult">
        /// The type of the result returned by the mapping function.
        /// </typeparam>
        /// <typeparam name="TBase">
        /// The underlying type of the strict type instance.
        /// </typeparam>
        /// <param name="value">
        /// The strict type instance whose value is to be transformed.
        /// </param>
        /// <param name="map">
        /// A function that defines the transformation to be applied to the strict type's value. 
        /// This function takes a parameter of the base type <typeparamref name="TBase"/> and returns a value of type <typeparamref name="TResult"/>.
        /// </param>
        /// <returns>
        /// The result of applying the <paramref name="map"/> function to the value of <paramref name="value"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// IStrictType&lt;int&gt; number = new StrictInteger(5);
        /// int result = number.Map(num => num / 5);
        /// // result is 1
        /// </code>
        /// </example>
        public static TResult Map<TResult, TBase>(this IStrictType<TBase> value, Func<TBase, TResult> map) =>
            map(value.Value);
        
        /// <summary>
        /// Transforms the value of the specified strict type instance and wraps the result in a new strict type.
        /// </summary>
        /// <remarks>
        /// This extension method applies a transformation function to the value of the strict type instance and then 
        /// encapsulates the result in a new strict type instance of type <typeparamref name="TResult"/>. 
        /// It is ideal for situations where a transformation of the value results in a different strict type.
        /// </remarks>
        /// <typeparam name="TBase">
        /// The underlying type of the original strict type instance.
        /// </typeparam>
        /// <typeparam name="TBaseResult">
        /// The type of the intermediate result returned by the transformation function.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the new strict type to which the intermediate result is converted. 
        /// This type must implement <see cref="IStrictType{TResult, TBaseResult}"/>.
        /// </typeparam>
        /// <param name="value">
        /// The strict type instance whose value is to be transformed.
        /// </param>
        /// <param name="map">
        /// A function that defines the transformation to be applied to the strict type's value. 
        /// This function takes a parameter of type <typeparamref name="TBase"/> and returns a value of type <typeparamref name="TBaseResult"/>.
        /// </param>
        /// <returns>
        /// A new strict type instance of type <typeparamref name="TResult"/> representing the original value after applying applying <paramref name="map"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// TemperatureInCelsius temperatureInCelsius = 100d.As&lt;TemperatureInCelsius&gt;();
        /// TemperatureInFahrenheit temperatureInFahrenheit = temperatureInCelsius.Map&lt;double, double, TemperatureInFahrenheit&gt;(celsius => (celsius * 9d) / 5d + 32d);
        /// </code>
        /// </example>
        public static TResult Map<TBase, TBaseResult, TResult>(this IStrictType<TBase> value, Func<TBase, TBaseResult> map)
            where TResult : struct, IStrictType<TResult, TBaseResult> =>
            TResult.From(map(value.Value));
    }
}
