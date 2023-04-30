namespace StrictlyTyped
{
    public interface IStrictLong<TSelf> : IStrictSignedNumber<TSelf, long>
        where TSelf : struct, IStrictLong<TSelf>
    {
        static abstract implicit operator TSelf?(long? value);
        static abstract implicit operator long?(TSelf? value);
    }
}
