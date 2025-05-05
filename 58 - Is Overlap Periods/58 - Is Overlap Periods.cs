using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace _58___Is_Overlap_Periods
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


        static bool IstDate1BeforeDate2(stDate date1, stDate date2)
        {

            if (date1.year != date2.year)
                return date1.year < date2.year;

            if (date1.month != date2.month)
                return date1.month < date2.month;

            return date1.day < date2.day;

        }

        static bool IstDate1EqualDate2(stDate date1, stDate date2)
        {

            return (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day);

        }

        enum enDateCompare { Before = -1, Equal = 0, After = 1 }

        static enDateCompare CompareDates(stDate date1, stDate date2)
        {

            if (IstDate1BeforeDate2(date1, date2))
            {
                return enDateCompare.Before;
            }

            if (IstDate1EqualDate2(date1, date2))
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

        static void Main(string[] args)
        {

            Console.WriteLine("\nEnter Period 1:");
            stPeriod period1 = ReadPeriod();

            Console.WriteLine("\nEnter Period 2:");
            stPeriod period2 = ReadPeriod();

            if (IsOverlapPeriods(period1, period2))
            {
                Console.WriteLine("\nYes, Periods Overlap.");
            }
            else
            {
                Console.WriteLine("\nNo, Periods NOT Overlap.");
            }

        }
    }
}