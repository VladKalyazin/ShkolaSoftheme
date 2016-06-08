using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    class Program
    {
        private const int MinArrayLength = 1000;
        private const int MaxArrayLength = 10000000;
        private const int CountOfIterations = 20;

        static void Main(string[] args)
        {
            Random ArrayGenerator = new Random();
            DateTime StartTime, FinishTime;
            double AverageTime, TimeForAlgorithm;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength *= 4)
            {
                Console.WriteLine($"Array length = {ArrayLength}");
                List<double> TimesForMergeSort = new List<double>(CountOfIterations);
                List<double> TimesForBinaryTreeSort = new List<double>(CountOfIterations);
                List<double> TimesForQuickSort = new List<double>(CountOfIterations);
                List<double> TimesForIntroSort = new List<double>(CountOfIterations);
                for (int SameLengthIteration = 0; SameLengthIteration < CountOfIterations; SameLengthIteration++)
                {
                    List<int> array = new List<int>(ArrayLength);
                    List<int> array2 = new List<int>(ArrayLength);
                    List<int> array3 = new List<int>(ArrayLength);
                    List<int> array4 = new List<int>(ArrayLength);
                    for (int i = 0; i < ArrayLength; i++)
                    {
                        int randValue = ArrayGenerator.Next(ArrayLength);
                        array.Add(randValue);
                        array2.Add(randValue);
                        array3.Add(randValue);
                        array4.Add(randValue);
                    }

                    StartTime = DateTime.Now;
                    MergeSort.BottomUp(array);
                    FinishTime = DateTime.Now;
                    TimeForAlgorithm = (FinishTime - StartTime).TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForMergeSort.Add(TimeForAlgorithm);

                    StartTime = DateTime.Now;
                    SortingBinaryTree.Sort(array2);
                    FinishTime = DateTime.Now;
                    TimeForAlgorithm = (FinishTime - StartTime).TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForBinaryTreeSort.Add(TimeForAlgorithm);

                    StartTime = DateTime.Now;
                    QuickSort.LomutoSort(array3);
                    FinishTime = DateTime.Now;
                    TimeForAlgorithm = (FinishTime - StartTime).TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForQuickSort.Add(TimeForAlgorithm);

                    StartTime = DateTime.Now;
                    QuickSort.IntroSort(array4);
                    FinishTime = DateTime.Now;
                    TimeForAlgorithm = (FinishTime - StartTime).TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForIntroSort.Add(TimeForAlgorithm);
                }

                AverageTime = 0;
                foreach (var time in TimesForMergeSort)
                    AverageTime += time;
                AverageTime /= TimesForMergeSort.Count;

                Console.WriteLine("Average time for BottomUp Merge sort (in ms):");
                Console.WriteLine(AverageTime);


                AverageTime = 0;
                foreach (var time in TimesForBinaryTreeSort)
                    AverageTime += time;
                AverageTime /= TimesForBinaryTreeSort.Count;

                Console.WriteLine("Average time for BinaryTree sort (in ms):");
                Console.WriteLine(AverageTime);

                AverageTime = 0;
                foreach (var time in TimesForQuickSort)
                    AverageTime += time;
                AverageTime /= TimesForQuickSort.Count;

                Console.WriteLine("Average time for QuickSort (in ms):");
                Console.WriteLine(AverageTime);

                AverageTime = 0;
                foreach (var time in TimesForIntroSort)
                    AverageTime += time;
                AverageTime /= TimesForIntroSort.Count;

                Console.WriteLine("Average time for IntroSort (in ms):");
                Console.WriteLine(AverageTime);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
