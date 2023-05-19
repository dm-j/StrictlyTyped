namespace StrictlyTyped
{
    public interface IStrictUInt<TSelf> : IStrictUnsignedNumber<TSelf, uint>
        where TSelf : struct, IStrictUInt<TSelf>
    {
    }
}
