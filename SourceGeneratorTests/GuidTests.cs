using System.ComponentModel;
using Newtonsoft.Json;
using StrictlyTyped;

namespace SourceGeneratorTests
{
    public partial class GuidTests
    {
         [StrictGuid] public partial record struct Test1;
         [StrictGuid] public partial record struct Test2;
         
         [Fact]
         public void Constructor_InitializesWithValue()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance = new Test1(guid);

             Assert.Equal(guid, instance.Value);
         }
         
         [Fact]
         public void ValueProperty_ReturnsCorrectGuid()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance = new Test1(guid);

             Assert.Equal(guid, instance.Value);
         }
         
         [Fact]
         public void EqualityOperator_ReturnsTrueForEqualStrictTypes()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance1 = new Test1(guid);
             Test1 instance2 = new Test1(guid);

             Assert.True(instance1 == instance2);
         }

         [Fact]
         public void EqualityOperator_ReturnsTrueForStrictTypeAndGuid()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance = new Test1(guid);

             Assert.True(instance == guid);
             Assert.True(guid == instance);
         }

         [Fact]
         public void InequalityOperator_ReturnsTrueForUnequalStrictTypes()
         {
             Test1 instance1 = new Test1(Guid.NewGuid());
             Test1 instance2 = new Test1(Guid.NewGuid());

             Assert.True(instance1 != instance2);
         }
         
         [Fact]
         public void InequalityOperator_ReturnsTrueForStrictTypeAndGuid()
         {
             Test1 instance = new Test1(Guid.NewGuid());
             Guid differentGuid = Guid.NewGuid();

             Assert.True(instance != differentGuid);
             Assert.True(differentGuid != instance);
         }

         [Fact]
         public void EqualityOperator_ReturnsFalseWhenStrictTypeIsNull()
         {
             Test1? instance = null;
             Test1 nonNullInstance = Test1.New();

             Assert.False(instance == nonNullInstance);
             Assert.False(nonNullInstance == instance);
         }
         
         [Fact]
         public void EqualityOperator_ReturnsFalseWhenComparedWithNullGuid()
         {
             Test1 instance = Test1.New();
             Guid? nullGuid = null;

             Assert.False(instance == nullGuid);
             Assert.False(nullGuid == instance);
         }
         
         [Fact]
         public void InequalityOperator_ReturnsTrueWhenStrictTypeIsNull()
         {
             Test1? instance = null;
             Test1 nonNullInstance = Test1.New();

             Assert.True(instance != nonNullInstance);
             Assert.True(nonNullInstance != instance);
         }

         [Fact]
         public void Serialize_SystemTextJson()
         {
             Guid guid = Guid.NewGuid();
             Test1 expected = Test1.From(guid);

             var result = System.Text.Json.JsonSerializer.Serialize(expected);

             Assert.Equal(System.Text.Json.JsonSerializer.Serialize(guid), result, StringComparer.InvariantCultureIgnoreCase);
         }
         
         [Fact]
         public void InequalityOperator_ReturnsTrueWhenComparedWithNullGuid()
         {
             Test1 instance = Test1.New();
             Guid? nullGuid = null;

             Assert.True(instance != nullGuid);
             Assert.True(nullGuid != instance);
         }
         
         [Fact]
         public void CompareTo_OrdersStrictTypesCorrectly()
         {
             var guid1 = Guid.NewGuid();
             var guid2 = Guid.NewGuid();

             var instance1 = new Test1(guid1);
             var instance2 = new Test1(guid2);

             int compareResult = instance1.CompareTo(instance2);
             int expectedCompareResult = guid1.CompareTo(guid2);

             Assert.Equal(expectedCompareResult, compareResult);
         }
         
         [Fact]
         public void CompareTo_SameInstanceReturnsZero()
         {
             var instance = Test1.New();

             Assert.Equal(0, instance.CompareTo(instance));
         }
         
         [Fact]
         public void CompareTo_NullComparisonHandlesCorrectly()
         {
             var instance = Test1.New();

             int compareResult = instance.CompareTo(null);
             
             Assert.True(compareResult > 0);
         }
         
         [Fact]
         public void CompareTo_DifferentTypeThrowsArgumentException()
         {
             var instance = Test1.New();
             var differentType = new object();

             Assert.Throws<ArgumentException>(() => instance.CompareTo(differentType));
         }
         
         [Fact]
         public void ToString_ReturnsCorrectStringRepresentation()
         {
             var guid = Guid.NewGuid();
             var instance = new Test1(guid);

             Assert.Equal(guid.ToString(), instance.ToString());
         }
         
         [Fact]
         public void ToString_WithFormat_ReturnsFormattedString()
         {
             var guid = Guid.NewGuid();
             var instance = new Test1(guid);

             Assert.Equal(guid.ToString("N"), instance.ToString("N"));
         }
        
         [Fact]
         public void Parse_ValidInput_CreatesInstance()
         {
             var guidString = Guid.NewGuid().ToString();
             var instance = Test1.Parse(guidString);

             Assert.Equal(guidString, instance.ToString());
         }
         
         [Fact]
         public void Parse_InvalidInput_ThrowsFormatException()
         {
             var invalidGuidString = "invalid_guid";

             Assert.Throws<FormatException>(() => Test1.Parse(invalidGuidString));
         }
         
         [Fact]
         public void TryParse_ValidInput_ReturnsTrue()
         {
             var guidString = Guid.NewGuid().ToString();
             bool result = Test1.TryParse(guidString, out var instance);

             Assert.True(result);
             Assert.Equal(guidString, instance.ToString());
         }

         [Fact]
         public void TryParse_InvalidInput_ReturnsFalse()
         {
             var invalidGuidString = "invalid_guid";
             bool result = Test1.TryParse(invalidGuidString, out var instance);

             Assert.False(result);
             Assert.Equal(default(Test1), instance);
         }

         [Fact]
         public void From_CreatesInstanceFromGuid()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance = Test1.From(guid);

             Assert.Equal(guid, instance.Value);
         }
         
         [Fact]
         public void Map_TransformsStrictTypeCorrectly()
         {
             Guid guid = Guid.NewGuid();
             Test1 instance = Test1.From(guid);

             string result = instance.Map(guidValue => guidValue.ToString());

             Assert.Equal(guid.ToString(), result);
         }
         
         [Fact]
         public void TryFormat_FormatsCorrectly()
         {
             var guid = Guid.NewGuid();
             var instance = new Test1(guid);
             Span<char> destination = new char[36]; // Adjust the size based on expected format ('D' format for Guid is 36 characters)

             ReadOnlySpan<char> format = "D".AsSpan(); // 'D' format for hyphenated Guid
             bool result = instance.TryFormat(destination, out int charsWritten, format, null);

             Assert.True(result);
             Assert.Equal(guid.ToString("D").Length, charsWritten);
             Assert.Equal(guid.ToString("D"), new string(destination));
         }
         
         [Fact]
         public void Parse_NullOrEmptyString_HandlesGracefully()
         {
             Assert.Throws<ArgumentNullException>(() => Test1.Parse(null!));
             Assert.Throws<FormatException>(() => Test1.Parse(""));
         }
         
         [Fact]
         public void CustomTypeConverter_ConvertsCorrectly()
         {
             var guid = Guid.NewGuid();
             var instance = new Test1(guid);
             var converter = TypeDescriptor.GetConverter(typeof(Test1));

             var convertedTo = converter.ConvertTo(instance, typeof(string));
             var convertedBackObject = converter.ConvertFrom(convertedTo);
             Assert.NotNull(convertedBackObject);

             // Cast the object back to Test1
             var convertedBack = (Test1)convertedBackObject;

             Assert.Equal(guid, convertedBack.Value);
         }
         
         [Fact]
         public void SerializeList_SystemTextJson()
         {
             List<Test1> list = Enumerable.Range(0, 10).Select(_ => Test1.New()).ToList();

             var result = System.Text.Json.JsonSerializer.Serialize(list);

             Assert.Equal(
                 $"""["{(global::System.String.Join("\",\"", list.Select(item => item.ToString())))}"]""", result, StringComparer.InvariantCultureIgnoreCase);
         }

         [Fact]
         public void DeserializeList_SystemTextJson()
         {
             List<Test1> list = Enumerable.Range(0, 10).Select(_ => Test1.New()).ToList();

             List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;

             Assert.Equal(list, result);
         }

         [Fact]
         public void SerializesDeserializes_SystemTextJson()
         {
             Guid guid = Guid.NewGuid();
             Test1 expected = Test1.From(guid);


             var serializedGuid = System.Text.Json.JsonSerializer.Serialize(guid);
             var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);

             var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);

             Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
             Assert.Equal(expected, deserializedExpected);
         }

         [Fact]
         public void Serialize_NewtonsoftJson()
         {
             Guid guid = Guid.NewGuid();
             Test1 expected = Test1.From(guid);

             var result = JsonConvert.SerializeObject(expected);

             Assert.Equal(JsonConvert.SerializeObject(guid), result, StringComparer.InvariantCultureIgnoreCase);
         }

         [Fact]
         public void SerializeList_NewtonsoftJson()
         {
             List<Test1> list = Enumerable.Range(0, 10).Select(_ => Test1.New()).ToList();

             var result = JsonConvert.SerializeObject(list);

             Assert.Equal(
                 $"""["{(global::System.String.Join("\",\"", list.Select(item => item.ToString())))}"]""", result, StringComparer.InvariantCultureIgnoreCase);
         }

         [Fact]
         public void DeserializeList_NewtonsoftJson()
         {
             List<Test1> list = Enumerable.Range(0, 10).Select(_ => Test1.New()).ToList();

             List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;

             Assert.Equal(list, result);
         }

         [Fact]
         public void SerializesDeserializes_NewtonsoftJson()
         {
             Guid guid = Guid.NewGuid();
             Test1 expected = Test1.From(guid);

             var serializedGuid = JsonConvert.SerializeObject(guid);
             var serializedExpected = JsonConvert.SerializeObject(expected);

             var deserializedExpected = JsonConvert.DeserializeObject<Test1>(serializedExpected);

             Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
             Assert.Equal(expected, deserializedExpected);
         }
    }
}
