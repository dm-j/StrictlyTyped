namespace StrictlyTyped
{
    public interface IStrictByte<TSelf> : IStrictUnsignedNumber<TSelf, byte>
        where TSelf : struct, IStrictByte<TSelf>
    {
        static abstract implicit operator TSelf?(byte? value);
        static abstract implicit operator byte?(TSelf? value);
    }
}
