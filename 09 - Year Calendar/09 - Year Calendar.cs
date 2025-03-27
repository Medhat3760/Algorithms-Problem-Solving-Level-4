namespace _09___Year_Calendar
{
    internal class Program
    {

        static short ReadYear()
        {

            short year = 0;

            Console.Write("\nPlease enter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

        }

        static string GetMonthShortName(short month)
        {

            string[] arrMonthNames = { "Jan", "Feb", "Mar", "Apr", "May", "Jun",
                                       "Jul", "Aug" ,"Sep" ,"Oct" ,"Nov" ,"Dec" };

            return arrMonthNames[month - 1];

        }

        static short GetDayOfWeekOrder(short day, short month, short year)
        {

            short d, a, y, m;

            a = (short)((14 - month) / 12);
            y = (short)(year - a);
            m = (short)(month + 12 * a - 2);

            d = (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);

            return d;

        }

        static bool IsLeapYear(short year)
        {

            return (year % 400 == 0 || year % 4 == 0 && year % 100 != 0);

        }

        static short NumberOfDaysInAMonth(short year, short month)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 30, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];

        }

        static void PrintMonthCalender(short year, short month)
        {

            short current = GetDayOfWeekOrder(1, month, year);

            short numberOfDays = NumberOfDaysInAMonth(year, month);

            Console.WriteLine($"\n  _______________{GetMonthShortName(month)}_______________\n");

            Console.WriteLine("  Sun  Mon  Tue  Wed  Thu  Fri  Sat");

            short i;
            for (i = 0; i < current; i++)
            {

                Console.Write("     ");
            }

            for (short j = 1; j <= numberOfDays; j++)
            {

                Console.Write($"{j,5}");

                if (++i == 7)
                {

                    i = 0;
                    Console.WriteLine();

                }

            }

            Console.WriteLine("\n  _________________________________\n");

        }

        static void PrintYearCalendar(short year)
        {

            Console.WriteLine("\n  _________________________________\n");
            Console.WriteLine($"\t  Calendar - {year}");
            Console.WriteLine("  _________________________________\n");

            for (short i = 1; i <= 12; i++)
            {

                PrintMonthCalender(year, i);

            }

        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            PrintYearCalendar(year);

        }
    }
}