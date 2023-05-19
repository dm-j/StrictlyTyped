namespace StrictlyTyped
{
    public interface IStrictDouble<TSelf> : IStrictSignedNumber<TSelf, double>
        where TSelf : struct, IStrictDouble<TSelf>
    {
    }
}
