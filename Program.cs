using System;

public class Program
{
	public static void Main()
	{
		var holidays = new HolidayProvider(DateTime.Now.Year);
		Console.WriteLine($"New Years day: {holidays.NewYear.ToShortDateString()}");
		Console.WriteLine($"Memorial day: {holidays.MemorialDay.ToShortDateString()}");
		Console.WriteLine($"Labor day: {holidays.LaborDay.ToShortDateString()}");
		Console.WriteLine($"Thanksgiving: {holidays.Thanksgiving.ToShortDateString()}");
		Console.WriteLine($"Chirstmas: {holidays.Christmas.ToShortDateString()}");
	}
}
