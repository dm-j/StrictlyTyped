using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace StrictlyTyped.EntityFramework
{
    internal class StrictUIntValueGenerator<TStrict> : ValueGenerator where TStrict : struct, IStrictUInt<TStrict>
    {
        public override bool GeneratesTemporaryValues => true;
        private uint _value = uint.MinValue;

        protected override object? NextValue(EntityEntry entry) =>
            // ReSharper disable once HeapView.BoxingAllocation
            TStrict.From(_value++);
    }
}