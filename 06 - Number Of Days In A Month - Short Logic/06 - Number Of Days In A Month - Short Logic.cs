namespace _06___Number_Of_Days_In_A_Month___Short_Logic
{
    internal class Program
    {

        static short ReadYear()
        {

            short year = 0;

            Console.Write("\nPlease enter a year to check? ");
            year = short.Parse(Console.ReadLine());
            return year;

        }

        static short ReadMonth()
        {

            short month = 0;

            Console.Write("\nPlease enter a month to check? ");
            month = short.Parse(Console.ReadLine());
            return month;

        }

        static bool IsLeapYear(short year)
        {
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        static short NumberOfDaysInAMonth(short month, short year)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];

        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            short month = ReadMonth();

            Console.WriteLine($"\nNumber of days in month [{month}] is {NumberOfDaysInAMonth(month, year)}");

        }
    }
}