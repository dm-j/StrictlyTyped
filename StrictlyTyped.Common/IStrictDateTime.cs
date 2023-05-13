using System.Numerics;

namespace StrictlyTyped
{
    public interface IStrictDateTime<TSelf> : IStrictType<TSelf, DateTime> where TSelf : struct, IStrictDateTime<TSelf> { }

    public interface IStrictDateTime<TSelf, TTimeZone>
    : IStrictDateTime<TSelf>,
    IComparable,
    IComparable<TSelf>,
    IEqualityOperators<TSelf, TSelf, bool>
    where TSelf : struct, IStrictDateTime<TSelf, TTimeZone>
    where TTimeZone : IStrictTimeZone
    {
        static abstract implicit operator TSelf(DateTime value);
        static abstract implicit operator DateTime(TSelf value);
        static abstract implicit operator TSelf?(DateTime? value);
        static abstract implicit operator DateTime?(TSelf? value);
        static abstract implicit operator TSelf(DateOnly value);
        static abstract implicit operator DateOnly(TSelf value);
        static abstract implicit operator TSelf?(DateOnly? value);
        static abstract implicit operator DateOnly?(TSelf? value);

        DateOnly DateOnly();
        DateOnly DateOnly<TNewTimeZone>() where TNewTimeZone : IStrictTimeZone;
        TStrictDate ToDate<TStrictDate>() where TStrictDate : struct, IStrictDateOnly<TStrictDate>;
        TStrictDate ToDate<TStrictDate, TNewTimeZone>() where TStrictDate : struct, IStrictDateOnly<TStrictDate> where TNewTimeZone : IStrictTimeZone;
    }
}