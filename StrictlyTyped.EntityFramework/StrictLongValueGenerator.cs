using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace StrictlyTyped.EntityFramework
{
    internal class StrictLongValueGenerator<TStrict> : ValueGenerator where TStrict : struct, IStrictLong<TStrict>
    {
        public override bool GeneratesTemporaryValues => true;
        private long _value = long.MinValue;

        protected override object? NextValue(EntityEntry entry) =>
            TStrict.Create(_value++);
    }
}