using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace HomeWork3
{
    class Program
    {
        private static DateTime GetDateFromConsole()
        {
            Console.WriteLine("Input date:");
            string input = Console.ReadLine();
            try
            {
                return DateTime.ParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                return GetDateFromConsole();
            }
        }

        static void Main(string[] args)
        {
            DateTime input = GetDateFromConsole();
            Console.WriteLine(Zodiac.GetAge(input));
            Console.WriteLine(Zodiac.GetZodiacSign(input).ToString("g"));
            Console.ReadKey();
        }
    }
}
