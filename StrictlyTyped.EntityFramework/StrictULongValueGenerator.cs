using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace StrictlyTyped.EntityFramework
{
    internal class StrictULongValueGenerator<TStrict> : ValueGenerator where TStrict : struct, IStrictULong<TStrict>
    {
        public override bool GeneratesTemporaryValues => true;
        private ulong _value = ulong.MinValue;

        protected override object? NextValue(EntityEntry entry) =>
            // ReSharper disable once HeapView.BoxingAllocation
            TStrict.From(_value++);
    }
}