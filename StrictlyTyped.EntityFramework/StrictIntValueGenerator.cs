using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace StrictlyTyped.EntityFramework
{
    internal class StrictIntValueGenerator<TStrict> : ValueGenerator where TStrict : struct, IStrictInt<TStrict>
    {
        public override bool GeneratesTemporaryValues => true;
        private int _value = int.MinValue;

        protected override object? NextValue(EntityEntry entry) =>
            // ReSharper disable once HeapView.BoxingAllocation
            TStrict.From(_value++);
    }
}