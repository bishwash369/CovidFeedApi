using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeedAPI.Helper
{
    public class DatesDto
    {
        public DatesDto()
        {
            //Daily
            Now = DateTime.UtcNow.ToCst();
            TodayStart = Now.Date;
            TodayEnd = Now.Date.AddDays(1);
            YesterdayStart = TodayStart.AddDays(-1);
            YesterdayEnd = TodayEnd.AddDays(-1);
            if (TodayStart.DayOfWeek == DayOfWeek.Monday)
            {
                YesterdayStart = TodayStart.AddDays(-3);
                YesterdayEnd = TodayEnd.AddDays(-3);
            }
        }

        public DateTime Now { get; set; }
        public DateTime TodayStart { get; private set; }
        public DateTime TodayEnd { get; private set; }
        public DateTime YesterdayStart { get; private set; }
        public DateTime YesterdayEnd { get; private set; }
    }


    public static class DateTimeExtensions
    {
        public static DateTime ToCst(this DateTime utcTime)
        {
            TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime, cstZone);
        }
    }
}
