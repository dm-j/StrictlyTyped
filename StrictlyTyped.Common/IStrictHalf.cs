namespace StrictlyTyped
{
    public interface IStrictHalf<TSelf> : IStrictSignedNumber<TSelf, Half>
        where TSelf : struct, IStrictHalf<TSelf>
    {
    }
}
