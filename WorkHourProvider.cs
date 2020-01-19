using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TimeTurner
{
    public static class WorkHourProvider
    {
        private static TimeSpan clockIn = new TimeSpan(8, 0, 0);
        private static TimeSpan clockOut = new TimeSpan(12, 0, 0);
        private static TimeSpan clockInAfter = new TimeSpan(1, 0, 0);
        private static TimeSpan clockOutAfter = new TimeSpan(5, 0, 0);
        private static bool isNextDay;

        public static TimeResult GetValidTime(TimeSpan time)
        {
            return new TimeResult
            {
                Time = CheckTime(time),
                DayAdded = isNextDay
            };
        }

        private static TimeSpan CheckTime(TimeSpan time)
        {
            //time is at or before 8AM
            if (time < clockIn) return clockIn;
            //time is between 8AM and 12noon
            if (time >= clockIn && time <= clockOut) return time;
            //time is between 12noon and 1pm
            if (time >= clockOut && time <= clockInAfter) return clockInAfter;
            //time is between 1pm and 5pm
            if (time >= clockInAfter && time < clockOutAfter) return time;
            //time is after 5pm
            if(time >= clockOutAfter)
            {
                isNextDay = true;
                return clockIn;
            }
            return time;
        }
    }

    public struct TimeResult
    {
        public TimeSpan Time { get; set; }
        public bool DayAdded { get; set; }
    }
}
