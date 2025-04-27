using System;

namespace _47_To_53___More_Date_Problems
{
    internal class Program
    {

        struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        static stDate GetSystemDate()
        {

            stDate date;
            DateTime now = DateTime.Now;

            date.day = (short)now.Day;
            date.month = (short)now.Month;
            date.year = (short)now.Year;

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

        static bool IsEndOfWeek(stDate date)
        {
            return GetDayOfWeekOrder(date) == 6;
        }

        static bool IsWeekEnd(stDate date)
        {
            //Weekends are Fri and Sat

            short dayIndex = GetDayOfWeekOrder(date);

            return dayIndex == 5 || dayIndex == 6;

        }

        static bool IsBusinessDay(stDate date)
        {
            //Business Days are Sun,Mon,Tue,Wed and Thur
            /* short DayIndex = DayOfWeekOrder(Date);
            return (DayIndex >= 0 && DayIndex <= 4);
            */

            //shorter method is to invert the IsWeekEnd: this will save updating code.           
            return !IsWeekEnd(date);

        }

        static short GetDaysUntilEndOfWeek(stDate date)
        {

            return (short)(6 - GetDayOfWeekOrder(date));

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

        static short GetDaysUntilEndOfMonth(stDate date)
        {

            return (short)(NumberOfDaysInAMonth(date.month, date.year) - date.day);

        }

        static short NumberOfDaysFromBeginningTheYear(stDate date)
        {

            short days = 0;

            for (short i = 1; i < date.month; i++)
            {

                days += NumberOfDaysInAMonth(i, date.year);

            }

            days += date.day;

            return days;

        }

        static short GetDaysUntilEndOfYear(stDate date)
        {

            short yearDays = (short)(IsLeapYear(date.year) ? 366 : 365);

            return (short)(yearDays - NumberOfDaysFromBeginningTheYear(date));

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

        static bool IsLastDayInMonth(stDate date)
        {
            return date.day == NumberOfDaysInAMonth(date.month, date.year);
        }

        static stDate IncreaseDateByOneDay(stDate date)
        {

            if (IsLastDayInMonth(date))
            {

                if (date.month == 12)
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

        static int GetDifferenceDays(stDate date1, stDate date2, bool includeEndDay = false)
        {

            int days = 0;

            while (IsDate1BeforeDate2(date1, date2))
            {

                date1 = IncreaseDateByOneDay(date1);
                days++;

            }

            return includeEndDay ? ++days : days;

        }

        static short GetDaysUntilEndOfMonth_v2(stDate date)
        {

            stDate endOfMonthDate;

            endOfMonthDate.day = NumberOfDaysInAMonth(date.month, date.year);
            endOfMonthDate.month = date.month;
            endOfMonthDate.year = date.year;

            return (short)GetDifferenceDays(date, endOfMonthDate);

        }

        static short GetDaysUntilEndOfYear_v2(stDate date)
        {

            stDate endYearDate;

            endYearDate.day = 31;
            endYearDate.month = 12;
            endYearDate.year = date.year;

            return (short)GetDifferenceDays(date, endYearDate);

        }

        static void Main(string[] args)
        {

            stDate date1 = GetSystemDate();

            string dayName = GetDayShortName(GetDayOfWeekOrder(date1));

            Console.WriteLine($"\nToday is {dayName} , {date1.day}/{date1.month}/{date1.year}");

            Console.WriteLine("\nIs it End of Week?");

            if (IsEndOfWeek(date1))
            {
                Console.WriteLine("Yes it is Saturday, it's of Week.");
            }
            else
            {
                Console.WriteLine("No NOT end of week.");
            }

            Console.WriteLine("\nIs it Weekend?");

            if (IsWeekEnd(date1))
            {
                Console.WriteLine("Yes it is a week end.");
            }
            else
            {
                Console.WriteLine($"No today is {dayName}, NOT a weekend.");
            }

            Console.WriteLine("\nIs it a Business Day?");

            if (IsBusinessDay(date1))
            {
                Console.WriteLine("Yes it is a business day.");
            }
            else
            {
                Console.WriteLine("No it is NOT a business day.");
            }

            Console.WriteLine($"\nDays until end of week : {GetDaysUntilEndOfWeek(date1)} Day(s)");

            Console.WriteLine($"\nDays until end of month : {GetDaysUntilEndOfMonth(date1)} Day(s)");

            Console.WriteLine($"\nDays until end of year : {GetDaysUntilEndOfYear(date1)} Day(s)");

            Console.WriteLine("\nVersion2:");

            Console.WriteLine($"\nDays until end of month (version 2) : {GetDaysUntilEndOfMonth_v2(date1)} Day(s)");

            Console.WriteLine($"\nDays until end of year (version 2) : {GetDaysUntilEndOfYear_v2(date1)} Day(s)");

        }
    }
}
