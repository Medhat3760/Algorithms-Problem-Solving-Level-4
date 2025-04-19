namespace _19___Diif_In_Days__Negative_Days_
{
    internal class Program
    {

        struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        static short ReadDay()
        {

            short day;

            Console.Write("\nPlease enter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        static short ReadMonth()
        {

            short month;

            Console.Write("\nPlease enter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        static short ReadYear()
        {

            short year;

            Console.Write("\nPlease enter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

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

        static void SwapDates(ref stDate date1, ref stDate date2)
        {

            stDate temp = date1;
            date1 = date2;
            date2 = temp;

        }

        static bool IsLastMonthInYear(short month)
        {
            return (month == 12);
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

            return month == 2 ? ((short)(IsLeapYear(year) ? 29 : 28)) : arrNumberOfDays[month - 1];

        }

        static bool IsLastDayInMonth(stDate date)
        {

            return date.day == NumberOfDaysInAMonth(date.month, date.year);

        }

        static stDate IncreaseDateByOneDay(stDate date)
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

        static int GetDifferenceInDays(stDate date1, stDate date2, bool includeEndDay = false)
        {

            int days = 0;
            short swapFalgValue = 1;

            if (!IsDate1BeforeDate2(date1, date2))
            {

                SwapDates(ref date1, ref date2);
                swapFalgValue = -1;

            }

            while (IsDate1BeforeDate2(date1, date2))
            {

                date1 = IncreaseDateByOneDay(date1);
                days++;

            }

            return (includeEndDay) ? (++days * swapFalgValue) : (days * swapFalgValue);

        }

        static void Main(string[] args)
        {

            stDate date1 = ReadFullDate();
            Console.WriteLine();
            stDate date2 = ReadFullDate();

            Console.WriteLine($"\nDifference is: {GetDifferenceInDays(date1, date2)} Day(s).");
            Console.WriteLine($"Difference (Including End Day) is: {GetDifferenceInDays(date1, date2, true)} Day(s).");


        }
    }
}