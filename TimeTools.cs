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

		public static DateTime AddMinutes(DateTime date, int minutes)
		{
			//NOTE: split this into testable fragments
			int workDayMinutes = 480;
			int halfDayMinutes = 240;
			int workDays = Math.Abs(minutes / workDayMinutes);
			if (workDays < 1)
			{
				return date.AddMinutes(minutes); ;
			}
			int minLeft = workDayMinutes;
			for (int i = 0; i <= workDays; i++)
			{
				if (minLeft > 0 && minLeft < workDayMinutes)
				{
					if (minLeft > halfDayMinutes) minLeft += 60;//add the lunch hour for accurate time
					return date.AddMinutes(minLeft);
				}
				date = date.AddDays(1);
				minLeft = minutes - workDayMinutes;
			}
			return date;
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

	}

}
