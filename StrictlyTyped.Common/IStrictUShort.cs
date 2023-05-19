namespace StrictlyTyped
{
    public interface IStrictUShort<TSelf> : IStrictUnsignedNumber<TSelf, ushort>
        where TSelf : struct, IStrictUShort<TSelf>
    {
    }
}
