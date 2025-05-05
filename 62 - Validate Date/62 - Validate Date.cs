namespace _62___Validate_Date
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
            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);
        }

        static short NumberOfDaysInAMonth(short month, short year)
        {

            if (month < 1 || month > 12)
            {
                return 0;
            }

            short[] arrNumberOfDays = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            return (short)((month == 2) ? (IsLeapYear(year) ? 29 : 28) : arrNumberOfDays[month - 1]);

        }

        static bool IsValidDate(stDate date)
        {

            if (date.year < 1)
            {
                return false;
            }

            if (date.month < 1 || date.month > 12)
            {
                return false;
            }

            if (date.day < 1 || date.day > 31)
            {
                return false;
            }

            short daysInMonth = NumberOfDaysInAMonth(date.month, date.year);

            if (date.day > daysInMonth)
            {
                return false;
            }

            return true;

        }

        static void Main(string[] args)
        {

            stDate date = ReadFullDate();

            if (IsValidDate(date))
            {
                Console.WriteLine("\nYes, Date is a valid date.");
            }
            else
            {
                Console.WriteLine("\nNo, Date is NOT a valid date.");
            }

        }
    }
}