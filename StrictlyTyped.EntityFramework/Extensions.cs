using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

namespace StrictlyTyped.EntityFramework
{
    public static class Extensions
    {
        public static PropertyBuilder<TStrict> GenerateStrictInt<TStrict>(this PropertyBuilder<TStrict> propertyBuilder) where TStrict : struct, IStrictInt<TStrict> =>
            propertyBuilder.ValueGeneratedOnAdd().HasValueGenerator<StrictIntValueGenerator<TStrict>>();

        public static PropertyBuilder<TStrict> GenerateStrictUInt<TStrict>(this PropertyBuilder<TStrict> propertyBuilder) where TStrict : struct, IStrictUInt<TStrict> =>
            propertyBuilder.ValueGeneratedOnAdd().HasValueGenerator<StrictUIntValueGenerator<TStrict>>();

        public static PropertyBuilder<TStrict> GenerateStrictLong<TStrict>(this PropertyBuilder<TStrict> propertyBuilder) where TStrict : struct, IStrictLong<TStrict> =>
            propertyBuilder.ValueGeneratedOnAdd().HasValueGenerator<StrictLongValueGenerator<TStrict>>();

        public static PropertyBuilder<TStrict> GenerateStrictULong<TStrict>(this PropertyBuilder<TStrict> propertyBuilder) where TStrict : struct, IStrictULong<TStrict> =>
            propertyBuilder.ValueGeneratedOnAdd().HasValueGenerator<StrictULongValueGenerator<TStrict>>();

        public static PropertyBuilder<TStrict> GenerateStrictGuid<TStrict>(this PropertyBuilder<TStrict> propertyBuilder) where TStrict : struct, IStrictGuid<TStrict> =>
            propertyBuilder.ValueGeneratedOnAdd().HasValueGenerator<StrictGuidValueGenerator<TStrict>>();
    }
}
