namespace StrictlyTyped
{
    /// <summary>
    /// Defines a strict boolean type that is comparable and equatable.
    /// </summary>
    /// <typeparam name="TSelf">The type of the implementing type.</typeparam>
    public interface IStrictBool<TSelf> : 
        IStrictType<TSelf, bool>,
        IComparable,
        IComparable<TSelf>,
        IEquatable<TSelf>,
        ISpanParsable<TSelf>
        where TSelf : struct, IStrictBool<TSelf>
    {

        bool IsTrue { get; }
        bool IsFalse { get; }

        static abstract TSelf True { get; }
        static abstract TSelf False { get; }

        static abstract implicit operator TSelf?(bool? value);
        static abstract implicit operator bool?(TSelf? value);
        static abstract implicit operator TSelf(bool value);
        static abstract implicit operator bool(TSelf value);
    }
}
