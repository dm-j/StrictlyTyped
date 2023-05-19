namespace StrictlyTyped
{
    public interface IStrictDecimal<TSelf> : IStrictSignedNumber<TSelf, decimal>
        where TSelf : struct, IStrictDecimal<TSelf>
    {
    }
}
