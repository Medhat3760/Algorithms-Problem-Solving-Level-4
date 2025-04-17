namespace _17___Diff_In_Days_v2
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



        static short NumOfDaysFromBeginningTheYear(stDate date)
        {

            short numOfDays = 0;

            for (short i = 1; i < date.month; i++)
            {

                numOfDays += NumberOfDaysInAMonth(i, date.year);

            }

            numOfDays += date.day;

            return numOfDays;

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

        static int GetDifferenceInDays(stDate date1, stDate date2, bool includeEndDay = false)
        {

            if (!IsDate1BeforeDate2(date1, date2))
            {
                SwapDates(ref date1, ref date2);
            }

            int days = 0;

            for (short i = date1.year; i < date2.year; i++)
            {
                days += IsLeapYear(i) ? 366 : 365;
            }

            days += (NumOfDaysFromBeginningTheYear(date2) - NumOfDaysFromBeginningTheYear(date1));


            return (includeEndDay) ? ++days : days;

        }

        static void Main(string[] args)
        {

            stDate date1, date2;

            date1 = ReadFullDate();
            Console.WriteLine();
            date2 = ReadFullDate();
            Console.WriteLine();

            Console.WriteLine($"\nDifference is: {GetDifferenceInDays(date1, date2)} Day(s)");

            Console.WriteLine($"\nDifference (Including End Day) is: {GetDifferenceInDays(date1, date2, true)} Day(s)");

        }
    }
}