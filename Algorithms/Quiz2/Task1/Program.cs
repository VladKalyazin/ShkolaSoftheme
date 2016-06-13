using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        public const int MinValue = 1;
        public const int MaxValue = 1000;

        public struct IntPair
        {
            public int A { get; set; }
            public int B { get; set; }

            public IntPair(int a, int b)
            {
                A = a;
                B = b;
            }
        }

        public static void PrintSolutions()
        {
            Dictionary<int, List<IntPair>> resultsTable = new Dictionary<int, List<IntPair>>();

            for (int i = MinValue; i <= MaxValue; i++)
            {
                for (int j = i; j <= MaxValue; j++)
                {
                    int result = GetThirdDegree(i) + GetThirdDegree(j);
                    if (!resultsTable.ContainsKey(result))
                        resultsTable.Add(result, new List<IntPair>());
                    resultsTable[result].Add(new IntPair(i, j));
                }
            }

            foreach (var solutions in resultsTable)
            {
                if (solutions.Value.Count > 1)
                {
                    Console.WriteLine($"Result = {solutions.Key}");
                    Console.WriteLine("Values:");
                    foreach (var value in solutions.Value)
                    {
                        Console.WriteLine($"a = {value.A}; b = {value.B}");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("Done");
        }

        static int GetThirdDegree(int value) => value * value * value;

        static void Main(string[] args)
        {
            PrintSolutions();

            Console.ReadKey();
        }
    }
}
