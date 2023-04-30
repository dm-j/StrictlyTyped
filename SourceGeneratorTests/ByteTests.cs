using Newtonsoft.Json;
using StrictlyTyped;

namespace SourceGeneratorTests
{
    [StrictByte] public partial record struct TestNotWrapped;

    public partial class ByteTests
    { 
        [StrictByte] public partial record struct Test1;
        [StrictByte] public partial record struct Test2;

        [StrictByte]
        public partial record struct OverrideToString
        {
            static partial void _overrideToString(byte value, ref string result)
            {
                result = $"Overridden {value}";
            }
        }

        [StrictByte]
        public partial record struct PreprocessesToEven
        {
            static partial void _preprocess(ref byte result)
            {
                result = (byte)(result - (result % 2));
            }
        }

        [Fact]
        public Test1 As()
        {
            byte value = 1;

            return value.As<Test1>();
        }

        [Fact]
        public void AsCreatesStrictTypeWithValue()
        {
            byte value = 1;
            Test1 test = value.As<Test1>();

            Assert.Equal(value, test.Value);
        }

        [Fact]
        public void AsNullable()
        {
            byte? value1 = null;

            Test1? actual1 = value1;

            Assert.False(actual1.HasValue);

            byte? value2 = (byte)7;

            Test1? actual2 = value2;

            Assert.True(actual2.HasValue);
        }

        [Fact]
        public void EqualToSelf()
        {
            var test1 = (byte)122;

            Assert.Equal(test1, test1);
        }

        [Fact]
        public void StrictTypesSameTypeWithSameValueAreEqual()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)122;

            Assert.Equal(one, two);
        }

        [Fact]
        public void EqualsOperator()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)122;

            Assert.True(one == two);
        }

        [Fact]
        public void NotEqualsOperator()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)2;

            Assert.True(one != two);
        }

        [Fact]
        public void GreaterThanOperator()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)3;

            Assert.True(one > two);
        }

        [Fact]
        public void GreaterThanEqualOperator()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)122;
            Test1 three = (byte)2;

            Assert.True(two >= three);
            Assert.True(two >= one);
        }

        [Fact]
        public void LessThanOperator()
        {
            Test1 one = (byte)5;
            Test1 two = (byte)122;

            Assert.True(one < two);
        }

        [Fact]
        public void LessThanEqualOperator()
        {
            Test1 one = (byte)7;
            Test1 two = (byte)122;
            Test1 three = (byte)122;

            Assert.True(one <= two);
            Assert.True(two <= three);
        }

        [Fact]
        public void StrictTypesSameTypeWithDifferentValueAreNotEqual()
        {
            Test1 one = (byte)122;
            Test1 two = (byte)3;

            Assert.NotEqual(one, two);
        }

        [Fact]
        public void NotEqualToNull()
        {
            Test1 one = (byte)122;

            Assert.False(one.Equals(null));
        }

        [Fact]
        public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
        {
            Test1 one = (byte)122;
            Test2 two = (byte)122;

            Assert.False(one.Equals(two));
        }

        [Fact]
        public void ToStringValue()
        {
            var value = (byte)122;
            Test1 one = value;

            Assert.Equal(value.ToString(), one.ToString());
        }

        [Fact]
        public void Serialize_SystemTextJson()
        {
            var value = (byte)100;
            Test1 expected = value;

            var result = System.Text.Json.JsonSerializer.Serialize(expected);

            Assert.Equal(System.Text.Json.JsonSerializer.Serialize(value), result, StringComparer.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void SerializeList_SystemTextJson()
        {
            List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((byte)v)).ToList();

            var result = System.Text.Json.JsonSerializer.Serialize(list);

            Assert.Equal($"[{(string.Join(",", list.Select(item => item.ToString())))}]", result, StringComparer.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void DeserializeList_SystemTextJson()
        {
            List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((byte)v)).ToList();

            List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;

            Assert.Equal(list, result);
        }

        [Fact]
        public void SerializesDeserializes_SystemTextJson()
        {
            var value = (byte)100;
            Test1 expected = value;


            var serializedGuid = System.Text.Json.JsonSerializer.Serialize(value);
            var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);

            var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);

            Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
            Assert.Equal(expected, deserializedExpected);
        }

        [Fact]
        public void Serialize_NewtonsoftJson()
        {
            var value = (byte)100;
            Test1 expected = value;

            var result = JsonConvert.SerializeObject(expected);

            Assert.Equal(JsonConvert.SerializeObject(value), result, StringComparer.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void SerializeList_NewtonsoftJson()
        {
            List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((byte)v)).ToList();

            var result = JsonConvert.SerializeObject(list);

            Assert.Equal($"[{(string.Join(",", list.Select(item => item.ToString())))}]", result, StringComparer.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void DeserializeList_NewtonsoftJson()
        {
            List<Test1> list = Enumerable.Range(0, 10).Select(v => Test1.From((byte)v)).ToList();

            List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;

            Assert.Equal(list, result);
        }

        [Fact]
        public void SerializesDeserializes_NewtonsoftJson()
        {
            var value = (byte)100;
            Test1 expected = value;

            var serializedGuid = JsonConvert.SerializeObject(value);
            var serializedExpected = JsonConvert.SerializeObject(expected);

            var deserializedExpected = JsonConvert.DeserializeObject<Test1>(serializedExpected);

            Assert.Equal(serializedGuid, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
            Assert.Equal(expected, deserializedExpected);
        }

        [Fact]
        public void OverrideTheToString()
        {
            byte value = 101;
            Assert.Equal("Overridden 101", value.As<OverrideToString>().ToString());
        }

        [Fact]
        public void PreprocessingPreprocesses()
        {
            var value1 = PreprocessesToEven.From(1);
            var value2 = PreprocessesToEven.From(2);
            var value3 = PreprocessesToEven.From(3);
            var value4 = PreprocessesToEven.From(4);

            Assert.Equal((byte)0, value1.Value);
            Assert.Equal((byte)2, value2.Value);
            Assert.Equal((byte)2, value3.Value);
            Assert.Equal((byte)4, value4.Value);
        }

        [Fact]
        public void CreateDoesNotPreprocess()
        {
            PreprocessesToEven value = 1;

            PreprocessesToEven pre = PreprocessesToEven.Create(value);

            Assert.Equal((byte)1, pre.Value);
        }
    }
}
