using System;
using TimeMachine;

public class Program
{
	public static void Main()
	{
		//var date1mins = 55;
		//var date2mins = 720;
		var date3mins = 4800;
		//DateTime dateTest1 = new DateTime(2018, 1, 3, 6, 0, 0);
		//DateTime dateTest2 = new DateTime(2018, 7, 3, 21, 0, 0);
		DateTime dateTest3 = new DateTime(2018, 8, 21, 5, 0, 0);
		TimeTurner timeTurner = new TimeTurner();
		//Console.WriteLine(timeTurner.GetEndDate(dateTest1, 55).ToString());
		Console.WriteLine("----------------- Begin Test -------------------");
		Console.WriteLine();
		Console.WriteLine($"  Start date: {dateTest3.ToString()}");
		Console.WriteLine($"  Minutes added: {date3mins}");
		Console.WriteLine($"  End date: {timeTurner.GetEndDate(dateTest3, date3mins).ToString()}");
		Console.WriteLine();
		Console.WriteLine("------------------ End Test -------------------");
		Console.WriteLine();
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
