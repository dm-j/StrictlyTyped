namespace StrictlyTyped
{
    public interface IStrictDecimal<TSelf> : IStrictSignedNumber<TSelf, decimal>
        where TSelf : struct, IStrictDecimal<TSelf>
    {
        static abstract implicit operator TSelf(decimal value);
        static abstract implicit operator decimal(TSelf value);
        static abstract implicit operator TSelf?(decimal? value);
        static abstract implicit operator decimal?(TSelf? value);
    }
}
