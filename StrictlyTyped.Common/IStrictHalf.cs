namespace StrictlyTyped
{
    public interface IStrictHalf<TSelf> : IStrictSignedNumber<TSelf, Half>
        where TSelf : struct, IStrictHalf<TSelf>
    {
        static abstract implicit operator TSelf(Half value);
        static abstract implicit operator Half(TSelf value);
        static abstract implicit operator TSelf?(Half? value);
        static abstract implicit operator Half?(TSelf? value);
    }
}
