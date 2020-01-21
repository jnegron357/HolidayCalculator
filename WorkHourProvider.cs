using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TimeMachine
{
    public static class WorkHourProvider
    {
        private static TimeSpan clockIn = new TimeSpan(8, 0, 0);
        private static TimeSpan clockOut = new TimeSpan(12, 0, 0);
        private static TimeSpan clockInAfter = new TimeSpan(13, 0, 0);
        private static TimeSpan clockOutAfter = new TimeSpan(17, 0, 0);

        public static DateTime Validate(DateTime date)
        {
            var time = date.TimeOfDay;
            //time is at or before 8AM
            if (time < clockIn) return GetNewDate(date, time, clockIn);
            //time is between 8AM and 12noon
            if (time >= clockIn && time <= clockOut) return date;
            //time is between 12noon and 1pm
            if (time >= clockOut && time <= clockInAfter) return  GetNewDate(date, time, clockInAfter);
            //time is between 1pm and 5pm
            if (time >= clockInAfter && time < clockOutAfter) return date;
            //time is after 5pm
            if (time >= clockOutAfter)
            {
                var holidays = new HolidayProvider(date.Year);
                date = TimeTools.GetNewDate(date.AddDays(1), clockIn);
                date = WorkDayProvider.Validate(date);
                date = holidays.Validate(date);
            }
            return date;
        }

        private static DateTime GetNewDate(DateTime date, TimeSpan time, TimeSpan clockIn)
        {
            string clientTime = GetTimeString(time);
            string clockInTime = GetTimeString(clockIn);
            var diff = DateTime.Parse(clockInTime).Subtract(DateTime.Parse(clientTime));
            return date.Add(diff);
        }

        private static string GetTimeString(TimeSpan time)
        {
            return (time.Hours > 12) ? $"{time.Hours}:{time.Minutes}:{time.Seconds} PM" : $"{time.Hours}:{time.Minutes}:{time.Seconds} AM";
        }
    }
}
