namespace _33_To_46_Decrease_Date_Problems
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

        static stDate DecreaseDateByOneDay(stDate date)
        {

            if (date.day == 1)
            {

                if (date.month == 1)
                {
                    date.year--;
                    date.month = 12;
                    date.day = 31;

                }
                else
                {
                    date.month--;
                    date.day = NumberOfDaysInAMonth(date.month, date.year);
                }

            }
            else
            {
                date.day--;
            }

            return date;

        }

        static stDate DecreaseDateByXDays(stDate date, short days)
        {

            for (short i = 0; i < days; i++)
            {
                date = DecreaseDateByOneDay(date);
            }

            return date;

        }

        static stDate DecreaseDateByOneWeek(stDate date)
        {

            return DecreaseDateByXDays(date, 7);

        }

        static stDate DecreaseDateByXWeeks(stDate date, short weeks)
        {

            for (short i = 0; i < weeks; i++)
            {
                date = DecreaseDateByOneWeek(date);
            }

            return date;

        }

        static stDate DecreaseDateByOneMonth(stDate date)
        {

            if (date.month == 1)
            {
                date.year--;
                date.month = 12;
            }
            else
            {
                date.month--;
            }

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        static stDate DecreaseDateByXMonths(stDate date, short months)
        {

            for (short i = 0; i < months; i++)
            {

                date = DecreaseDateByOneMonth(date);

            }

            return date;

        }

        static stDate DecreaseDateByOneYear(stDate date)
        {

            date.year--;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        static stDate DecreaseDateByXYears(stDate date, short years)
        {

            for (short i = 0; i < years; i++)
            {

                date = DecreaseDateByOneYear(date);

            }

            return date;

        }

        static stDate DecreaseDateByXYearsFaster(stDate date, short years)
        {

            date.year -= years;

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        static stDate DecreaseDateByOneDecade(stDate date)
        {
            //date.year-=10;
            //short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            //if (date.day > numberOfDaysInCurrentMonth)
            //{
            //    date.day = numberOfDaysInCurrentMonth;
            //}
            //return date;

            return DecreaseDateByXYears(date, 10);

        }

        static stDate DecreaseDateByXDecades(stDate date, short decades)
        {

            for (short i = 0; i < decades * 10; i++)
            {
                date = DecreaseDateByOneYear(date);
            }

            return date;

        }

        static stDate DecreaseDateByXDecadesFaster(stDate date, short decades)
        {

            date.year -= (short)(decades * 10);

            short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > numberOfDaysInCurrentMonth)
            {
                date.day = numberOfDaysInCurrentMonth;
            }

            return date;

        }

        static stDate DecreaseDateByOneCentury(stDate date)
        {
            //date.year -= 100;
            //short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            //if (date.day > numberOfDaysInCurrentMonth)
            //{
            //    date.day = numberOfDaysInCurrentMonth;
            //}
            //return date;

            return DecreaseDateByXDecades(date, 10);
        }

        static stDate DecreaseDateByOneMillennium(stDate date)
        {
            //date.year -= 1000;
            //short numberOfDaysInCurrentMonth = NumberOfDaysInAMonth(date.month, date.year);

            //if (date.day > numberOfDaysInCurrentMonth)
            //{
            //    date.day = numberOfDaysInCurrentMonth;
            //}
            //return date;

            return DecreaseDateByXYears(date, 1000);
        }

        static void Main(string[] args)
        {

            stDate date = ReadFullDate();

            Console.WriteLine($"\nDate After:");

            date = DecreaseDateByOneDay(date);
            Console.WriteLine($"\n01-Subtracting one day is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXDays(date, 10);
            Console.WriteLine($"\n02-Subtracting 10 days is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneWeek(date);
            Console.WriteLine($"\n03-Subtracting one week is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXWeeks(date, 10);
            Console.WriteLine($"\n04-Subtracting 10 weeks is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneMonth(date);
            Console.WriteLine($"\n05-Subtracting one month is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXMonths(date, 5);
            Console.WriteLine($"\n06-Subtracting 5 months is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneYear(date);
            Console.WriteLine($"\n07-Subtracting one year is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXYears(date, 10);
            Console.WriteLine($"\n08-Subtracting 10 years is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXYearsFaster(date, 10);
            Console.WriteLine($"\n09-Subtracting 10 years (faster) is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneDecade(date);
            Console.WriteLine($"\n10-Subtracting one decade is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXDecades(date, 10);
            Console.WriteLine($"\n11-Subtracting 10 decades is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByXDecadesFaster(date, 10);
            Console.WriteLine($"\n12-Subtracting 10 decades (faster) is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneCentury(date);
            Console.WriteLine($"\n13-Subtracting one century is: {date.day}/{date.month}/{date.year}");

            date = DecreaseDateByOneMillennium(date);
            Console.WriteLine($"\n14-Subtracting one millennium is: {date.day}/{date.month}/{date.year}");

        }
    }
}