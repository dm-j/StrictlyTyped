using System.Diagnostics.CodeAnalysis;

// ReSharper disable once CheckNamespace
namespace StrictlyTyped
{
    public interface IStrictType { }

    // ReSharper disable once TypeParameterCanBeVariant
    /// <summary>
    /// Base interface for a strictly-typed value that represents a TBase
    /// </summary>
    /// <typeparam name="TBase">The type wrapped</typeparam>
    public interface IStrictType<TBase> : IStrictType
    {
        TBase Value { get; }

        bool Validate(out IReadOnlyCollection<string> errors);
        bool Validate();
    }

    /// <summary>
    /// Interface for a strictly-typed value that represents a TBase
    /// </summary>
    /// <typeparam name="TSelf">This type</typeparam>
    /// <typeparam name="TBase">The type wrapped</typeparam>
    public interface IStrictType<TSelf, TBase> : IStrictType<TBase>
        where TSelf : IStrictType<TSelf, TBase>
    {
        /// <summary>
        /// Creates a strictly typed value from a literal. Preprocessing performed if implemented.
        /// Validation not performed
        /// </summary>
        /// <param name="value">The value to wrap in the strict type</param>
        /// <returns>A strictly typed value</returns>
        static abstract TSelf From(TBase value);

        /// <summary>
        /// Creates a validated strictly typed value. Validation and preprocessing performed if implemented
        /// </summary>
        /// <param name="value">The value to validate and strictly type</param>
        /// <param name="result">The out parameter that contains a SUCCESSFUL creation</param>
        /// <param name="failures">An enumerable of strings listing reasons why it failed (default: empty)</param>
        /// <returns>Whether or not the creation was successful</returns>
        static abstract bool TryFrom(TBase value, [MaybeNull, NotNullWhen(true)] out TSelf result, out IReadOnlySet<string> failures);
        static abstract bool TryFrom(TBase value, [MaybeNull, NotNullWhen(true)] out TSelf result);

        /// <summary>
        /// Creates a strictly typed value. No validation or preprocessing performed
        /// </summary>
        /// <param name="value">The value to strictly type</param>
        /// <returns>The strictly typed value</returns>
        static abstract TSelf Create(TBase value);

        TResult Map<TResult>(Func<TBase, TResult> map);
        TStrictResult Map<TResult, TStrictResult>(Func<TBase, TResult> map) where TStrictResult : struct, IStrictType<TStrictResult, TResult>;
    }
}
