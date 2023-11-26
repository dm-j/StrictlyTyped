namespace StrictlyTyped
{
    public interface IStrictInt<TSelf> : IStrictSignedNumber<TSelf, int>
        where TSelf : struct, IStrictInt<TSelf>
    {
    }
}
