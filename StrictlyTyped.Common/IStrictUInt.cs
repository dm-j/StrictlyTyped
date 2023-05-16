namespace StrictlyTyped
{
    public interface IStrictUInt<TSelf> : IStrictUnsignedNumber<TSelf, uint>
        where TSelf : struct, IStrictUInt<TSelf>
    {
        static abstract implicit operator TSelf(uint value);
        static abstract implicit operator uint(TSelf value);
        static abstract implicit operator TSelf?(uint? value);
        static abstract implicit operator uint?(TSelf? value);
    }
}
