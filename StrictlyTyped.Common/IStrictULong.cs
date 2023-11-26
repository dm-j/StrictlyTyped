namespace StrictlyTyped
{
    public interface IStrictULong<TSelf> : IStrictUnsignedNumber<TSelf, ulong>
        where TSelf : struct, IStrictULong<TSelf>
    {
    }
}
