namespace StrictlyTyped
{
    public interface IStrictSByte<TSelf> : IStrictSignedNumber<TSelf, sbyte>
        where TSelf : struct, IStrictSByte<TSelf>
    {
        static abstract implicit operator TSelf?(sbyte? value);
        static abstract implicit operator sbyte?(TSelf? value);
    }
}
