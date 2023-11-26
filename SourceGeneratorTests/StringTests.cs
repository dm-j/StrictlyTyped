// using Newtonsoft.Json;
// using StrictlyTyped;
// using System.ComponentModel;
//
// namespace SourceGeneratorTests
// {
//     public partial class StringTests
//     {
//         [StrictString] public partial record struct Test1;
//         [StrictString] public partial record struct Test2;
//
//         [Fact]
//         public Test1 As()
//         {
//             return "Hello".As<Test1>();
//         }
//
//         [Fact]
//         public void AsCreatesStrictTypeWithValue()
//         {
//             string value = "Hello";
//             Test1 hello = value.As<Test1>();
//
//             Assert.Equal(value, hello.Value);
//         }
//
//         [Fact]
//         public void AsNullableForNullValue()
//         {
//             string? value = null;
//
//             Test1? actual = value.AsNullable<Test1>();
//
//             Assert.False(actual.HasValue);
//         }
//
//         [Fact]
//         public void EqualToSelf()
//         {
//             var test1 = "Beep".As<Test1>();
//
//             Assert.Equal(test1, test1);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithSameValueAreEqual()
//         {
//             Test1 one = "Beep".As<Test1>();
//             Test1 two = "Beep".As<Test1>();
//
//             Assert.Equal(one, two);
//         }
//
//         [Fact]
//         public void EqualsOperator()
//         {
//             Test1 one = "Boop".As<Test1>();
//             Test1 two = "Boop".As<Test1>();
//
//             Assert.True(one == two);
//         }
//
//         [Fact]
//         public void NotEqualsOperator()
//         {
//             Test1 one = "Boop".As<Test1>();
//             Test1 two = "Beep".As<Test1>();
//
//             Assert.True(one != two);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithDifferentValueAreNotEqual()
//         {
//             Test1 one = "Boop".As<Test1>();
//             Test1 two = "Beep".As<Test1>();
//
//             Assert.NotEqual(one, two);
//         }
//
//         [Fact]
//         public void NotEqualToDefault()
//         {
//             Test1 one = "Boop".As<Test1>();
//
//             Assert.False(one.Equals(default));
//         }
//
//         [Fact]
//         public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
//         {
//             Test1 one = "Boop".As<Test1>();
//             Test2 two = "Boop".As<Test2>();
//
//             Assert.False(one.Equals(two));
//         }
//
//         [Fact]
//         public void ToStringValue()
//         {
//             string value = "Beep";
//             Test1 one = value.As<Test1>();
//
//             Assert.Equal(value, one.ToString());
//         }
//
//         [Fact]
//         public void CastTest1ToString()
//         {
//             Test1 one = "Boop".As<Test1>();
//
//             var result = (string)one;
//
//             Assert.Equal(one.Value, result);
//         }
//
//         [Fact]
//         public void CastStringToTest1()
//         {
//             string value = "Beep";
//
//             var result = (Test1)value;
//
//             Assert.Equal(value, result.Value);
//         }
//
//         [Fact]
//         public void FromReturnsWithValidValue()
//         {
//             string value = "Beep";
//
//             var test1 = Test1.From(value);
//
//             Assert.IsType<Test1>(test1);
//         }
//
//         [Fact]
//         public void TypeConverter_ConvertFromString()
//         {
//             var converter = TypeDescriptor.GetConverter(typeof(Test1));
//             string test1Guid = Guid.NewGuid().ToString();
//             var expected = new Test1(test1Guid);
//
//             var result = converter.ConvertFrom(test1Guid);
//
//             Assert.Equal(expected, result);
//         }
//
//         [Fact]
//         public void TryAsTrueAndTStrictFromString()
//         {
//             string value = "Beep";
//             Test1 expected = Test1.From(value);
//
//             bool success = value.TryAs(out Test1 actual);
//
//             Assert.True(success);
//             Assert.Equal(expected, actual);
//         }
//
//         [Fact]
//         public void TryAsFalseFromNullValue()
//         {
//             string? value = null;
//             IReadOnlySet<string> expectedFailures = new HashSet<string> { $"Cannot create {typeof(Test1).FullName} from <null>" };
//
//             bool success = value!.TryAs(out Test1 _, out IReadOnlySet<string> actualFailures);
//
//             Assert.False(success);
//             Assert.Equal(expectedFailures, actualFailures);
//         }
//
//         [Fact]
//         public void TryAsTrueFromNullableValue()
//         {
//             string? value = "Boop";
//             Test1 expected = Test1.From(value);
//
//             bool success = value.TryAs(out Test1 actual);
//
//             Assert.True(success);
//             Assert.Equal(expected, actual);
//         }
//
//
//         [Fact]
//         public void TryAsNullableTrueFromNullString()
//         {
//             string? value = null;
//
//             bool success = value.TryAsNullable(out Test1? actual);
//
//             Assert.True(success);
//             Assert.Null(actual);
//         }
//
//         [Fact]
//         public void TryAsNullableTrueFromNullableGuid()
//         {
//             string? value = "Beep";
//             Test1 expected = Test1.From(value);
//
//             bool success = value.TryAsNullable(out Test1? actual);
//
//             Assert.True(success);
//             Assert.Equal(expected, actual);
//         }
//
//         [Fact]
//         public void Serialize_SystemTextJson()
//         {
//             string value = "Beep";
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
//             List<Test1> list = new [] { (Test1)"Boop", (Test1)"Beep", (Test1)"Borp", (Test1)"Barp" }.ToList();
//
//             var result = System.Text.Json.JsonSerializer.Serialize(list);
//
//             Assert.Equal($@"[""{(string.Join("\",\"", list.Select(item => item.ToString())))}""]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_SystemTextJson()
//         {
//             List<Test1> list = new[] { (Test1)"Boop", (Test1)"Beep", (Test1)"Borp", (Test1)"Barp" }.ToList();
//
//             List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_SystemTextJson()
//         {
//             string value = "Beep";
//             Test1 expected = Test1.From(value);
//
//
//             var serializedstring = System.Text.Json.JsonSerializer.Serialize(value);
//             var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);
//
//             var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);
//
//             Assert.Equal(serializedstring, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//             Assert.Equal(expected, deserializedExpected);
//         }
//
//         [Fact]
//         public void Serialize_NewtonsoftJson()
//         {
//             string value = "Beep";
//             Test1 expected = Test1.From(value);
//
//             var result = JsonConvert.SerializeObject(expected);
//
//             Assert.Equal(JsonConvert.SerializeObject(value), result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         public class TestSerializeProperty
//         {
//             public Test1 Test1 { get; set; }
//         }
//
//         [Fact]
//         public void SerializeSerializesPropertyNewtonsoftJson()
//         {
//             Test1 value = "Beep".As<Test1>();
//             var valueToSerialize = new TestSerializeProperty { Test1 = value };
//
//             var result = JsonConvert.SerializeObject(valueToSerialize);
//             Assert.Equal(@"{""Test1"":""Beep""}", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//
//         [Fact]
//         public void SerializeList_NewtonsoftJson()
//         {
//             List<Test1> list = new[] { (Test1)"Boop", (Test1)"Beep", (Test1)"Borp", (Test1)"Barp" }.ToList();
//
//             var result = JsonConvert.SerializeObject(list);
//
//             Assert.Equal($@"[""{(string.Join("\",\"", list.Select(item => item.ToString())))}""]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_NewtonsoftJson()
//         {
//             List<Test1> list = new[] { (Test1)"Boop", (Test1)"Beep", (Test1)"Borp", (Test1)"Barp" }.ToList();
//
//             List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_NewtonsoftJson()
//         {
//             string value = "Beep";
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
