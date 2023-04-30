namespace StrictlyTyped
{
    public interface IStrictShort<TSelf> : IStrictSignedNumber<TSelf, short>
        where TSelf : struct, IStrictShort<TSelf>
    {
        static abstract implicit operator TSelf?(short? value);
        static abstract implicit operator short?(TSelf? value);
    }
}
