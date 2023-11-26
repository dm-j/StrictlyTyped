using System.Diagnostics.CodeAnalysis;

namespace StrictlyTyped
{
    public static partial class StrictTypeExtensions
    {
        /// <summary>
        /// Converts the specified <see cref="Guid"/> value to its equivalent strict type <typeparamref name="TStrict"/>.
        /// </summary>
        /// <remarks>
        /// This extension method provides a convenient way to convert a <see cref="Guid"/> to a strictly typed instance. 
        /// It internally calls <see cref="IStrictGuid{TStrict}.From(Guid)"/>, encapsulating the conversion logic 
        /// defined in the strict type.
        /// </remarks>
        /// <typeparam name="TStrict">
        /// The type of the strict type to which the <see cref="Guid"/> is being converted. 
        /// This type must implement <see cref="IStrictGuid{TStrict}"/>.
        /// </typeparam>
        /// <param name="value">
        /// The <see cref="Guid"/> value to convert.
        /// </param>
        /// <returns>
        /// A strictly typed instance of <typeparamref name="TStrict"/> representing the <paramref name="value"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// Guid guidValue = Guid.NewGuid();
        /// EmployeeId employeeId = guidValue.As&lt;EmployeeId&gt;();
        /// </code>
        /// </example>
        /// <seealso cref="IStrictGuid{TStrict}.From"/>
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
    }
}
