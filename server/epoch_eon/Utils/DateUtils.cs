namespace EpochEon.Utils
{
    public class DateUtils
    {
        private static readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ConvertToTimestamp(DateTime value)
        {
            TimeSpan elapsedTime = value - _epoch;
            return (long)elapsedTime.TotalSeconds;
        }
    }
}
