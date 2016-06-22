using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace HashSort
{
    public static class SortingsTester
    {
        public static int MinArrayLength { get; set; } = 20;
        public static int MaxArrayLength { get; set; } = 1000000;
        public static int CountOfSortings { get; set; } = 50;

        public static Dictionary<string, List<Tuple<int, double>>> GetTestAnalysis(Dictionary<string, Action<List<int>>> Sortings)
        {
            if (Sortings == null)
                return null;

            var Data = new Dictionary<string, List<Tuple<int, double>>>();
            var ElapsedTimes = new Dictionary<string, List<double>>();
            Data.Clear();
            foreach (string key in Sortings.Keys)
            {
                Data.Add(key, new List<Tuple<int, double>>());
                ElapsedTimes.Add(key, new List<double>());
            }

            Random ArrayGenerator = new Random();
            var SortTimer = new Stopwatch();
            double TimeForAlgorithm;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength += ArrayLength / 2)
            {
                foreach (string key in Sortings.Keys)
                    ElapsedTimes[key].Clear();

                for (int SameLengthIteration = 0; SameLengthIteration < CountOfSortings; SameLengthIteration++)
                {
                    List<List<int>> arraysList = new List<List<int>>();
                    for (int j = 0; j < Sortings.Count; j++)
                        arraysList.Add(new List<int>(ArrayLength));
                    for (int i = 0; i < ArrayLength; i++)
                    {
                        int randValue = ArrayGenerator.Next(ArrayLength);
                        for (int j = 0; j < Sortings.Count; j++)
                            arraysList[j].Add(randValue);
                    }

                    int iterator = 0;
                    foreach (var sorting in Sortings)
                    {
                        SortTimer.Restart();
                        sorting.Value.Invoke(arraysList[iterator]);
                        SortTimer.Stop();
                        TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                        if (TimeForAlgorithm > 0)
                            ElapsedTimes[sorting.Key].Add(TimeForAlgorithm);

                        for (int i = 1; i < arraysList[iterator].Count; i++)
                        {
                            if (arraysList[iterator][i] < arraysList[iterator][i - 1])
                                throw new Exception("Invalid sorting algorithm.");
                        }

                        iterator++;
                    }
                }

                foreach (var elapsedTime in ElapsedTimes)
                {
                    Data[elapsedTime.Key].Add(new Tuple<int, double>(ArrayLength, elapsedTime.Value.Average()));
                }
            }

            return Data;
        }
    }
}