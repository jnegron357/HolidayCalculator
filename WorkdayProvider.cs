using System;
using System.Collections.Generic;
using System.Text;

namespace TimeTurner
{
    /// <summary>A component that provides methods for day-of-week calculations</summary>
    public class WorkdayProvider
    {
        private DayOfWeek targetDay = DateTime.Now.DayOfWeek;

        public WorkdayProvider(DayOfWeek? day = null)
        {
            if (day != null) targetDay = day.Value;
        }

        public bool IsWorkDay(DayOfWeek dayOfWeek)
        {
            return (dayOfWeek == targetDay);
        }
    }
}
