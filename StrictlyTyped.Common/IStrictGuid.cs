using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace StrictlyTyped
{
    public interface IStrictGuid<TSelf> : 
            IStrictType<TSelf, Guid>,
            IEquatable<TSelf>,
            IComparable,
            IComparable<TSelf>,
            ISpanFormattable,
            ISpanParsable<TSelf>,
            IEqualityOperators<TSelf, TSelf, bool> 
        where TSelf : 
            struct, IStrictGuid<TSelf> 
    {
        /// <summary>
        /// Creates a new, randomly generated instance of <typeparamref name="TSelf"/>.
        /// </summary>
        /// <remarks>
        /// This static method generates a new, unique value of type <typeparamref name="TSelf"/> 
        /// using a randomization algorithm suitable for creating a <see cref="Guid"/>. 
        /// It is analogous to calling <see cref="Guid.NewGuid"/>, providing a strict type equivalent.
        /// </remarks>
        /// <returns>
        /// A new, unique instance of type <typeparamref name="TSelf"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// EmployeeId newId = EmployeeId.New();
        /// </code>
        /// </example>
        static abstract TSelf New();
        
        /// <summary>
        /// Gets the default, empty instance of <typeparamref name="TSelf"/>.
        /// </summary>
        /// <remarks>
        /// This property represents an empty or uninitialized state for the strict type, 
        /// analogous to <see cref="Guid.Empty"/> in the standard <see cref="Guid"/> type. 
        /// It is useful for representing a default or null-equivalent state for the strict type.
        /// </remarks>
        /// <value>
        /// An instance of <typeparamref name="TSelf"/> that represents the default, empty state.
        /// </value>
        /// <example>
        /// <code>
        /// EmployeeId employeeId = EmployeeId.Empty;
        /// if (employeeId == EmployeeId.Empty)
        /// {
        ///     ...
        /// }
        /// </code>
        /// </example>
        static abstract TSelf Empty { get; }
        
        /// <summary>
        /// Converts the string representation of a <typeparamref name="TSelf"/> to its equivalent strict type instance.
        /// </summary>
        /// <remarks>
        /// Parses a string to create an instance of <typeparamref name="TSelf"/>. 
        /// The format of the string should be compatible with the standard representation of the underlying type, 
        /// in this case, a <see cref="Guid"/>. This method throws an exception if the string is not in a valid format.
        /// </remarks>
        /// <param name="s">A string containing the value to convert. Can be <see langword="null"/>.</param>
        /// <returns>
        /// An instance of <typeparamref name="TSelf"/> equivalent to the value contained in the input string.
        /// </returns>
        /// <exception cref="System.FormatException">
        /// Thrown when the string is not in a format compliant with the underlying type's standard representation.
        /// </exception>
        /// <example>
        /// <code>
        /// string guidString = "d94f1e34-3803-4d23-aa6f-2b8daefdbfbd";
        /// EmployeeId employeeId = EmployeeId.Parse(guidString);
        /// </code>
        /// </example>
        static abstract TSelf Parse(string? s);
        
        /// <summary>
        /// Tries to convert the string representation of a <typeparamref name="TSelf"/> to its equivalent strict type instance, 
        /// and returns a value that indicates whether the conversion succeeded.
        /// </summary>
        /// <remarks>
        /// This method attempts to parse a string to create an instance of <typeparamref name="TSelf"/>. 
        /// It is a safer alternative to <see cref="Parse(string?)"/> as it does not throw an exception 
        /// if the string is not in a valid format, but instead returns <see langword="false"/>.
        /// </remarks>
        /// <param name="s">A string containing the value to convert. Can be <see langword="null"/>.</param>
        /// <param name="result">
        /// When this method returns, contains the <typeparamref name="TSelf"/> equivalent of the value contained in <paramref name="s"/>,
        /// if the conversion succeeded, or the default value of the type if the conversion failed.
        /// The conversion fails if the <paramref name="s"/> parameter is <see langword="null"/> or is not in a format 
        /// compliant with the underlying type's standard representation. This parameter is passed uninitialized.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="s"/> was converted successfully; otherwise, <see langword="false"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// string guidString = "d94f1e34-3803-4d23-aa6f-2b8daefdbfbd";
        /// if (EmployeeId.TryParse(guidString, out EmployeeId employeeId))
        /// {
        ///     // Use employeeId here
        /// }
        /// else
        /// {
        ///     // Handle the case where the string is not a valid EmployeeId
        /// }
        /// </code>
        /// </example>
        static abstract bool TryParse(string? s, out TSelf result);
        
        /// <summary>
        /// Determines whether an instance of the strict type <typeparamref name="TSelf"/> is equal to a <see cref="Guid"/> value.
        /// </summary>
        /// <remarks>
        /// This operator provides a way to compare a strict type instance with a <see cref="Guid"/> value directly, 
        /// facilitating easy checks for equality between the two. It's useful for scenarios where the strict type 
        /// needs to be compared with its base primitive type for equality.
        /// </remarks>
        /// <param name="left">
        /// The instance of the strict type <typeparamref name="TSelf"/> to compare.
        /// </param>
        /// <param name="right">
        /// The <see cref="Guid"/> value to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the value represented by <paramref name="left"/> is equal to <paramref name="right"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// EmployeeId employeeId = EmployeeId.New();
        /// Guid guidValue = employeeId.Value;
        /// bool areEqual = (employeeId == guidValue);
        /// // areEqual is true if guidValue is the same as the value of employeeId.
        /// </code>
        /// </example>
        static abstract bool operator ==(TSelf? left, Guid? right);
        
        /// <summary>
        /// Determines whether an instance of the strict type <typeparamref name="TSelf"/> is not equal to a <see cref="Guid"/> value.
        /// </summary>
        /// <remarks>
        /// This operator provides a way to compare a strict type instance with a <see cref="Guid"/> value directly, 
        /// facilitating easy checks for inequality between the two. It's useful for scenarios where the strict type 
        /// needs to be compared with its base primitive type to determine if they are not equal.
        /// </remarks>
        /// <param name="left">
        /// The instance of the strict type <typeparamref name="TSelf"/> to compare.
        /// </param>
        /// <param name="right">
        /// The <see cref="Guid"/> value to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if the value represented by <paramref name="left"/> is not equal to <paramref name="right"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// EmployeeId employeeId = EmployeeId.New();
        /// Guid anotherGuidValue = Guid.NewGuid();
        /// bool areNotEqual = (employeeId != anotherGuidValue);
        /// // areNotEqual is true if anotherGuidValue is different from the value of employeeId.
        /// </code>
        /// </example>
        static abstract bool operator !=(TSelf? left, Guid? right);
        
        /// <summary>
        /// Determines whether a <see cref="Guid"/> value is equal to an instance of the strict type <typeparamref name="TSelf"/>.
        /// </summary>
        /// <remarks>
        /// This operator enables direct comparison between a <see cref="Guid"/> value and a strict type instance, 
        /// facilitating easy checks for equality. It is useful for cases where a base primitive type needs to be 
        /// compared with a strict type for equality.
        /// </remarks>
        /// <param name="left">
        /// The <see cref="Guid"/> value to compare.
        /// </param>
        /// <param name="right">
        /// The instance of the strict type <typeparamref name="TSelf"/> to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="left"/> is equal to the value represented by <paramref name="right"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// Guid guidValue = Guid.NewGuid();
        /// EmployeeId employeeId = EmployeeId.From(guidValue);
        /// bool areEqual = (guidValue == employeeId);
        /// // areEqual is true if guidValue is the same as the value of employeeId.
        /// </code>
        /// </example>
        static abstract bool operator ==(Guid? left, TSelf? right);
        
        /// <summary>
        /// Determines whether a <see cref="Guid"/> value is not equal to an instance of the strict type <typeparamref name="TSelf"/>.
        /// </summary>
        /// <remarks>
        /// This operator enables direct comparison between a <see cref="Guid"/> value and a strict type instance, 
        /// facilitating easy checks for inequality. It is useful for cases where a base primitive type needs to be 
        /// compared with a strict type to determine if they are not equal.
        /// </remarks>
        /// <param name="left">
        /// The <see cref="Guid"/> value to compare.
        /// </param>
        /// <param name="right">
        /// The instance of the strict type <typeparamref name="TSelf"/> to compare.
        /// </param>
        /// <returns>
        /// <see langword="true"/> if <paramref name="left"/> is not equal to the value represented by <paramref name="right"/>; 
        /// otherwise, <see langword="false"/>.
        /// </returns>
        /// <example>
        /// <code>
        /// Guid guidValue = Guid.NewGuid();
        /// EmployeeId employeeId = EmployeeId.New();
        /// bool areNotEqual = (guidValue != employeeId);
        /// // areNotEqual is true if guidValue is different from the value of employeeId.
        /// </code>
        /// </example>
        static abstract bool operator !=(Guid? left, TSelf? right);
    }
}
