using Newtonsoft.Json;
using StrictlyTyped;
using System.ComponentModel;

namespace SourceGeneratorTests
{
    public partial class GuidTests
    {
        [StrictGuid] public partial record struct Test1;
        [StrictGuid] public partial record struct Test2;

        [Fact]
        public Test1 As()
        {
            var value = Guid.NewGuid();
            return value.As<Test1>();
        }

        [Fact]
        public void AsCreatesStrictTypeWithValue()
        {
            var value = Guid.NewGuid();

            Test1 id = value.As<Test1>();

            Assert.Equal(value, id.Value);
        }

        [Fact]
        public void AsForNullGuid()
        {
            Guid? guid = null;

            Test1? actual = guid.AsNullable<Test1>();

            Assert.Null(actual);
        }

        [Fact]
        public void AsFromNullableGuid()
        {
            Guid? guid = Guid.NewGuid();
            Test1? expected = guid;

            Test1? actual = guid.AsNullable<Test1>();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void EqualToSelf()
        {
            var test1 = Test1.New();

            Assert.Equal(test1, test1);
        }

        [Fact]
        public void StrictTypesSameTypeWithSameValueAreEqual()
        {
            Guid value = Guid.NewGuid();

            Test1 one = value.As<Test1>();
            Test1 two = value.As<Test1>();

            Assert.Equal(one, two);
        }

        [Fact]
        public void EqualsOperator()
        {
            Guid value = Guid.NewGuid();

            Test1 one = value.As<Test1>();
            Test1 two = value.As<Test1>();

            Assert.True(one == two);
        }

        [Fact]
        public void NotEqualsOperator()
        {
            Guid value = Guid.NewGuid();

            Test1 one = value.As<Test1>();
            Test1 two = value.As<Test1>();

            Assert.False(one != two);
        }

        [Fact]
        public void StrictTypesSameTypeWithDifferentValueAreNotEqual()
        {
            Guid value1 = Guid.NewGuid();
            Guid value2 = Guid.NewGuid();


            Test1 one = value1.As<Test1>();
            Test1 two = value2.As<Test1>();

            Assert.NotEqual(one, two);
        }

        [Fact]
        public void NewCreatesDifferent()
        {
            Test1 one = Test1.New();
            Test1 two = Test1.New();

            Assert.NotEqual(one, two);
        }

        [Fact]
        public void NotEqualToNull()
        {
            var test1 = (object)Test1.New();

            Assert.False(test1.Equals(null!));
        }

        [Fact]
        public void StrictTypesDifferentTypeWithSameValueAreNotEqual()
        {
            Guid value1 = Guid.NewGuid();
            Guid value2 = Guid.NewGuid();


            Test1 one = value1.As<Test1>();
            Test2 two = value2.As<Test2>();

            Assert.False(one.Equals(two));
        }

        [Fact]
        public void ToStringValue()
        {
            Guid value = Guid.NewGuid();
            var test = value.As<Test1>();

            Assert.Equal(value.ToString(), test.ToString());
        }

        [Fact]
        public void ParseReturnsExpectedValue()
        {
            var guid = Guid.NewGuid();
            var test1 = new Test1(guid);

            var result = Test1.Parse(guid.ToString());

            Assert.Equal(test1, result);
        }

        [Fact]
        public void ParseThrowsFormatExceptionForInvalidValue()
        {
            var invalidValue = "not a guid";
            Assert.Throws<FormatException>(() => Test1.Parse(invalidValue));
        }

        [Fact]
        public void CastTest1ToGuid()
        {
            var test1 = new Test1(Guid.NewGuid());

            var result = (Guid)test1;

            Assert.Equal(test1.Value, result);
        }

        [Fact]
        public void CastGuidToTest1()
        {
            var guid = Guid.NewGuid();

            var result = (Test1)guid;

            Assert.Equal(guid, result.Value);
        }

        [Fact]
        public void FromReturnsWithValidGuid()
        {
            var guid = Guid.NewGuid();

            var test1 = Test1.From(guid);

            Assert.IsType<Test1>(test1);
        }

        [Fact]
        public void Empty()
        {
            var expectedValue = new Test1(Guid.Empty);

            var actualValue = Test1.Empty;

            Assert.Equal(expectedValue, actualValue);
            Assert.Equal(Guid.Empty, expectedValue.Value);
        }

        [Fact]
        public void TypeConverter_ConvertFromString()
        {
            var converter = TypeDescriptor.GetConverter(typeof(Test1));
            string test1String = Guid.NewGuid().ToString();
            var expected = new Test1(Guid.Parse(test1String));

            var result = converter.ConvertFromString(test1String);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TypeConverter_ConvertFromGuid()
        {
            var converter = TypeDescriptor.GetConverter(typeof(Test1));
            Guid test1Guid = Guid.NewGuid();
            var expected = new Test1(test1Guid);

            var result = converter.ConvertFrom(test1Guid);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryAsTrueAndTStrictFromGuid()
        {
            Guid guid = Guid.NewGuid();
            Test1 expected = Test1.From(guid);

            bool success = guid.TryAs(out Test1 actual);

            Assert.True(success);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryAsFalseFromNullGuid()
        {
            Guid? guid = null;
            IReadOnlySet<string> expectedFailures = new HashSet<string> { $"Cannot create {typeof(Test1).FullName} from <null>" };

            bool success = guid.TryAs(out Test1 _, out IReadOnlySet<string> actualFailures);

            Assert.False(success);
            Assert.Equal(expectedFailures, actualFailures);
        }

        [Fact]
        public void TryAsTrueFromNullableGuid()
        {
            Guid? guid = Guid.NewGuid();
            Test1 expected = Test1.From(guid.Value);

            bool success = guid.TryAsNullable(out Test1? actual);

            Assert.True(success);
            Assert.Equal(expected, actual);
        }


        [Fact]
        public void TryAsNullableTrueFromNullGuid()
        {
            Guid? guid = null;

            bool success = guid.TryAsNullable(out Test1? actual);

            Assert.True(success);
            Assert.Null(actual);
        }

        [Fact]
        public void TryAsNullableTrueFromNullableGuid()
        {
            Guid? guid = Guid.NewGuid();
            Test1 expected = Test1.From(guid.Value);

            bool success = guid.TryAsNullable(out Test1? actual);

            Assert.True(success);
            Assert.Equal(expected, actual);
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
        public void SerializeList_SystemTextJson()
        {
            List<Test1> list = Enumerable.Range(0, 10).Select(_ => Test1.New()).ToList();

            var result = System.Text.Json.JsonSerializer.Serialize(list);

            Assert.Equal($"[\"{(string.Join("\",\"", list.Select(item => item.ToString())))}\"]", result, StringComparer.InvariantCultureIgnoreCase);
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

            Assert.Equal($"[\"{(string.Join("\",\"", list.Select(item => item.ToString())))}\"]", result, StringComparer.InvariantCultureIgnoreCase);
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
