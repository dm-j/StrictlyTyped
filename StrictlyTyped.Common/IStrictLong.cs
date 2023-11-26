namespace StrictlyTyped
{
    public interface IStrictLong<TSelf> : IStrictSignedNumber<TSelf, long>
        where TSelf : struct, IStrictLong<TSelf>
    {
    }
}
