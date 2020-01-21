using System;

namespace TimeMachine
{
	public static class TimeTools
	{	
		///<summary>Gets first occurance of given day in the given month and year</summary>
		public static DateTime? GetFirstDay(int year, int month, DayOfWeek targetDay)
		{
			var daysInMonth = DateTime.DaysInMonth(year, month);		
			for (int day = 1; day <= daysInMonth; day++)
			{
				DateTime currentDateTime = new DateTime(year, month, day);
				if (currentDateTime.DayOfWeek == targetDay)
					return currentDateTime;
			}
			return null;
		}

		///<summary>Gets last occurance of given day in the given month and year</summary>
		public static DateTime? GetLastDay(int year, int month, DayOfWeek targetDay)
		{
			var daysInMonth = DateTime.DaysInMonth(year, month);
			//Loop from the last day to find our Monday much quicker
			for (int day = daysInMonth; day > 0; day--)
			{
				DateTime currentDateTime = new DateTime(year, month, day);
				//The first monday you hit will be the last monday of the month
				//because we're looping from the last day backwards
				if (currentDateTime.DayOfWeek == targetDay)
					return currentDateTime;
			}
			return null;	
		}

		public static DateTime AddMinutes(DateTime date, int minutes, HolidayProvider holidays)
		{
			//NOTE: split this into testable fragments
			int workDayMinutes = 480;
			int halfDayMinutes = 240;
			int lunchMinutes = 60;
			int workDayMinutesWithLunch = workDayMinutes + lunchMinutes;
			int workDays = Math.Abs(minutes / workDayMinutes);
			if (workDays < 1)
			{
				return date.AddMinutes(minutes); ;
			}
			int minLeft = minutes;
			
			//Console.WriteLine($"  work days: {workDays}");

			for (int i = 0; i <= workDays-1; i++)
			{
				if (minLeft > 0 && minLeft < workDayMinutes)
				{
					if (minLeft > halfDayMinutes) minLeft += lunchMinutes;//add the lunch hour for accurate time
					return date.AddMinutes(minLeft);
				}
				date = date.AddMinutes(workDayMinutesWithLunch);
				minLeft -= workDayMinutes;
				if (minLeft >= workDayMinutes) date = GetNewWorkDay(date, holidays);
			}
			return date;
		}

		private static DateTime GetNewWorkDay(DateTime date, HolidayProvider holidays)
		{
			var newDate = GetNewDate(date.AddDays(1), new TimeSpan(8, 0, 0));
			newDate = WorkDayProvider.Validate(newDate, holidays);
			newDate = WorkHourProvider.Validate(newDate, holidays);
			return holidays.Validate(newDate);
		}

		public static DateTime GetNewDate(DateTime date, TimeSpan time)
		{
			return new DateTime(
				date.Year,
				date.Month,
				date.Day,
				time.Hours,
				time.Minutes,
				time.Seconds);
		}

		public static string GetDateString(this DateTime date)
		{
			return $"{date.ToLongDateString()} {date.ToLongTimeString()}";
		}
	}
}
