using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public class Program
    {
        public static List<int> GetValues()
        {
            List<int> result = new List<int>();
            Console.WriteLine($"Input {LotteryTicket.CountOfNumbers} integer values");
            for (int i = 0; i < LotteryTicket.CountOfNumbers; i++)
            {
                try
                {
                    int value = Convert.ToInt32(Console.ReadLine());
                    result.Add(value);
                }
                catch
                {
                    Console.WriteLine("Input error. Try again");
                    return GetValues();
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var ticket = new LotteryTicket();
            List<int> values = GetValues();
            bool isCorrect = true;
            for (int i = 0; i < LotteryTicket.CountOfNumbers; i++)
            {
                if (ticket[i] != values[i])
                {
                    isCorrect = false;
                    break;
                }
            }
            if (isCorrect)
                Console.WriteLine("Congratulations");
            else
                Console.WriteLine("You lose");

            Console.ReadKey();
        }
    }
}
