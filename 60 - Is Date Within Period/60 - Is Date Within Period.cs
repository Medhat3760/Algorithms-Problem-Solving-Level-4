namespace _60___Is_Date_Within_Period
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

        struct stPeriod
        {
            public stDate startDate;
            public stDate endDate;
        }

        static stPeriod ReadPeriod()
        {

            stPeriod period;

            Console.WriteLine("Enter Start Date:\n");
            period.startDate = ReadFullDate();

            Console.WriteLine("\nEnter End Date:\n");
            period.endDate = ReadFullDate();

            return period;

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

        static bool IsDate1EqualDate2(stDate date1, stDate date2)
        {

            return (date1.year == date2.year && date1.month == date2.month && date1.day == date2.day);

        }

        static bool IsDate1AfterDate2(stDate date1, stDate date2)
        {
            return !IsDate1BeforeDate2(date1, date2) && !IsDate1EqualDate2(date1, date2);
        }

        static bool IsDateInPeriod(stPeriod period, stDate date)
        {

            return !(IsDate1BeforeDate2(date, period.startDate) || IsDate1AfterDate2(date, period.endDate));

        }

        static void Main(string[] args)
        {

            Console.WriteLine("\nEnter Period 1:");
            stPeriod period = ReadPeriod();

            Console.WriteLine("\nEnter Date to Check:");
            stDate dateToCheck = ReadFullDate();

            if (IsDateInPeriod(period, dateToCheck))
            {
                Console.WriteLine("\nYes, Date is Within Period.");
            }
            else
            {
                Console.WriteLine("\nNo, Date is NOT Within Period.");
            }

        }
    }
}