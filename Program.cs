using System;

public class Program
{
	public static void Main()
	{
		var holidays = new HolidayCalculator(DateTime.Now.Year);
		Console.WriteLine($"New Years day: {holidays.NewYear.ToShortDateString()}");
		Console.WriteLine($"Memorial day: {holidays.GetMemorialDay().Value.ToShortDateString()}");
		Console.WriteLine($"Labor day: {holidays.GetLaborDay().Value.ToShortDateString()}");
		Console.WriteLine($"Thanksgiving: {holidays.GetThanksgiving().Value.ToShortDateString()}");
		Console.WriteLine($"Chirstmas: {holidays.Christmas.ToShortDateString()}");
	}
}
