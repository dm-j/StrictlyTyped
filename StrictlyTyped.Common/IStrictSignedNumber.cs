using System.Numerics;

namespace StrictlyTyped
{
    public interface IStrictSignedNumber<TSelf, TBase> 
        : IStrictNumber<TSelf, TBase>,
        IUnaryPlusOperators<TSelf, TSelf>,
        IUnaryNegationOperators<TSelf, TSelf>
        where TSelf : struct, IStrictSignedNumber<TSelf, TBase>
    {
        static abstract TSelf NegativeOne { get; }
    }
}
