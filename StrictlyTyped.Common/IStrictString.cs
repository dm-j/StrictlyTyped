using System.Numerics;

namespace StrictlyTyped
{
    public interface IStrictString<TSelf> : 
        IStrictType<TSelf, string>,
        IEquatable<TSelf>,
        IComparable,
        IComparable<TSelf>,
        IEqualityOperators<TSelf, TSelf, bool>
        where TSelf : struct, IStrictString<TSelf>
    {
        int Length { get; }

        static abstract bool operator ==(TSelf left, string right);
        static abstract bool operator !=(TSelf left, string right);
        static abstract bool operator ==(string left, TSelf right);
        static abstract bool operator !=(string left, TSelf right);
    }
}
