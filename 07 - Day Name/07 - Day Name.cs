namespace _07___Day_Name
{
    internal class Program
    {

        static short ReadYear()
        {

            short year = 0;

            Console.Write("\nPlease enter a Year? ");
            year = short.Parse(Console.ReadLine());
            return year;

        }

        static short ReadMonth()
        {

            short month = 0;

            Console.Write("\nPlease enter a Month? ");
            month = short.Parse(Console.ReadLine());
            return month;

        }

        static short ReadDay()
        {

            short day = 0;

            Console.Write("\nPlease enter a Day? ");
            day = short.Parse(Console.ReadLine());
            return day;

        }

        static short GetDayOfWeekOrder(short day, short month, short year)
        {

            short d, a, y, m;

            a = (short)((14 - month) / 12);
            y = (short)(year - a);
            m = (short)(month + 12 * a - 2);

            d = (short)((day + y + (y / 4) - (y / 100) + (y / 400) + ((31 * m) / 12)) % 7);

            return d;

        }

        static string GetDayShortName(short dayOrder)
        {

            string[] arrDayNames = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            return arrDayNames[dayOrder];

        }

        static void Main(string[] args)
        {

            short year = ReadYear();

            short month = ReadMonth();

            short day = ReadDay();

            short dayOrder = GetDayOfWeekOrder(day, month, year);

            Console.WriteLine($"\nDate      : {day}/{month}/{year}");
            Console.WriteLine($"Day Order : {dayOrder}");
            Console.WriteLine($"Day Name  : {GetDayShortName(dayOrder)}");

        }
    }
}