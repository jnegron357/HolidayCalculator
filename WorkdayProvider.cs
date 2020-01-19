using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTurner
{
    /// <summary>A component that provides methods for day-of-week calculations</summary>
    public static class WorkDayProvider
    {
        public static DateTime Validate(DateTime date)
        {
            while (IsNotWorkDay(date)) date.AddDays(1);
            return date;
        }

        public static bool IsNotWorkDay(DateTime dateTime)
        {
            var day = dateTime.DayOfWeek;
            switch (day)
            {
                case DayOfWeek.Sunday:
                    return true;
                case DayOfWeek.Saturday:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsWorkDay(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday:
                    return true;
                case DayOfWeek.Tuesday:
                    return true;
                case DayOfWeek.Wednesday:
                    return true;
                case DayOfWeek.Thursday:
                    return true;
                case DayOfWeek.Friday:
                    return true;
                default:
                    return false;
            }
        }
    }
}
