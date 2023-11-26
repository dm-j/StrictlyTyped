namespace StrictlyTyped
{
    public interface IStrictSByte<TSelf> : IStrictSignedNumber<TSelf, sbyte>
        where TSelf : struct, IStrictSByte<TSelf>
    {
    }
}
