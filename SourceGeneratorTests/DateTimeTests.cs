//using Newtonsoft.Json;
//using StrictlyTyped;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SourceGeneratorTests
//{
//    public partial class DateTimeTests
//    {
//        public class CentralUSTimeZone : IStrictTimeZone
//        {
//            public static TimeZoneInfo TimeZone { get; } = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
//        }

//        public class EasternUSTimeZone : IStrictTimeZone
//        {
//            public static TimeZoneInfo TimeZone { get; } = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
//        }

//        //[StrictDateTime] public partial record struct Test1;

//        [Fact]
//        public void ConvertBetweenUTCandUSCentral()
//        {
//            var dateTime = new DateTime(2020, 6, 13, 13, 5, 1);

//            var valueInUtc = new Test1<UtcTimeZone>(dateTime);
//            var valueInCentral = new Test1<CentralUSTimeZone>(dateTime);

//            var fiveHoursAhead = new DateTime(2020, 6, 13, 18, 5, 1);
//            var fiveHoursBehind = new DateTime(2020, 6, 13, 8, 5, 1);
//            var oneHourAhead = new DateTime(2020, 6, 13, 14, 5, 1);

//            Assert.Equal(valueInUtc.Value, dateTime);
//            Assert.Equal(fiveHoursBehind, valueInUtc.InTimeZone<CentralUSTimeZone>().Value);
//            Assert.Equal(fiveHoursAhead, valueInCentral.InTimeZone<UtcTimeZone>().Value);
//            Assert.Equal(oneHourAhead, valueInCentral.InTimeZone<EasternUSTimeZone>().Value);
//        }

//        [Fact]
//        public void ConvertToSameTimeZoneIsEqual()
//        {
//            var dateTime = new DateTime(2020, 6, 13, 13, 5, 1);

//            var valueInUtc = new Test1<UtcTimeZone>(dateTime);
//            var valueInCentral = new Test1<CentralUSTimeZone>(dateTime);

//            Assert.Equal(valueInUtc.Value, valueInUtc.InTimeZone<UtcTimeZone>().Value);
//            Assert.Equal(valueInCentral.Value, valueInCentral.InTimeZone<CentralUSTimeZone>().Value);
//        }

//        [Fact]
//        public void ImplicitConversionFromDateTime()
//        {
//            var dateTime = new DateTime(2020, 6, 13, 13, 5, 1);
//            Test1<UtcTimeZone> value1 = dateTime;
//            Test1<CentralUSTimeZone> value2 = dateTime;

//            Assert.Equal(dateTime, value1.Value);
//            Assert.Equal(dateTime, value2.Value);
//        }

//        [Fact]
//        public void EqualityOperators()
//        {
//            var dateTime = new DateTime(2020, 6, 13, 13, 5, 1);
//            Test1<UtcTimeZone> dateTime1 = dateTime;
//            Test1<UtcTimeZone> dateTime2 = dateTime;

//#pragma warning disable CS1718 // Comparison made to same variable
//            Assert.True(dateTime1 == dateTime1);
//            Assert.True(dateTime1 == dateTime2);
//            Assert.False(dateTime1 != dateTime1);
//            Assert.False(dateTime1 != dateTime2);
//            Assert.True(dateTime1 == dateTime);
//#pragma warning restore CS1718 // Comparison made to same variable
//        }

//        //[Fact]
//        //public void TypeConverter_ConvertFromString()
//        //{
//        //    var converter = TypeDescriptor.GetConverter(typeof(Test1));
//        //    string test1String = DateTime.Parse("2023/01/13").ToString();
//        //    var expected = new Test1(DateTime.Parse(test1String));

//        //    var result = converter.ConvertFromString(test1String);

//        //    Assert.Equal(expected, result);
//        //}

//        //[Fact]
//        //public void TypeConverter_ConvertFromDateTime()
//        //{
//        //    var converter = TypeDescriptor.GetConverter(typeof(Test1));
//        //    DateTime test1DateTime = DateTime.Parse("2023/01/13");
//        //    var expected = new Test1(test1DateTime);

//        //    var result = converter.ConvertFrom(test1DateTime);

//        //    Assert.Equal(expected, result);
//        //}

//        //[Fact]
//        //public void TryAsTrueAndTStrictFromDateTime()
//        //{
//        //    DateTime value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value);

//        //    bool success = value.TryAs(out Test1 actual);

//        //    Assert.True(success);
//        //    Assert.Equal(expected, actual);
//        //}

//        //[Fact]
//        //public void TryAsFalseFromNullDateTime()
//        //{
//        //    DateTime? value = null;
//        //    IReadOnlySet<string> expectedFailures = new HashSet<string> { $"Cannot create {typeof(Test1).FullName} from <null>" };

//        //    bool success = value.TryAs(out Test1 _, out IReadOnlySet<string> actualFailures);

//        //    Assert.False(success);
//        //    Assert.Equal(expectedFailures, actualFailures);
//        //}

//        //[Fact]
//        //public void TryAsTrueFromNullableDateTime()
//        //{
//        //    DateTime? value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value.Value);

//        //    bool success = value.TryAsNullable(out Test1? actual);

//        //    Assert.True(success);
//        //    Assert.Equal(expected, actual);
//        //}


//        //[Fact]
//        //public void TryAsNullableTrueFromNullDateTime()
//        //{
//        //    DateTime? value = null;

//        //    bool success = value.TryAsNullable(out Test1? actual);

//        //    Assert.True(success);
//        //    Assert.Null(actual);
//        //}

//        //[Fact]
//        //public void TryAsNullableTrueFromNullableDateTime()
//        //{
//        //    DateTime? value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value.Value);

//        //    bool success = value.TryAsNullable(out Test1? actual);

//        //    Assert.True(success);
//        //    Assert.Equal(expected, actual);
//        //}

//        //[Fact]
//        //public void Serialize_SystemTextJson()
//        //{
//        //    DateTime value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value);

//        //    var result = System.Text.Json.JsonSerializer.Serialize(expected);

//        //    Assert.Equal(System.Text.Json.JsonSerializer.Serialize(value.ToDateTime(TimeOnly.MinValue)), result, StringComparer.InvariantCultureIgnoreCase);
//        //}

//        //[Fact]
//        //public void SerializeList_SystemTextJson()
//        //{
//        //    List<Test1> list = Enumerable.Range(0, 10).Select(i => DateTime.Parse($"2023/{i + 1}/13").As<Test1<UtcTimeZone>, UtcTimeZone>()).ToList();

//        //    var result = System.Text.Json.JsonSerializer.Serialize(list);

//        //    Assert.Equal($"[{string.Join(",", list.Select(item => System.Text.Json.JsonSerializer.Serialize(item.ToDateTime(TimeOnly.MinValue))))}]", result, StringComparer.InvariantCultureIgnoreCase);
//        //}

//        //[Fact]
//        //public void DeserializeList_SystemTextJson()
//        //{
//        //    List<Test1> list = Enumerable.Range(0, 10).Select(i => DateTime.Parse($"2023/{i + 1}/13").As<Test1<UtcTimeZone>, UtcTimeZone>()).ToList();

//        //    List<Test1> result = System.Text.Json.JsonSerializer.Deserialize<List<Test1>>(System.Text.Json.JsonSerializer.Serialize(list))!;

//        //    Assert.Equal(list, result);
//        //}

//        //[Fact]
//        //public void SerializesDeserializes_SystemTextJson()
//        //{
//        //    DateTime value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1<UtcTimeZone>.From(value);


//        //    var serializedDateTime = System.Text.Json.JsonSerializer.Serialize(value.ToDateTime(TimeOnly.MinValue));
//        //    var serializedExpected = System.Text.Json.JsonSerializer.Serialize(expected);

//        //    var deserializedExpected = System.Text.Json.JsonSerializer.Deserialize<Test1>(serializedExpected);

//        //    Assert.Equal(serializedDateTime, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//        //    Assert.Equal(expected, deserializedExpected);
//        //}

//        //[Fact]
//        //public void Serialize_NewtonsoftJson()
//        //{
//        //    DateTime value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value);

//        //    var result = JsonConvert.SerializeObject(expected);

//        //    Assert.Equal(JsonConvert.SerializeObject(value.ToDateTime(TimeOnly.MinValue)), result, StringComparer.InvariantCultureIgnoreCase);
//        //}

//        //[Fact]
//        //public void SerializeList_NewtonsoftJson()
//        //{
//        //    List<Test1> list = Enumerable.Range(0, 10).Select(i => DateTime.Parse($"2023/{i + 1}/13").As<Test1<UtcTimeZone>, UtcTimeZone>()).ToList();

//        //    var result = JsonConvert.SerializeObject(list);

//        //    Assert.Equal($"[{(string.Join(",", list.Select(item => JsonConvert.SerializeObject(item.ToDateTime(TimeOnly.MinValue)))))}]", result, StringComparer.InvariantCultureIgnoreCase);
//        //}

//        //[Fact]
//        //public void DeserializeList_NewtonsoftJson()
//        //{
//        //    List<Test1> list = Enumerable.Range(0, 10).Select(i => DateTime.Parse($"2023/{i + 1}/13").As<Test1<UtcTimeZone>, UtcTimeZone>()).ToList();

//        //    List<Test1> result = JsonConvert.DeserializeObject<List<Test1>>(JsonConvert.SerializeObject(list))!;

//        //    Assert.Equal(list, result);
//        //}

//        //[Fact]
//        //public void SerializesDeserializes_NewtonsoftJson()
//        //{
//        //    DateTime value = DateTime.Parse("2023/01/13");
//        //    Test1 expected = Test1.From(value);

//        //    var serializedDateTime = JsonConvert.SerializeObject(value.ToDateTime(TimeOnly.MinValue));
//        //    var serializedExpected = JsonConvert.SerializeObject(expected);

//        //    var deserializedExpected = JsonConvert.DeserializeObject<Test1>(serializedExpected);

//        //    Assert.Equal(serializedDateTime, serializedExpected, StringComparer.InvariantCultureIgnoreCase);
//        //    Assert.Equal(expected, deserializedExpected);
//        //}
//    }
//}
