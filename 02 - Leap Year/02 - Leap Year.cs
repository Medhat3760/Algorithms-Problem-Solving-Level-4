namespace _02___Leap_Year
{
    internal class Program
    {

        static short ReadYear()
        {

            short year = 0;

            Console.Write("Please enter a year to check ? ");
            year = short.Parse(Console.ReadLine());
            return year;

        }

        static bool IsLeapYear(short year)
        {

            return (year % 400 == 0) || (year % 4 == 0 && year % 100 != 0);

        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            if (IsLeapYear(year))
            {
                Console.WriteLine($"\nYes, year [ {year} ] is a leap year.");
            }
            else
            {
                Console.WriteLine($"\nNo, year [ {year} ] is NOT a leap year.");
            }

        }
    }
}