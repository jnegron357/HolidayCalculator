using System;

public class HolidayProvider
{
	private int targetYear = DateTime.Now.Year;
	public DateTime NewYear = new DateTime(DateTime.Now.Year, 1, 1);
	public DateTime Christmas = new DateTime(DateTime.Now.Year, 12, 25);
	public DateTime IndependenceDay = new DateTime(DateTime.Now.Year, 7, 4);
	public DateTime MemorialDay => GetMemorialDay().Value.Date;
	public DateTime Thanksgiving => GetThanksgiving().Value.Date;
	public DateTime LaborDay => GetLaborDay().Value.Date;

	public HolidayProvider(int? year = null)
	{
		if (year != null) targetYear = year.Value;
	}

	public bool IsHoliday(DateTime date)
	{
		if (date == NewYear) return true;
		if (date == MemorialDay) return true;
		if (date == IndependenceDay) return true;
		if (date == LaborDay) return true;
		if (date == Thanksgiving) return true;
		if (date == Christmas) return true;
		return false;
	}

	private DateTime? GetMemorialDay()
	{	
		var memorialDay = TimeTools.GetLastDay(targetYear, 5, DayOfWeek.Monday);
		return memorialDay == null ? DateTime.MinValue : memorialDay;
	}
	
	private DateTime? GetLaborDay()
	{
		var laborDay = TimeTools.GetFirstDay(targetYear, 9, DayOfWeek.Monday);
		return laborDay == null ? DateTime.MinValue : laborDay;
	}

	private DateTime? GetThanksgiving() 
	{
		var thanksgiving = TimeTools.GetLastDay(DateTime.Now.Year, 11, DayOfWeek.Thursday);
		return thanksgiving == null ? DateTime.MinValue : thanksgiving;
	}

}
