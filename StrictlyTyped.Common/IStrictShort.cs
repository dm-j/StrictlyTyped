namespace StrictlyTyped
{
    public interface IStrictShort<TSelf> : IStrictSignedNumber<TSelf, short>
        where TSelf : struct, IStrictShort<TSelf>
    {
    }
}
