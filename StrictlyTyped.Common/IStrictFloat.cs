namespace StrictlyTyped
{
    public interface IStrictFloat<TSelf> : IStrictSignedNumber<TSelf, float>
        where TSelf : struct, IStrictFloat<TSelf>
    {
    }
}
