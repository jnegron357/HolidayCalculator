using System;

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
}
