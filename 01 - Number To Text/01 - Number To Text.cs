namespace _01___Number_To_Text
{
    internal class Program
    {

        static long ReadNumber()
        {

            long number = 0;
            Console.Write("Enter a number? ");
            number = long.Parse(Console.ReadLine());
            return number;

        }

        static string NumberToText(long number)
        {

            if (number == 0)
            {
                return "";
            }

            if (number >= 1 && number <= 19)
            {

                string[] arr = { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine",
                    "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Seventeen", "Eighteen",
                    "Nineteen" };

                return arr[number] + " ";

            }
            else if (number >= 20 && number <= 99)
            {

                string[] arr = { "", "", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty",
                    "Ninety" };

                return arr[number / 10] + "-" + NumberToText(number % 10);

            }
            else if (number >= 100 && number <= 199)
            {

                return "One Hundred " + NumberToText(number % 100);

            }
            else if (number >= 200 && number <= 999)
            {

                return NumberToText(number / 100) + "Hundreds " + NumberToText(number % 100);

            }
            else if (number >= 1000 && number <= 1999)
            {

                return "One Thousand " + NumberToText(number % 1000);

            }
            else if (number >= 2000 && number <= 999999)
            {

                return NumberToText(number / 1000) + "Thousands " + NumberToText(number % 1000);

            }
            else if (number >= 1000000 && number <= 1999999)
            {

                return "One Million " + NumberToText(number % 1000000);

            }
            else if (number >= 2000000 && number <= 999999999)
            {

                return NumberToText(number / 1000000) + "Millions " + NumberToText(number % 1000000);

            }
            else if (number >= 1000000000 && number <= 1999999999)
            {

                return "One Billion " + NumberToText(number % 1000000000);

            }
            else
            {

                return NumberToText(number / 1000000000) + "Billions " + NumberToText(number % 1000000000);

            }

        }

        static void Main(string[] args)
        {

            long number = ReadNumber();

            Console.WriteLine(NumberToText(number));

        }
    }
}