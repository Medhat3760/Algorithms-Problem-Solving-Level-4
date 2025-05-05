namespace _63_To_64___Read_Print_Date_String
{
    internal class Program
    {

        struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        static string ReadStringDate(string message)
        {

            Console.Write(message);
            string date = Console.ReadLine();

            return date;

        }

        static List<string> SplitString(string text, string delim)
        {

            List<string> lWords = new List<string>();

            string sWord = "";
            short pos = 0;

            while ((pos = (short)text.IndexOf(delim)) != -1)
            {

                sWord = text.Substring(0, pos);

                if (sWord != "")
                {
                    lWords.Add(sWord);
                }
                text = text.Substring(pos + delim.Length);

            }

            if (text != "")
            {
                lWords.Add(text);
            }

            return lWords;
        }

        static stDate StringToDate(string dateString)
        {

            stDate date;

            List<string> lDate = SplitString(dateString, "/");

            date.day = short.Parse(lDate[0]);
            date.month = short.Parse(lDate[1]);
            date.year = short.Parse(lDate[2]);

            return date;

        }

        static string DateToString(stDate date)
        {
            return date.day.ToString() + "/" + date.month.ToString() + "/" + date.year.ToString();
        }

        static void Main(string[] args)
        {

            string dateString = ReadStringDate("\nPlease enter a Date dd/mm/yyyy? ");

            stDate date = StringToDate(dateString);

            Console.WriteLine("\nDay: " + date.day);
            Console.WriteLine("Month: " + date.month);
            Console.WriteLine("Year: " + date.year);

            Console.WriteLine("\nYou Entered: " + DateToString(date));

        }
    }
}