using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayCalculator
{
    public class TimeTurner
    {
        private HolidayProvider Holidays = new HolidayProvider();

        public DateTime GetEndDate(DateTime start, int minutes)
        {
            var endDate = start.AddMinutes(minutes);
            while (Holidays.IsHoliday(endDate))
            {
                endDate.AddDays(1);
            }

            return endDate;
        }
    }
}
