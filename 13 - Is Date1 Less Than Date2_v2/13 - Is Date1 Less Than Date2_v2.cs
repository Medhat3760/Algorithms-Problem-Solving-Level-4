namespace _13___Is_Date1_Less_Than_Date2_v2
{
    internal class Program
    {

        struct sDate
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

        static sDate ReadFulDate()
        {

            sDate date;

            date.day = ReadDay();
            date.month = ReadMonth();
            date.year = ReadYear();

            return date;

        }

        static bool IsDate1BeforeDate2(sDate date1, sDate date2)
        {

            if (date1.year != date2.year)
                return date1.year < date2.year;

            if (date1.month != date2.month)
                return date1.month < date2.month;

            return date1.day < date2.day;

        }

        static void Main(string[] args)
        {

            sDate date1, date2;

            date1 = ReadFulDate();

            Console.WriteLine();

            date2 = ReadFulDate();

            if (IsDate1BeforeDate2(date1, date2))
            {
                Console.WriteLine("\n Yes, Date1 is less than Date2.");
            }
            else
            {
                Console.WriteLine("\n No, Date1 is NOT less than Date2.");
            }

        }
    }
}