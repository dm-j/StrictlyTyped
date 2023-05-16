namespace StrictlyTyped
{
    /// <summary>
    /// Defines a strict DateOnly type that is comparable and equatable.
    /// </summary>
    /// <typeparam name="TSelf">The type of the implementing type.</typeparam>
    public interface IStrictDateOnly<TSelf> :
        IStrictType<TSelf, DateOnly>,
        IComparable,
        IComparable<TSelf>,
        IEquatable<TSelf>,
        ISpanParsable<TSelf>
        where TSelf : struct, IStrictDateOnly<TSelf>
    {
        static abstract TSelf Create(DateTime value);

        static abstract implicit operator TSelf?(DateOnly? value);
        static abstract implicit operator DateOnly?(TSelf? value);
        static abstract implicit operator TSelf(DateOnly value);
        static abstract implicit operator DateOnly(TSelf value);

        static abstract implicit operator TSelf?(DateTime? value);
        static abstract implicit operator DateTime?(TSelf? value);
        static abstract implicit operator TSelf(DateTime value);
        static abstract implicit operator DateTime(TSelf value);

        static abstract TSelf From(DateTime dt);

        DateTime ToDateTime(TimeOnly? time = null);
        string ToShortDateString();
    }
}
