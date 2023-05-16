namespace StrictlyTyped
{
    public interface IStrictUShort<TSelf> : IStrictUnsignedNumber<TSelf, ushort>
        where TSelf : struct, IStrictUShort<TSelf>
    {
        static abstract implicit operator TSelf(ushort value);
        static abstract implicit operator ushort(TSelf value);
        static abstract implicit operator TSelf?(ushort? value);
        static abstract implicit operator ushort?(TSelf? value);
    }
}
