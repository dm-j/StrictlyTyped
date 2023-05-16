namespace StrictlyTyped
{
    public interface IStrictInt<TSelf> : IStrictSignedNumber<TSelf, int>
        where TSelf : struct, IStrictInt<TSelf>
    {
        static abstract implicit operator TSelf(int value);
        static abstract implicit operator int(TSelf value);
        static abstract implicit operator TSelf?(int? value);
        static abstract implicit operator int?(TSelf? value);
    }
}
