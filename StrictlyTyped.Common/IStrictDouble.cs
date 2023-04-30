namespace StrictlyTyped
{
    public interface IStrictDouble<TSelf> : IStrictSignedNumber<TSelf, double>
        where TSelf : struct, IStrictDouble<TSelf>
    {

        static abstract implicit operator TSelf?(double? value);
        static abstract implicit operator double?(TSelf? value);
    }
}
