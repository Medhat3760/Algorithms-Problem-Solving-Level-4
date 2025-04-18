using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _18___Your_Age_In_Days
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

        static bool IsDate1BeforeDate2(stDate date1, stDate date2)
        {

            if (date1.year != date2.year)
            {
                return date1.year < date2.year;
            }

            if (date1.month != date2.month)
            {
                return date1.month < date2.month;
            }

            return date1.day < date2.day;

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

            return date.day == NumberOfDaysInAMonth(date.month, date.year);

        }

        static bool IsLastMonthInYear(short month)
        {
            return (month == 12);
        }

        static stDate IcreaseDateByOneDay(stDate date)
        {

            if (IsLastDayInMonth(date))
            {

                if (IsLastMonthInYear(date.month))
                {
                    date.year++;
                    date.month = 1;
                    date.day = 1;
                }
                else
                {
                    date.month++;
                    date.day = 1;
                }

            }
            else
            {
                date.day++;
            }

            return date;

        }

        static stDate GetSystemDate()
        {

            DateTime now = DateTime.Now;

            stDate date;
            date.year = (short)now.Year;
            date.month = (short)now.Month;
            date.day = (short)now.Day;

            return date;

        }

        static int GetDifferenceInDays(stDate date1, stDate date2, bool includeEndDay = false)
        {

            int days = 0;

            while (IsDate1BeforeDate2(date1, date2))
            {

                date1 = IcreaseDateByOneDay(date1);
                days++;

            }

            return (includeEndDay) ? ++days : days;

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter Your Date of Birth:");
            stDate date1 = ReadFullDate();
            stDate date2 = GetSystemDate();

            Console.WriteLine($"\nYour Age is : {GetDifferenceInDays(date1, date2, true)} Day(s).");

        }
    }
}