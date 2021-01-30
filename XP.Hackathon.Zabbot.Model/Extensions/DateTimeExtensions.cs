using System;

namespace XP.Hackathon.Zabbot.Model.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetBrazilianDate()
        {
            TimeZoneInfo curTimeZone = TimeZoneInfo.Local;
            var time = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById(curTimeZone.Id));
            return time;
            //var brazilDateTimeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, GetBrazilTimeZone());
            //return brazilDateTimeNow;
        }

        private static TimeZoneInfo GetBrazilTimeZone()
        {
            String timeZoneId = "E. South America Standard Time";
            TimeZoneInfo brazilTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            return brazilTimeZone;
        }
    }
}
