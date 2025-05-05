namespace _59___Period_Length_In_Days
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

            Console.Write("Enter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

        }

        static short ReadMonth()
        {

            short month;

            Console.Write("Enter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        static short ReadDay()
        {

            short day;

            Console.Write("Enter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        static stDate ReadFulDate()
        {

            stDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        struct stPeriod
        {
            public stDate startDate;
            public stDate endDate;
        }

        static stPeriod ReadPeriod()
        {

            stPeriod period;

            Console.WriteLine("Enter Start Date:\n");
            period.startDate = ReadFulDate();

            Console.WriteLine("\nEnter End Date:\n");
            period.endDate = ReadFulDate();

            return period;

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

        static void SwapDates(ref stDate date1, ref stDate date2)
        {

            stDate temp = date1;
            date1 = date2;
            date2 = temp;

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

            if (!IsDate1BeforeDate2(date1, date2))
            {

                SwapDates(ref date1, ref date2);

            }

            while (IsDate1BeforeDate2(date1, date2))
            {

                date1 = IncreaseDateByOneDay(date1);
                days++;

            }

            return (includeEndDay) ? (++days) : (days);

        }

        static int GetPeriodLengthInDays(stPeriod period, bool includeEndDate = false)
        {

            return GetDifferenceInDays(period.startDate, period.endDate, includeEndDate);

        }

        static void Main(string[] args)
        {

            Console.WriteLine("\nEnter Period 1:");
            stPeriod period1 = ReadPeriod();

            Console.WriteLine("\nPeriod Length is: " + GetPeriodLengthInDays(period1));
            Console.WriteLine("Period Length (Including End Date) is: " + GetPeriodLengthInDays(period1, true));

        }
    }
}