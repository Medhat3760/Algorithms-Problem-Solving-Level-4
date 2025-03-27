namespace _10___Number_Of_Days_From_The_Beginning_Of_The_Year
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

            Console.Write("\nPlease enter a year? ");
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

            return (month == 2) ? (IsLeapYear(year) ? (short)29 : (short)28) : arrNumberOfDays[month - 1];

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

        static void Main(string[] args)
        {

            short day = ReadDay();

            short month = ReadMonth();

            short year = ReadYear();


            Console.WriteLine("\nNumber Of Days From The Beginning Of The Year is " + NumOfDaysFromBeginningTheYear(year, month, day));

        }
    }
}