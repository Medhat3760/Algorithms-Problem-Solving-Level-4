namespace _20_To_32___Increase_Date_Problems
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

        static stDate IncreaseDateByXDays(stDate date, int days)
        {

            for (int i = 0; i < days; i++)
            {
                date = IncreaseDateByOneDay(date);
            }

            return date;

        }

        static stDate IncreaseDateByOneWeek(stDate date)
        {
            return IncreaseDateByXDays(date, 7);
        }

        static stDate IncreaseDateByXWeeks(stDate date, int weeks)
        {

            for (int i = 0; i < weeks; i++)
            {
                date = IncreaseDateByOneWeek(date);
            }

            return date;

        }

        static stDate IncreaseDateByOneMonth(stDate date)
        {

            if (IsLastMonthInYear(date.month))
            {
                date.year++;
                date.month = 1;
            }
            else
            {
                date.month++;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        static stDate IncreaseDateByXMonths(stDate date, int months)
        {

            for (int i = 0; i < months; i++)
            {
                date = IncreaseDateByOneMonth(date);
            }

            return date;

        }

        static stDate IncreaseDateByOneYear(stDate date)
        {
            //date.year++;
            //return date;

            return IncreaseDateByXMonths(date, 12);
        }

        static stDate IncreaseDateByXYears(stDate date, int years)
        {

            for (int i = 0; i < years; i++)
            {
                date = IncreaseDateByOneYear(date);
            }

            return date;

        }

        static stDate IncreaseDateByXYearsFaster(stDate date, short years)
        {

            date.year += years;

            return date;

        }

        static stDate IncreaseDateByOneDecade(stDate date)
        {
            //date.year += 10;
            //return date;

            return IncreaseDateByXYears(date, 10);
        }

        static stDate IncreaseDateByXDecades(stDate date, short decades)
        {

            for (short i = 0; i < decades * 10; i++)
            {
                date = IncreaseDateByOneYear(date);
            }

            return date;

        }

        static stDate IncreaseDateByXDecadesFaster(stDate date, short decades)
        {

            date.year += (short)(decades * 10);

            return date;

        }

        static stDate IncreaseDateByOneCentury(stDate date)
        {

            //date.year += 100;
            //return date;

            return IncreaseDateByXDecades(date, 10);
        }

        static stDate IncreaseDateByOneMillennium(stDate date)
        {
            //date.year += 1000;
            //return date;

            return IncreaseDateByXYears(date, 1000);
        }

        static void Main(string[] args)
        {

            stDate date1 = ReadFullDate();

            Console.WriteLine("\nDate After:");

            date1 = IncreaseDateByOneDay(date1);
            Console.WriteLine($"\n01-Adding one day is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXDays(date1, 10);
            Console.WriteLine($"02-Adding 10 days is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneWeek(date1);
            Console.WriteLine($"03-Adding one week is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXWeeks(date1, 10);
            Console.WriteLine($"04-Adding 10 weeks is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneMonth(date1);
            Console.WriteLine($"05-Adding one month is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXMonths(date1, 5);
            Console.WriteLine($"06-Adding 5 months is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneYear(date1);
            Console.WriteLine($"07-Adding one year is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXYears(date1, 10);
            Console.WriteLine($"08-Adding 10 years is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXYearsFaster(date1, 10);
            Console.WriteLine($"09-Adding 10 years (Faster) is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneDecade(date1);
            Console.WriteLine($"10-Adding one decade is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXDecades(date1, 10);
            Console.WriteLine($"11-Adding 10 decades is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByXDecadesFaster(date1, 10);
            Console.WriteLine($"12-Adding 10 decades (Faster) is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneCentury(date1);
            Console.WriteLine($"13-Adding Century is: {date1.day}/{date1.month}/{date1.year}");

            date1 = IncreaseDateByOneMillennium(date1);
            Console.WriteLine($"14-Adding Century is: {date1.day}/{date1.month}/{date1.year}");

        }
    }
}