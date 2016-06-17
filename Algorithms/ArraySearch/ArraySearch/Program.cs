using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ArraySearch
{
    class Program
    {
        public const int MinArrayLength = 100;
        public const int MaxArrayLength = 50000000;
        public const int AlgorithmsCount = 3;

        static void Main(string[] args)
        {
            Random ArrayGenerator = new Random();
            var Timer = new Stopwatch();
            double TimeForAlgorithm;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength *= 3)
            {
                int key = ArrayLength * 2 - ArrayLength / 100 - 9;

                List<List<int>> arraysList = new List<List<int>>();
                for (int j = 0; j < AlgorithmsCount; j++)
                    arraysList.Add(new List<int>(ArrayLength));
                for (int i = 0; i < ArrayLength; i++)
                {
                    int randValue = ArrayGenerator.Next(ArrayLength);
                    for (int j = 0; j < AlgorithmsCount; j++)
                        arraysList[j].Add(randValue);
                }

                Console.WriteLine($"Array length = {ArrayLength}; Key = {key}");

                ValuesPair<ArrayValue<int>, ArrayValue<int>> result;

                if (ArrayLength < 100000)
                {
                    Timer.Restart();
                    result = BruteForce.FindPair(arraysList[0], key);
                    Timer.Stop();
                    TimeForAlgorithm = Timer.Elapsed.TotalMilliseconds;
                    Console.WriteLine("Time for brute force algorithm (in ms):");
                    Console.WriteLine(TimeForAlgorithm);
                    Console.WriteLine($"Result: {result}");
                }

                Timer.Restart();
                result = SortingMethod.FindPair(arraysList[1], key);
                Timer.Stop();
                TimeForAlgorithm = Timer.Elapsed.TotalMilliseconds;
                Console.WriteLine("Time for sorting base algorithm (in ms):");
                Console.WriteLine(TimeForAlgorithm);
                Console.WriteLine($"Result: {result}");

                Timer.Restart();
                result = HashTableMethod.FindPair(arraysList[2], key);
                Timer.Stop();
                TimeForAlgorithm = Timer.Elapsed.TotalMilliseconds;
                Console.WriteLine("Time for hash-table base algorithm (in ms):");
                Console.WriteLine(TimeForAlgorithm);
                Console.WriteLine($"Result: {result}");

                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
