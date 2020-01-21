using System;

namespace TimeMachine
{
    public class TimeTurner
    {
        public DateTime GetEndDate(DateTime start, int minutes)
        {
            var holidays = new HolidayProvider(start.Year);
            DateTime newStartDate = CheckStartDate(start, holidays);
            return CheckEndDate(newStartDate, minutes, holidays);
        }

        private DateTime CheckStartDate(DateTime start, HolidayProvider holidays)
        {
            //Check the start date
            start = holidays.Validate(start);
            //Compensate for Saturday and Sunday
            start = WorkDayProvider.Validate(start);
            //Ensure only work hours are used
            start = WorkHourProvider.Validate(start);
            return start;
        }

        private DateTime CheckEndDate(DateTime newStartDate, int minutes, HolidayProvider holidays)
        {
            var endDate = TimeTools.AddMinutes(newStartDate, minutes);
            endDate = holidays.Validate(endDate);
            endDate = WorkDayProvider.Validate(endDate);
            endDate = WorkHourProvider.Validate(endDate);
            return endDate;
        }        
    }
}
