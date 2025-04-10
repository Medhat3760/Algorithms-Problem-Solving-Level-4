namespace _12___Add_Days_To_Date_v2
{
    internal class Program
    {

        static short ReadDay()
        {

            short day = 0;

            Console.Write("\nPlease enter a Day? ");
            day = short.Parse(Console.ReadLine());

            return day;

        }

        static short ReadMonth()
        {

            short month = 0;

            Console.Write("\nPlease enter a Month? ");
            month = short.Parse(Console.ReadLine());

            return month;

        }

        static short ReadYear()
        {

            short year = 0;

            Console.Write("\nPlease enter a Year? ");
            year = short.Parse(Console.ReadLine());

            return year;

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

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (month == 2) ? (short)(IsLeapYear(year) ? 29 : 28) : arrNumberOfDays[month - 1];

        }

        static short NumOfDaysFromBeginningTheYear(short year, short month, short day)
        {

            short numOfDays = 0;

            for (short i = 1; i < month; i++)
            {

                numOfDays += NumberOfDaysInAMonth(i, year);

            }

            numOfDays += day;

            return numOfDays;

        }

        struct sDate
        {

            public short year;
            public short month;
            public short day;

        }

        static sDate ReadFulDate()
        {

            sDate date;

            date.day = ReadDay();

            date.month = ReadMonth();

            date.year = ReadYear();

            return date;

        }

        static short ReadDaysToAdd()
        {

            short days;

            Console.Write("\nHow many days to add? ");
            days = short.Parse(Console.ReadLine());

            return days;

        }

        static sDate GetDateFromDayOrderInAYear(short dayOrderInAYear, short year)
        {

            sDate date;

            short remainingDays = dayOrderInAYear;
            short monthDays = 0;

            date.year = year;
            date.month = 1;

            while (true)
            {

                monthDays = NumberOfDaysInAMonth(date.month, year);

                if (remainingDays > monthDays)
                {
                    remainingDays -= monthDays;
                    date.month++;
                }
                else
                {
                    date.day = remainingDays;
                    break;
                }

            }

            return date;

        }

        static sDate DateAddDays(short days, sDate date)
        {

            short remainingDays = (short)(days + NumOfDaysFromBeginningTheYear(date.year, date.month, date.day));

            short yearDays;

            while (remainingDays > (yearDays = (short)(IsLeapYear(date.year) ? 366 : 365)))
            {

                remainingDays -= yearDays;
                date.year++;

            }

            date = GetDateFromDayOrderInAYear(remainingDays, date.year);

            return date;

        }

        static void Main(string[] args)
        {

            sDate date = ReadFulDate();

            short days = ReadDaysToAdd();

            date = DateAddDays(days, date);

            Console.Write($"\nDate after adding [{days}] days is: ");
            Console.WriteLine($"{date.day}/{date.month}/{date.year}");

        }
    }
}