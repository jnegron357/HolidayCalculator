using System;

namespace TimeMachine
{
	public class HolidayProvider
	{
		private int targetYear = 0;
		public DateTime NewYear => new DateTime(targetYear, 1, 1);
		public DateTime Christmas => new DateTime(targetYear, 12, 25);
		public DateTime IndependenceDay => new DateTime(targetYear, 7, 4);
		public DateTime MemorialDay => GetMemorialDay().Value.Date;
		public DateTime Thanksgiving => GetThanksgiving().Value.Date;
		public DateTime LaborDay => GetLaborDay().Value.Date;

		public HolidayProvider(int? year = null)
		{
			if (year != null) targetYear = year.Value;
			targetYear = DateTime.Now.Year;
		}

		public DateTime Validate(DateTime date)
		{
			while (IsHoliday(date)) date = date.AddDays(1);
			return date;
		}

		public bool IsHoliday(DateTime date)
		{
			targetYear = date.Year;
			if (date.Date == NewYear.Date) return true;
			if (date.Date == MemorialDay.Date) return true;
			if (date.Date == IndependenceDay.Date) return true;
			if (date.Date == LaborDay.Date) return true;
			if (date.Date == Thanksgiving.Date) return true;
			if (date.Date == Christmas.Date) return true;
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
			var thanksgiving = TimeTools.GetLastDay(targetYear, 11, DayOfWeek.Thursday);
			return thanksgiving == null ? DateTime.MinValue : thanksgiving;
		}
	}

}
