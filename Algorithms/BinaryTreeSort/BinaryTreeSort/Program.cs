using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTreeSort
{
    class Program
    {
        private const int MinArrayLength = 10;
        private const int MaxArrayLength = 1000000;
        private const int CountOfIterations = 1000;
        private const int ArraysCount = 10;

        static void Main(string[] args)
        {
            Random ArrayGenerator = new Random();
            var SortTimer = new Stopwatch();
            double AverageTime, TimeForAlgorithm;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength *= 2)
            {
                Console.WriteLine($"Array length = {ArrayLength}");
                List<double> TimesForBottomUpMergeSort = new List<double>(CountOfIterations);
                List<double> TimesForTopDownMergeSort = new List<double>(CountOfIterations);
                List<double> TimesForBinaryTreeSort = new List<double>(CountOfIterations);
                List<double> TimesForQuickSort = new List<double>(CountOfIterations);
                List<double> TimesForQuickInsertSort = new List<double>(CountOfIterations);
                List<double> TimesForInsertionSort = new List<double>(CountOfIterations);
                //List<double> TimesForIntroSort = new List<double>(CountOfIterations);
                for (int SameLengthIteration = 0; SameLengthIteration < CountOfIterations; SameLengthIteration++)
                {
                    List<List<int>> arraysList = new List<List<int>>();
                    for (int j = 0; j < ArraysCount; j++)
                        arraysList.Add(new List<int>(ArrayLength));
                    for (int i = 0; i < ArrayLength; i++)
                    {
                        int randValue = ArrayGenerator.Next(ArrayLength);
                        for (int j = 0; j < ArraysCount; j++)
                            arraysList[j].Add(randValue);
                    }

                    SortTimer.Restart();
                    MergeSort.BottomUp(arraysList[0]);
                    SortTimer.Stop();
                    TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForBottomUpMergeSort.Add(TimeForAlgorithm);

                    SortTimer.Restart();
                    MergeSort.TopDown(arraysList[1]);
                    SortTimer.Stop();
                    TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForTopDownMergeSort.Add(TimeForAlgorithm);

                    SortTimer.Restart();
                    SortingBinaryTree.Sort(arraysList[2]);
                    SortTimer.Stop();
                    TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForBinaryTreeSort.Add(TimeForAlgorithm);

                    SortTimer.Restart();
                    QuickSort.LomutoSort(arraysList[3]);
                    SortTimer.Stop();
                    TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForQuickSort.Add(TimeForAlgorithm);

                    SortTimer.Restart();
                    QuickSort.WithInsertionSort(arraysList[4]);
                    SortTimer.Stop();
                    TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                    if (TimeForAlgorithm > 0)
                        TimesForQuickInsertSort.Add(TimeForAlgorithm);

                    if (ArrayLength < 1000)
                    {
                        SortTimer.Restart();
                        InsertionSort.Sort(arraysList[5]);
                        SortTimer.Stop();
                        TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                        if (TimeForAlgorithm > 0)
                            TimesForInsertionSort.Add(TimeForAlgorithm);
                    }
                }

                AverageTime = 0;
                foreach (var time in TimesForBottomUpMergeSort)
                    AverageTime += time;
                AverageTime /= TimesForBottomUpMergeSort.Count;

                Console.WriteLine("Average time for BottomUp Merge sort (in ms):");
                Console.WriteLine(AverageTime);

                AverageTime = 0;
                foreach (var time in TimesForTopDownMergeSort)
                    AverageTime += time;
                AverageTime /= TimesForTopDownMergeSort.Count;

                Console.WriteLine("Average time for TopDown Merge sort (in ms):");
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
                foreach (var time in TimesForQuickInsertSort)
                    AverageTime += time;
                AverageTime /= TimesForQuickInsertSort.Count;

                Console.WriteLine("Average time for QuickSort hybrid with InsertionSort (in ms):");
                Console.WriteLine(AverageTime);

                if (ArrayLength < 1000)
                {
                    AverageTime = 0;
                    foreach (var time in TimesForInsertionSort)
                        AverageTime += time;
                    AverageTime /= TimesForInsertionSort.Count;

                    Console.WriteLine("Average time for InsertionSort (in ms):");
                    Console.WriteLine(AverageTime);
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
