using System;
using TimeMachine;

public class Program
{
	public static void Main()
	{
		DateTime dateTest1 = new DateTime(2018, 1, 3, 6, 0, 0);
		DateTime dateTest2 = new DateTime(2018, 7, 3, 21, 0, 0);
		DateTime dateTest3 = new DateTime(2018, 8, 21, 5, 0, 0);
		TimeTurner timeTurner = new TimeTurner();
		Console.WriteLine(timeTurner.GetEndDate(dateTest1, 55).ToString());
		Console.WriteLine(timeTurner.GetEndDate(dateTest2, 720).ToString());
		Console.WriteLine(timeTurner.GetEndDate(dateTest3, 4800).ToString());
	}

	public static void TestHolidays()
	{
		var holidays = new HolidayProvider(DateTime.Now.AddYears(2).Year);
		Console.WriteLine($"New Years day: {holidays.NewYear.ToString()}");
		Console.WriteLine($"Memorial day: {holidays.MemorialDay.ToString()}");
		Console.WriteLine($"Independence day: {holidays.IndependenceDay.ToString()}");
		Console.WriteLine($"Labor day: {holidays.LaborDay.ToString()}");
		Console.WriteLine($"Thanksgiving: {holidays.Thanksgiving.ToString()}");
		Console.WriteLine($"Chirstmas: {holidays.Christmas.ToString()}");

	}
}
