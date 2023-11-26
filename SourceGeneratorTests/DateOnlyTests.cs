// using Newtonsoft.Json;
// using StrictlyTyped;
// using System.ComponentModel;
//
// namespace SourceGeneratorTests
// {
//     public partial class DateOnlyTests
//     {
//         [StrictDateOnly] public partial record struct Test1;
//         [StrictDateOnly] public partial record struct Test2;
//
//         [Fact]
//         public Test1 As()
//         {
//             var value = DateOnly.Parse("2023/01/13");
//
//             return value.As<Test1>();
//         }
//
//         [Fact]
//         public void AsCreatesStrictTypeWithValue()
//         {
//             var value = DateOnly.Parse("2023/01/13");
//
//             Test1 id = value.As<Test1>();
//
//             Assert.Equal(value, id.Value);
//         }
//
//         [Fact]
//         public void AsForNullDateOnly()
//         {
//             DateOnly? value = null;
//
//             Test1? actual = value.AsNullable<Test1>();
//
//             Assert.Null(actual);
//         }
//
//         [Fact]
//         public void AsFromNullableDateOnly()
//         {
//             DateOnly? value = DateOnly.Parse("2023/01/13");
//             Test1? expected = value;
//
//             Test1? actual = value.AsNullable<Test1>();
//
//             Assert.Equal(expected, actual);
//         }
//
//         [Fact]
//         public void EqualToSelf()
//         {
//             Test1 test1 = DateOnly.Parse("2023/01/13");
//
//             Assert.Equal(test1, test1);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithSameValueAreEqual()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//
//             Test1 one = value.As<Test1>();
//             Test1 two = value.As<Test1>();
//
//             Assert.Equal(one, two);
//         }
//
//         [Fact]
//         public void EqualsOperator()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//
//             Test1 one = value.As<Test1>();
//             Test1 two = value.As<Test1>();
//
//             Assert.True(one == two);
//         }
//
//         [Fact]
//         public void NotEqualsOperator()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//
//             Test1 one = value.As<Test1>();
//             Test1 two = value.As<Test1>();
//
//             Assert.False(one != two);
//         }
//
//         [Fact]
//         public void StrictTypesSameTypeWithDifferentValueAreNotEqual()
//         {
//             DateOnly value1 = DateOnly.Parse("2023/01/13");
//             DateOnly value2 = DateOnly.Parse("2020/07/20");
//
//
//             Test1 one = value1.As<Test1>();
//             Test1 two = value2.As<Test1>();
//
//             Assert.NotEqual(one, two);
//         }
//
//         [Fact]
//         public void NotEqualToNull()
//         {
//             var test1 = (object)DateOnly.Parse("2023/01/13");
//
//             Assert.False(test1.Equals(null!));
//         }
//
//         [Fact]
//         public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
//         {
//             DateOnly value1 = DateOnly.Parse("2023/01/13");
//             DateOnly value2 = DateOnly.Parse("2023/01/13");
//
//
//             Test1 one = value1.As<Test1>();
//             Test2 two = value2.As<Test2>();
//
//             Assert.False(one.Equals(two));
//         }
//
//         [Fact]
//         public void ToStringValue()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//             var test = value.As<Test1>();
//
//             Assert.Equal(value.ToString(), test.ToString());
//         }
//
//         [Fact]
//         public void ParseReturnsExpectedValue()
//         {
//             var value = DateOnly.Parse("2023/01/13");
//             var test1 = new Test1(value);
//
//             var result = Test1.Parse(value.ToString());
//
//             Assert.Equal(test1, result);
//         }
//
//         [Fact]
//         public void ParseThrowsFormatExceptionForInvalidValue()
//         {
//             var invalidValue = "not a value";
//             Assert.Throws<FormatException>(() => Test1.Parse(invalidValue));
//         }
//
//         [Fact]
//         public void CastTest1ToDateOnly()
//         {
//             var test1 = new Test1(DateOnly.Parse("2023/01/13"));
//
//             var result = (DateOnly)test1;
//
//             Assert.Equal(test1.Value, result);
//         }
//
//         [Fact]
//         public void CastDateOnlyToTest1()
//         {
//             var value = DateOnly.Parse("2023/01/13");
//
//             var result = (Test1)value;
//
//             Assert.Equal(value, result.Value);
//         }
//
//         [Fact]
//         public void FromReturnsWithValidDateOnly()
//         {
//             var value = DateOnly.Parse("2023/01/13");
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
//             string test1String = DateOnly.Parse("2023/01/13").ToString();
//             var expected = new Test1(DateOnly.Parse(test1String));
//
//             var result = converter.ConvertFromString(test1String);
//
//             Assert.Equal(expected, result);
//         }
//
//         [Fact]
//         public void TypeConverter_ConvertFromDateOnly()
//         {
//             var converter = TypeDescriptor.GetConverter(typeof(Test1));
//             DateOnly test1DateOnly = DateOnly.Parse("2023/01/13");
//             var expected = new Test1(test1DateOnly);
//
//             var result = converter.ConvertFrom(test1DateOnly);
//
//             Assert.Equal(expected, result);
//         }
//
//         [Fact]
//         public void TryAsTrueAndTStrictFromDateOnly()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//             Test1 expected = Test1.From(value);
//
//             bool success = value.TryAs(out Test1 actual);
//
//             Assert.True(success);
//             Assert.Equal(expected, actual);
//         }
//
//         [Fact]
//         public void TryAsFalseFromNullDateOnly()
//         {
//             DateOnly? value = null;
//             IReadOnlySet<string> expectedFailures = new HashSet<string> { $"Cannot create {typeof(Test1).FullName} from <null>" };
//
//             bool success = value.TryAs(out Test1 _, out IReadOnlySet<string> actualFailures);
//
//             Assert.False(success);
//             Assert.Equal(expectedFailures, actualFailures);
//         }
//
//         [Fact]
//         public void TryAsTrueFromNullableDateOnly()
//         {
//             DateOnly? value = DateOnly.Parse("2023/01/13");
//             Test1 expected = Test1.From(value.Value);
//
//             bool success = value.TryAsNullable(out Test1? actual);
//
//             Assert.True(success);
//             Assert.Equal(expected, actual);
//         }
//
//
//         [Fact]
//         public void TryAsNullableTrueFromNullDateOnly()
//         {
//             DateOnly? value = null;
//
//             bool success = value.TryAsNullable(out Test1? actual);
//
//             Assert.True(success);
//             Assert.Null(actual);
//         }
//
//         [Fact]
//         public void TryAsNullableTrueFromNullableDateOnly()
//         {
//             DateOnly? value = DateOnly.Parse("2023/01/13");
//             Test1 expected = Test1.From(value.Value);
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
//             DateOnly value = DateOnly.Parse("2023/01/13");
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
//             List<Test1> list = Enumerable.Range(0, 10).Select(i => DateOnly.Parse($"2023/{i + 1}/13").As<Test1>()).ToList();
//
//             var result = System.Text.Json.JsonSerializer.Serialize(list);
//
//             Assert.Equal($"[{string.Join(",", list.Select(item => System.Text.Json.JsonSerializer.Serialize(item)))}]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_SystemTextJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(i => DateOnly.Parse($"2023/{i + 1}/13").As<Test1>()).ToList();
//
//             List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_SystemTextJson()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//             Test1 expected = Test1.From(value);
//
//
//             var serializedDateOnly = System.Text.Json.JsonSerializer.Serialize(value);
//             var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);
//
//             var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);
//
//             Assert.Equal(serializedDateOnly, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//             Assert.Equal(expected, deserializedExpected);
//         }
//
//         [Fact]
//         public void Serialize_NewtonsoftJson()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
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
//             List<Test1> list = Enumerable.Range(0, 10).Select(i => DateOnly.Parse($"2023/{i + 1}/13").As<Test1>()).ToList();
//
//             var result = JsonConvert.SerializeObject(list);
//
//             Assert.Equal($"[{(string.Join(",", list.Select(item => JsonConvert.SerializeObject(item))))}]", result, StringComparer.InvariantCultureIgnoreCase);
//         }
//
//         [Fact]
//         public void DeserializeList_NewtonsoftJson()
//         {
//             List<Test1> list = Enumerable.Range(0, 10).Select(i => DateOnly.Parse($"2023/{i + 1}/13").As<Test1>()).ToList();
//
//             List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;
//
//             Assert.Equal(list, result);
//         }
//
//         [Fact]
//         public void SerializesDeserializes_NewtonsoftJson()
//         {
//             DateOnly value = DateOnly.Parse("2023/01/13");
//             Test1 expected = Test1.From(value);
//
//             var serializedDateOnly = JsonConvert.SerializeObject(value);
//             var serializedExpected = JsonConvert.SerializeObject(expected);
//
//             var deserializedExpected = JsonConvert.DeserializeObject<Test1>(serializedExpected);
//
//             Assert.Equal(serializedDateOnly, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//             Assert.Equal(expected, deserializedExpected);
//         }
//     }
// }
