using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace StrictlyTyped.EntityFramework
{
    internal class StrictGuidValueGenerator<TStrict> : ValueGenerator where TStrict : struct, IStrictGuid<TStrict>
    {
        public override bool GeneratesTemporaryValues => false;

        protected override object? NextValue(EntityEntry entry) =>
            TStrict.New();
    }
}