// using Newtonsoft.Json;
// using StrictlyTyped;
//
// namespace SourceGeneratorTests
// {
//     public partial class UIntTests
//     { 
//         [StrictUInt] public partial record struct Test1;
//         [StrictUInt] public partial record struct Test2;
//
//         [Fact]
//         public Test1 As()
//         {
//             uint value = 1;
//
//             return value.As<Test1>();
//         }
//
//         [Fact]
//         public void AsCreatesStrictTypeWithValue()
//         {
//             uint value = 1;
//             Test1 test = value.As<Test1>();
//
//             Assert.Equal(value, test.Value);
//         }
//
//         [Fact]
//         public void AsNullableForNullValue()
//         {
//             uint? value = null;
//
//             Test1? actual = value.AsNullable<Test1>();
//
//             Assert.False(actual.HasValue);
//         }
//
//         [Fact]
//         public void EqualToSelf()
//         {
//             var test1 = ((uint)122).As<Test1>();
//
//             Assert.Equal(test1, test1);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithSameValueAreEqual()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)122).As<Test1>();
//
//             Assert.Equal(one, two);
//         }
//
//         [Fact]
//         public void EqualsOperator()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)122).As<Test1>();
//
//             Assert.True(one == two);
//         }
//
//         [Fact]
//         public void NotEqualsOperator()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)2).As<Test1>();
//
//             Assert.True(one != two);
//         }
//
//         [Fact]
//         public void GreaterThanOperator()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)3).As<Test1>();
//
//             Assert.True(one > two);
//         }
//
//         [Fact]
//         public void GreaterThanEqualOperator()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)122).As<Test1>();
//             Test1 three = ((uint)2).As<Test1>();
//
//             Assert.True(two >= three);
//             Assert.True(two >= one);
//         }
//
//         [Fact]
//         public void LessThanOperator()
//         {
//             Test1 one = ((uint)5).As<Test1>();
//             Test1 two = ((uint)122).As<Test1>();
//
//             Assert.True(one < two);
//         }
//
//         [Fact]
//         public void LessThanEqualOperator()
//         {
//             Test1 one = ((uint)7).As<Test1>();
//             Test1 two = ((uint)122).As<Test1>();
//             Test1 three = ((uint)122).As<Test1>();
//
//             Assert.True(one <= two);
//             Assert.True(two <= three);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithDifferentValueAreNotEqual()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test1 two = ((uint)3).As<Test1>();
//
//             Assert.NotEqual(one, two);
//         }
//
//         [Fact]
//         public void NotEqualToNull()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//
//             Assert.False(one.Equals(null));
//         }
//
//         [Fact]
//         public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
//         {
//             Test1 one = ((uint)122).As<Test1>();
//             Test2 two = ((uint)122).As<Test2>();
//
//             Assert.False(one.Equals(two));
//         }
//
//         [Fact]
//         public void ToStringValue()
//         {
//             var value = ((uint)122);
//             Test1 one = value.As<Test1>();
//
//             Assert.Equal(value.ToString(), one.ToString());
//         }
//
//         [Fact]
//         public void Serialize_SystemTextJson()
//         {
//             var value = (uint)100;
//             Test1 expected = Test1.From(value);
//
//             var result = System.Text.Json.JsonSerializer.Serialize(expected);
//
//             Assert.Equal(System.Text.Json.JsonSerializer.Serialize(value), result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void SerializeList_SystemTextJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((uint)v)).ToList();
//
//             var result = System.Text.Json.JsonSerializer.Serialize(list);
//
//             Assert.Equal($"[{(string.Join(",", list.Select(item => item.ToString())))}]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_SystemTextJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((uint)v)).ToList();
//
//             List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_SystemTextJson()
//         {
//             var value = (uint)100;
//             Test1 expected = Test1.From(value);
//
//
//             var serializedGuid = System.Text.Json.JsonSerializer.Serialize(value);
//             var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);
//
//             var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);
//
//             Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//             Assert.Equal(expected, deserializedExpected);
//         }
//
//         [Fact]
//         public void Serialize_NewtonsoftJson()
//         {
//             var value = (uint)100;
//             Test1 expected = Test1.From(value);
//
//             var result = JsonConvert.SerializeObject(expected);
//
//             Assert.Equal(JsonConvert.SerializeObject(value), result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void SerializeList_NewtonsoftJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((uint)v)).ToList();
//
//             var result = JsonConvert.SerializeObject(list);
//
//             Assert.Equal($"[{(string.Join(",", list.Select(item => item.ToString())))}]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_NewtonsoftJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((uint)v)).ToList();
//
//             List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_NewtonsoftJson()
//         {
//             var value = (uint)100;
//             Test1 expected = Test1.From(value);
//
//             var serializedGuid = JsonConvert.SerializeObject(value);
//             var serializedExpected = JsonConvert.SerializeObject(expected);
//
//             var deserializedExpected = JsonConvert.DeserializeObject<Test1>(serializedExpected);
//
//             Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//             Assert.Equal(expected, deserializedExpected);
//         }
//     }
// }
