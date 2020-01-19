using System;
					
public class Program
{
	public static void Main()
	{
		Console.WriteLine($"New Years day: {HolidayCalculator.NewYear.ToShortDateString()}");
		Console.WriteLine($"Memorial day: {HolidayCalculator.GetMemorialDay().Value.ToShortDateString()}");
		Console.WriteLine($"Labor day: {HolidayCalculator.GetLaborDay().Value.ToShortDateString()}");
		Console.WriteLine($"Thanksgiving: {HolidayCalculator.GetThanksgiving().Value.ToShortDateString()}");
		Console.WriteLine($"Chirstmas: {HolidayCalculator.Christmas.ToShortDateString()}");
	}
}

public static class HolidayCalculator
{
	public static DateTime NewYear = new DateTime(DateTime.Now.Year, 1, 1);
	public static DateTime Christmas = new DateTime(DateTime.Now.Year, 12, 25);
	
	public static DateTime? GetMemorialDay()
	{
		var memorialDay = TimeTools.GetLastDay(DateTime.Now.Year, 5, DayOfWeek.Monday);
		return memorialDay == null ? DateTime.MinValue : memorialDay;
	}
	
	public static DateTime? GetLaborDay()
	{
		var laborDay = TimeTools.GetFirstDay(DateTime.Now.Year, 9, DayOfWeek.Monday);
		return laborDay == null ? DateTime.MinValue : laborDay;
	}

	public static DateTime? GetThanksgiving() 
	{
		var thanksgiving = TimeTools.GetLastDay(DateTime.Now.Year, 11, DayOfWeek.Thursday);
		return thanksgiving == null ? DateTime.MinValue : thanksgiving;
	}

}

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
