// using StrictlyTyped;
//
// namespace SourceGeneratorTests
// {
//     public partial class BoolTests
//     {
//         [StrictBool] public partial record struct Test1
//         {
//
//         }
//         [StrictBool] public partial record struct Test2;
//
//         [Fact]
//         public Test1 As()
//         {
//             bool value = true;
//
//             return value.As<Test1>();
//         }
//
//         [Fact]
//         public void AsCreatesStrictTypeWithValue()
//         {
//             bool value = true;
//             Test1 test = value.As<Test1>();
//
//             Assert.Equal(value, test.Value);
//         }
//
//         [Fact]
//         public void AsNullable()
//         {
//             bool? value1 = null;
//
//             Test1? actual1 = value1;
//
//             Assert.False(actual1.HasValue);
//
//             bool? value2 = false;
//
//             Test1? actual2 = value2;
//
//             Assert.True(actual2.HasValue);
//         }
//
//         [Fact]
//         public void EqualToSelf()
//         {
//             var test1 = (Test1)true;
//
//             Assert.Equal(test1, test1);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithSameValueAreEqual()
//         {
//             Test1 one = Test1.True;
//             Test1 two = true;
//
//             Assert.Equal(one, two);
//         }
//
//         [Fact]
//         public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
//         {
//             Test1 one = Test1.True;
//             Test2 two = true;
//
//             Assert.False(one.Equals(two));
//         }
//
//         [Fact]
//         public void EqualsOperator()
//         {
//             Test1 one = true;
//             Test1 two = true;
//
//             Assert.True(one == two);
//         }
//
//         [Fact]
//         public void NotEqualsOperator()
//         {
//             Test1 one = true;
//             Test1 two = false;
//
//             Assert.True(one != two);
//         }
//     }
// }
