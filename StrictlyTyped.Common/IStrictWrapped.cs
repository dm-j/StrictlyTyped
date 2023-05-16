using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrictlyTyped.Common
{
    public interface IStrictWrappedStruct<TSelf, TWrapped, TBase> :
        IStrictWrapped<TSelf, TWrapped, TBase>
    where TSelf :
        struct,
        IStrictWrappedStruct<TSelf, TWrapped, TBase>
    where TWrapped :
        struct,
        IStrictType<TWrapped, TBase>
    where
        TBase :
        struct
    {
        static abstract implicit operator TSelf?(TBase? value);
        static abstract implicit operator TBase?(TSelf? value);
    }

    public interface IStrictWrapped<TSelf, TWrapped, TBase> :
        IStrictType<TSelf, TBase>
    where TSelf :
        struct,
        IStrictWrapped<TSelf, TWrapped, TBase>
    where TWrapped :
        struct,
        IStrictType<TWrapped, TBase>
    {
        TWrapped WrappedValue { get; }

        static abstract implicit operator TSelf(TBase value);
        static abstract implicit operator TBase(TSelf value);

        static abstract TSelf Create(TWrapped value);
        static abstract TSelf From(TWrapped value);
        static abstract bool TryFrom(TWrapped value, [MaybeNullWhen(false)] out TSelf result);
        static abstract bool TryFrom(TWrapped value, [MaybeNullWhen(false)] out TSelf result, out IReadOnlyCollection<string> errors);
        static abstract bool TryFrom(TWrapped? value, [MaybeNull] out TSelf? result);
        static abstract bool TryFrom(TWrapped? value, [MaybeNull] out TSelf? result, out IReadOnlyCollection<string> errors);
    }

    public interface IStrictWrappedClass<TSelf, TWrapped, TBase> :
        IStrictWrapped<TSelf, TWrapped, TBase>
    where TSelf :
        struct,
        IStrictWrappedClass<TSelf, TWrapped, TBase>
    where TWrapped :
        struct,
        IStrictType<TWrapped, TBase>
    where
        TBase :
        class
    { }
}
