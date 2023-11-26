using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace StrictlyTyped
{
    public interface IStrictType { }
    
    public interface IStrictType<out TBase> : IStrictType
    {
        /// <summary>
        /// Gets the underlying value of the strict type.
        /// </summary>
        /// <remarks>
        /// This property provides access to the underlying primitive value represented by the strict type instance.
        /// It is a key feature of the strict type system, allowing the encapsulated value to be retrieved and used
        /// in computations or other operations that require the base type.
        /// </remarks>
        /// <value>
        /// The underlying value of type <typeparamref name="TBase"/> that this strict type instance represents.
        /// </value>
        /// <example>
        /// <code>
        /// EmployeeId employeeId = EmployeeId.New();
        /// Guid underlyingValue = employeeId.Value;
        /// // underlyingValue contains the Guid value represented by employeeId.
        /// </code>
        /// </example>
        TBase Value { get; }
    }
    
    public interface IStrictType<out TSelf, TBase> : IStrictType<TBase>
        where TSelf : IStrictType<TSelf, TBase>
    {
        /// <summary>
        /// Creates an instance of <typeparamref name="TSelf"/> from the provided base type value.
        /// </summary>
        /// <remarks>
        /// This method encapsulates the logic to convert from the base type <typeparamref name="TBase"/> 
        /// to the strict type <typeparamref name="TSelf"/>. It is a fundamental method for creating 
        /// strictly typed instances from their underlying primitive types.
        /// For a more convenient way of creating 
        /// strictly typed instances, consider using the extension method 
        /// <see cref="StrictlyTyped.StrictTypeExtensions.As{TSelf}"/>.
        /// </remarks>
        /// <param name="value">
        /// The value of type <typeparamref name="TBase"/> to be converted into a strict type.
        /// </param>
        /// <returns>
        /// An instance of <typeparamref name="TSelf"/> representing the provided <paramref name="value"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// Guid guidValue = Guid.NewGuid();
        /// EmployeeId employeeId = EmployeeId.From(guidValue);
        /// </code>
        /// </example>
        static abstract TSelf From(TBase value);
    }
}
