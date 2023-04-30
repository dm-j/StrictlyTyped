namespace StrictlyTyped
{
    public interface IStrictFloat<TSelf> : IStrictSignedNumber<TSelf, float>
        where TSelf : struct, IStrictFloat<TSelf>
    {
        static abstract implicit operator TSelf?(float? value);
        static abstract implicit operator float?(TSelf? value);
    }
}
