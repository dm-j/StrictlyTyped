namespace StrictlyTyped
{
    public interface IStrictTimeZone
    {
        static abstract TimeZoneInfo TimeZone { get; }
    }

    public class UtcTimeZone : IStrictTimeZone
    {
        private UtcTimeZone() { }
        public static TimeZoneInfo TimeZone { get; } = TimeZoneInfo.Utc;
    }
}