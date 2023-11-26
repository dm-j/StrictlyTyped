namespace StrictlyTyped
{
    public interface IStrictByte<TSelf> : IStrictUnsignedNumber<TSelf, byte>
        where TSelf : struct, IStrictByte<TSelf>
    { }
}
