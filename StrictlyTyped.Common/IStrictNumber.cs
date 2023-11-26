using System.Numerics;

namespace StrictlyTyped
{
    public interface IStrictNumber<TSelf, TBase>
        : IStrictType<TSelf, TBase>,
        IComparable,
        IComparable<TSelf>,
        IEquatable<TSelf>,
        IComparisonOperators<TSelf, TSelf, bool>,
        ISpanFormattable,
        ISpanParsable<TSelf>
    where TSelf
        : struct, 
        IStrictNumber<TSelf, TBase>
    {
        static abstract TSelf One { get; }
        static abstract TSelf Zero { get; }
    }
}
