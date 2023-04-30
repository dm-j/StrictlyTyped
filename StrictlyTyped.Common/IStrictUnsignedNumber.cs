namespace StrictlyTyped
{
    public interface IStrictUnsignedNumber<TSelf, TBase>
        : IStrictNumber<TSelf, TBase>
        where TSelf : struct, IStrictUnsignedNumber<TSelf, TBase>
    { }
}
