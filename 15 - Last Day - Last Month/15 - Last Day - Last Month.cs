namespace _15___Last_Day___Last_Month
{
    internal class Program
    {

        struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        static short ReadYear()
        {

            short year;

            Console.Write("\nEnter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

        }

        static short ReadMonth()
        {

            short month;

            Console.Write("\nEnter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        static short ReadDay()
        {

            short day;

            Console.Write("\nEnter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        static stDate ReadFullDate()
        {

            stDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        static bool IsLeapYear(short year)
        {

            return (year % 4 == 0 && year % 100 != 0) || (year % 400 == 0);

        }

        static short NumberOfDaysInAMonth(short month, short year)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? ((short)(IsLeapYear(year) ? 29 : 28)) : arrNumberOfDays[month - 1];

        }

        static bool IsLastDayInMonth(stDate date)
        {

            return (date.day == NumberOfDaysInAMonth(date.month, date.year));

        }

        static bool IsLastMonthInYear(short month)
        {

            return month == 12;

        }

        static void Main(string[] args)
        {

            stDate date = ReadFullDate();

            if (IsLastDayInMonth(date))
            {
                Console.WriteLine("\n Yes, Day is Last Day in Month.");
            }
            else
            {
                Console.WriteLine("\n No, Day is NOT Last Day in Month.");
            }

            if (IsLastMonthInYear(date.month))
            {
                Console.WriteLine("\n Yes, Month is Last Month in Year.");
            }
            else
            {
                Console.WriteLine("\n No, Month is NOT Last Month in Year.");
            }

        }
    }
}