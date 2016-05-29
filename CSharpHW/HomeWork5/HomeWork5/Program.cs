using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork5
{
    class Program
    {
        public static void DrawSquare(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write("*".PadRight(2));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void DrawTringle(int size)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (j <= i)
                        Console.Write("*".PadRight(2));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void DrawRomb(int size)
        {
            for (int i = 0; i < size * 2 - 1; i++)
            {
                int countOfElems = - 2 * Math.Abs(size - (i + 1)) + 2 * size - 1;
                for (int j = 0; j < size * 2 - 1; j++)
                {
                    string result = "";
                    if ((j >= size - 1 - countOfElems / 2) && (j <= size - 1 + countOfElems / 2))
                        result += "*";
                    Console.Write(result.PadRight(2));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static int GetSize()
        {
            Console.WriteLine("n = ?");
            string input = Console.ReadLine();
            try
            {
                return Convert.ToInt32(input);
            }
            catch
            {
                Console.WriteLine("Input error");
                return GetSize();
            }
        }

        static void Main(string[] args)
        {
            int size = GetSize();
            DrawTringle(size);
            DrawSquare(size);
            DrawRomb(size);
            Console.ReadKey();
        }
    }
}
