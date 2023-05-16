namespace StrictlyTyped
{
    public interface IStrictULong<TSelf> : IStrictUnsignedNumber<TSelf, ulong>
        where TSelf : struct, IStrictULong<TSelf>
    {
        static abstract implicit operator TSelf(ulong value);
        static abstract implicit operator ulong(TSelf value);
        static abstract implicit operator TSelf?(ulong? value);
        static abstract implicit operator ulong?(TSelf? value);
    }
}
