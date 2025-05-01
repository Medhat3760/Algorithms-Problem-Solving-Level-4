namespace _55___Calculate_Vacation_Return_Date
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

        static stDate ReadFullDate()
        {

            stDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        static short GetDayOfWeekOrder(short day, short month, short year)
        {

            short d, a, y, m;

            a = (short)((14 - month) / 12);
            y = (short)(year - a);
            m = (short)(month + 12 * a - 2);
            // Gregorian:
            //0:sun, 1:Mon, 2:Tue...etc
            d = (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);

            return d;

        }

        static short GetDayOfWeekOrder(stDate date)
        {

            return GetDayOfWeekOrder(date.day, date.month, date.year);

        }

        static string GetDayShortName(short dayOfWeekOrder)
        {

            string[] arrDayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            return arrDayNames[dayOfWeekOrder];
        }
        static bool IsDate1BeforeDate2(stDate date1, stDate date2)
        {

            if (date1.year != date2.year)
                return date1.year < date2.year;

            if (date1.month != date2.month)
                return date1.month < date2.month;

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
                    date.day = 1;
                    date.month = 1;
                    date.year++;
                }
                else
                {
                    date.day = 1;
                    date.month++;
                }

            }
            else
            {
                date.day++;
            }

            return date;

        }

        static bool IsWeekEnd(stDate date)
        {

            short dayIndex = GetDayOfWeekOrder(date);

            return dayIndex == 5 || dayIndex == 6;

        }

        static bool IsBusinessDay(stDate date)
        {
            return !IsWeekEnd(date);
        }

        static short ReadVacationDays()
        {

            short vacationDays;

            Console.Write("\nPlease Enter Vacation Days? ");
            vacationDays = short.Parse(Console.ReadLine());

            return vacationDays;

        }

        static stDate CalculateVacationReturnDate(stDate dateFrom, short vacationDays)
        {

            short weekEndCounter = 0;

            while (IsWeekEnd(dateFrom))
            {
                dateFrom = IncreaseDateByOneDay(dateFrom);
            }

            for (short i = 1; i <= vacationDays + weekEndCounter; i++)
            {

                if (IsWeekEnd(dateFrom))
                {
                    weekEndCounter++;
                }

                dateFrom = IncreaseDateByOneDay(dateFrom);

            }

            while (IsWeekEnd(dateFrom))
            {
                dateFrom = IncreaseDateByOneDay(dateFrom);
            }

            return dateFrom;

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Vacation Starts:");
            stDate dateFrom = ReadFullDate();

            short vacationDays = ReadVacationDays();

            stDate returnDate = CalculateVacationReturnDate(dateFrom, vacationDays);

            Console.WriteLine($"\nReturn Date: {GetDayShortName(GetDayOfWeekOrder(returnDate))} , {returnDate.day}/{returnDate.month}/{returnDate.year}");

        }
    }
}