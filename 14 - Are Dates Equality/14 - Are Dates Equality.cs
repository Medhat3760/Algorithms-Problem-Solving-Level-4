namespace _14___Are_Dates_Equality
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

        static stDate ReadFulDate()
        {

            stDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        static bool IsDate1EqualDate2(stDate date1, stDate date2)
        {

            return (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day);

        }

        static void Main(string[] args)
        {

            stDate date1, date2;

            date1 = ReadFulDate();

            Console.WriteLine();

            date2 = ReadFulDate();

            if (IsDate1EqualDate2(date1, date2))
            {
                Console.WriteLine("\n Yes, Date1 is Equal To Date2.");
            }
            else
            {
                Console.WriteLine("\n No, Date1 is NOT Equal To Date2.");
            }


        }
    }
}