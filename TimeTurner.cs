using System;

namespace TimeMachine
{
    public class TimeTurner
    {
        private HolidayProvider Holidays;

        public DateTime GetEndDate(DateTime start, int minutes)
        {
            Holidays = new HolidayProvider(start.Year);
            DateTime newStartDate = CheckStartDate(start);
            return CheckEndDate(newStartDate, minutes);
        }

        private DateTime CheckEndDate(DateTime newStartDate, int minutes)
        {
            //Check the end date
            var endDate = newStartDate.AddMinutes(minutes);
            endDate = Holidays.Validate(endDate);
            endDate = WorkDayProvider.Validate(endDate);
            var validTime = WorkHourProvider.GetValidTime(endDate.TimeOfDay);
            endDate = ConstructNewDate(endDate, validTime.Time);
            if (validTime.DayAdded)
            {
                endDate = endDate.AddDays(1);
                endDate = Holidays.Validate(endDate);
                endDate = WorkDayProvider.Validate(endDate);
            }
            return endDate;
        }

        private DateTime CheckStartDate(DateTime start)
        {
            //Check the start date
            start = Holidays.Validate(start);
            //Compensate for Saturday and Sunday
            start = WorkDayProvider.Validate(start);
            //Check the hours
            var validTime = WorkHourProvider.GetValidTime(start.TimeOfDay);
            //Generate new date with valid time
            start = ConstructNewDate(start, validTime.Time);
            if (validTime.DayAdded)
            {
                start = start.AddDays(1);
                start = Holidays.Validate(start);
                start = WorkDayProvider.Validate(start);
            }
            return start;
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
