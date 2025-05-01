namespace _56___Is_Date1_After_Date2
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

        static bool IstDate1AfterDate2(stDate date1, stDate date2)
        {
            return !IstDate1BeforeDate2(date1, date2) && !IstDate1EqualDate2(date1, date2);
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Enter Date1:");

            stDate date1 = ReadFulDate();

            Console.WriteLine("\nEnter Date2:");

            stDate date2 = ReadFulDate();

            if (IstDate1AfterDate2(date1, date2))
            {
                Console.WriteLine("\n Yes, Date1 is After Date2.");
            }
            else
            {
                Console.WriteLine("\n No, Date1 is NOT After Date2.");
            }

        }
    }
}