using System;

public class HolidayCalculator
{
	private int targetYear = DateTime.Now.Year;

	public HolidayCalculator(int? year = null)
	{
		if (year != null) targetYear = year.Value;
	}
	public DateTime NewYear = new DateTime(DateTime.Now.Year, 1, 1);
	public DateTime Christmas = new DateTime(DateTime.Now.Year, 12, 25);

	public DateTime? GetMemorialDay()
	{
		var memorialDay = TimeTools.GetLastDay(targetYear, 5, DayOfWeek.Monday);
		return memorialDay == null ? DateTime.MinValue : memorialDay;
	}
	
	public DateTime? GetLaborDay()
	{
		var laborDay = TimeTools.GetFirstDay(targetYear, 9, DayOfWeek.Monday);
		return laborDay == null ? DateTime.MinValue : laborDay;
	}

	public DateTime? GetThanksgiving() 
	{
		var thanksgiving = TimeTools.GetLastDay(DateTime.Now.Year, 11, DayOfWeek.Thursday);
		return thanksgiving == null ? DateTime.MinValue : thanksgiving;
	}

}
