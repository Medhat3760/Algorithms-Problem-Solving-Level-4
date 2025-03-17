namespace _04___Number_Of_Days_Hours_Minutes_Seconds_In_a_Year
{
    internal class Program
    {

        static short ReadYear()
        {

            short year;

            Console.Write("Please enter a year to check? ");
            year = short.Parse(Console.ReadLine());
            return year;

        }

        static bool IsLeapYear(short year)
        {
            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);
        }


        static short NumberOfDaysInAYear(short year)
        {
            return IsLeapYear(year) ? (short)366 : (short)365;
        }

        static short NumberOfHoursInAYear(short year)
        {
            return (short)(NumberOfDaysInAYear(year) * 24);
        }

        static int NumberOfMinutesINAYear(short year)
        {
            return (NumberOfHoursInAYear(year) * 60);
        }

        static int NumberOfSecondsInAYear(short year)
        {
            return NumberOfMinutesINAYear(year) * 60;
        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            Console.WriteLine($"\nNumber of Days    in Year [{year}] is {NumberOfDaysInAYear(year)}");
            Console.WriteLine($"Number of Hours   in Year [{year}] is {NumberOfHoursInAYear(year)}");
            Console.WriteLine($"Number of Minutes in Year [{year}] is {NumberOfMinutesINAYear(year)}");
            Console.WriteLine($"Number of Seconds in Year [{year}] is {NumberOfSecondsInAYear(year)}");

        }
    }
}