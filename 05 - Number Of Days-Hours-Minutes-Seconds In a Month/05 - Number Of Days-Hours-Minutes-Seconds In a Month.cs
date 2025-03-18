using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _05___Number_Of_Days_Hours_Minutes_Seconds_In_a_Month
{
    internal class Program
    {

        static short ReadYear()
        {

            short year = 0;

            Console.Write("Please enter a year to check? ");
            year = short.Parse(Console.ReadLine());
            return year;

        }

        static short ReadMonth()
        {

            short month = 0;

            Console.Write("Please enter a month to check? ");
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

            if (month == 2)
            {
                return IsLeapYear(year) ? (short)29 : (short)28;
            }

            short[] arr31Days = { 1, 3, 5, 7, 8, 10, 12 };

            foreach (short m in arr31Days)
            {

                if (m == month)
                {
                    return 31;
                }

            }

            return 30;


        }

        static short NumberOfHoursInAMonth(short month, short year)
        {
            return (short)(NumberOfDaysInAMonth(month, year) * 24);
        }

        static int NumberOfMinutesInAMonth(short month, short year)
        {
            return (NumberOfHoursInAMonth(month, year) * 60);
        }

        static int NumberOfSecondsInAMonth(short month, short year)
        {
            return (NumberOfMinutesInAMonth(month, year) * 60);
        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            short month = ReadMonth();

            Console.WriteLine($"\nNumber of Days    in month [{month}] is {NumberOfDaysInAMonth(month, year)}");
            Console.WriteLine($"Number of Hours   in month [{month}] is {NumberOfHoursInAMonth(month, year)}");
            Console.WriteLine($"Number of Minutes in month [{month}] is {NumberOfMinutesInAMonth(month, year)}");
            Console.WriteLine($"Number of Seconds in month [{month}] is {NumberOfSecondsInAMonth(month, year)}");

        }
    }
}