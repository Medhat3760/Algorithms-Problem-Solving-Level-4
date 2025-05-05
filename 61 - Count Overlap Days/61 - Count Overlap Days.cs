namespace _61___Count_Overlap_Days
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

            Console.Write("Please enter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        static short ReadMonth()
        {

            short month;

            Console.Write("Please enter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        static short ReadYear()
        {

            short year;

            Console.Write("Please enter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

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
                return date1.year < date2.year;

            if (date1.month != date2.month)
                return date1.month < date2.month;

            return date1.day < date2.day;

        }

        static bool IsDate1EqualDate2(stDate date1, stDate date2)
        {

            return (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day);

        }

        enum enDateCompare { Before = -1, Equal = 0, After = 1 }

        static enDateCompare CompareDates(stDate date1, stDate date2)
        {

            if (IsDate1BeforeDate2(date1, date2))
            {
                return enDateCompare.Before;
            }

            if (IsDate1EqualDate2(date1, date2))
            {
                return enDateCompare.Equal;
            }

            return enDateCompare.After;

        }

        static bool IsOverlapPeriods(stPeriod period1, stPeriod period2)
        {

            if (
               CompareDates(period2.endDate, period1.startDate) == enDateCompare.Before
               ||
               CompareDates(period2.startDate, period1.endDate) == enDateCompare.After
              )
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        static bool IsDate1AfterDate2(stDate date1, stDate date2)
        {
            return !IsDate1BeforeDate2(date1, date2) && !IsDate1EqualDate2(date1, date2);
        }

        static bool IsDateInPeriod(stPeriod period, stDate date)
        {

            return !(IsDate1BeforeDate2(date, period.startDate) || IsDate1AfterDate2(date, period.endDate));

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

        static void SwapDates(ref stDate date1, ref stDate date2)
        {

            stDate temp = date1;
            date1 = date2;
            date2 = temp;

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

        static int CountOverlapDays(stPeriod period1, stPeriod period2)
        {

            int overlapDaysCount = 0;

            int period1Length = GetPeriodLengthInDays(period1, true);
            int period2Length = GetPeriodLengthInDays(period2, true);

            if (!IsOverlapPeriods(period1, period2))
            {
                return 0;
            }

            if (period1Length < period2Length)
            {
                while (IsDate1BeforeDate2(period1.startDate, period1.endDate))
                {

                    if (IsDateInPeriod(period2, period1.startDate))
                    {
                        overlapDaysCount++;
                    }

                    period1.startDate = IncreaseDateByOneDay(period1.startDate);

                }
            }
            else
            {
                while (IsDate1BeforeDate2(period2.startDate, period2.endDate))
                {

                    if (IsDateInPeriod(period1, period2.startDate))
                    {
                        overlapDaysCount++;
                    }

                    period2.startDate = IncreaseDateByOneDay(period2.startDate);

                }
            }

            return overlapDaysCount;

        }

        static void Main(string[] args)
        {

            Console.WriteLine("\nEnter Period 1:");
            stPeriod period1 = ReadPeriod();

            Console.WriteLine("\nEnter Period 2:");
            stPeriod period2 = ReadPeriod();

            Console.WriteLine("\nOverlap Days Count is: " + CountOverlapDays(period1, period2));

        }
    }
}