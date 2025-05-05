using static System.Net.Mime.MediaTypeNames;

namespace _65___Format_Date
{
    internal class Program
    {

        static string ReadStringDate(string message)
        {

            Console.Write(message);
            string date = Console.ReadLine();

            return date;

        }

        struct stDate
        {

            public short year;
            public short month;
            public short day;

        }

        static List<string> SplitString(string s, string delim)
        {

            List<string> lWord = new List<string>();

            string sWord = "";
            short pos = 0;

            while ((pos = (short)s.IndexOf(delim)) != -1)
            {

                sWord = s.Substring(0, pos);

                if (sWord != "")
                {
                    lWord.Add(sWord);
                }

                s = s.Substring(pos + delim.Length);

            }

            if (s != "")
            {
                lWord.Add(s);
            }

            return lWord;

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

        static string ReplaceWordInString(string s, string word, string replaceTo)
        {

            short pos = (short)s.IndexOf(word);

            while (pos != -1)
            {

                s = s.Remove(pos, word.Length).Insert(pos, replaceTo);

                pos = (short)s.IndexOf(word);

            }

            //text = text.Replace(word, replaceTo);

            return s;
        }

        static string FormatDate(stDate date, string dateFormat = "dd/mm/yyyy")
        {

            string formattedDateString = "";

            formattedDateString = ReplaceWordInString(dateFormat, "dd", date.day.ToString());
            formattedDateString = ReplaceWordInString(formattedDateString, "mm", date.month.ToString());
            formattedDateString = ReplaceWordInString(formattedDateString, "yyyy", date.year.ToString());

            return formattedDateString;

        }

        static void Main(string[] args)
        {

            string dateString = ReadStringDate("\nPlease enter a Date dd/mm/yyyy? ");

            stDate date = StringToDate(dateString);

            Console.WriteLine("\n" + FormatDate(date, "dd/mm/yyyy"));
            Console.WriteLine("\n" + FormatDate(date, "yyyy/dd/mm"));
            Console.WriteLine("\n" + FormatDate(date, "mm/dd/yyyy"));
            Console.WriteLine("\n" + FormatDate(date, "mm-dd-yyyy"));
            Console.WriteLine("\n" + FormatDate(date, "dd-mm-yyyy"));
            Console.WriteLine("\n" + FormatDate(date, "Day:dd, Month:mm, Year:yyyy"));

        }
    }
}