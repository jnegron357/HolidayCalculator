using System;
using System.Collections.Generic;
using System.Text;
using TimeTurner;

namespace HolidayCalculator
{
    public class TimeTurner
    {
        private HolidayProvider Holidays;

        public TimeTurner(DateTime dateTime)
        {
            Holidays = new HolidayProvider(dateTime.Year);
        }

        public DateTime GetEndDate(DateTime start, int minutes)
        {
            DateTime newStartDate = CheckStartDate(ref start);
            return CheckEndDate(minutes, newStartDate);
        }

        private DateTime CheckEndDate(int minutes, DateTime newStartDate)
        {
            //Check the end date
            var endDate = newStartDate.AddMinutes(minutes);
            endDate = Holidays.Validate(endDate);
            endDate = WorkDayProvider.Validate(endDate);
            var validTime = WorkHourProvider.GetValidTime(endDate.TimeOfDay);
            if (validTime.DayAdded)
            {
                endDate.AddDays(1);
                endDate = Holidays.Validate(endDate);
                endDate = WorkDayProvider.Validate(endDate);
            }
            return ConstructNewDate(endDate, validTime.Time);
        }

        private DateTime CheckStartDate(ref DateTime start)
        {
            //Check the start date
            start = Holidays.Validate(start);
            //Compensate for Saturday and Sunday
            start = WorkDayProvider.Validate(start);
            //Check the hours
            var validTime = WorkHourProvider.GetValidTime(start.TimeOfDay);
            if (validTime.DayAdded)
            {
                start.AddDays(1);
                start = Holidays.Validate(start);
                start = WorkDayProvider.Validate(start);
            }
            //Generate new date
            var newStartDate = ConstructNewDate(start, validTime.Time);
            return newStartDate;
        }

        private DateTime ConstructNewDate(DateTime date, TimeSpan validTime)
        {
            return new DateTime(
                date.Year, 
                date.Month, 
                date.Day, 
                validTime.Hours, 
                validTime.Minutes, 
                validTime.Seconds);
        }
    }
}
