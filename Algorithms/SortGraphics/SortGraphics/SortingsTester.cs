using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using OxyPlot;

namespace SortGraphics
{
    public static class SortingsTester
    {
        public static int MinArrayLength { get; set; } = 10;
        public static int MaxArrayLength { get; set; } = 10000;
        public static int CountOfIterations { get; set; } = 100;
        public static int CountOfSortings { get; set; } = 500;

        public delegate void ArrayLengthChangedHandler(int length);
        public static event ArrayLengthChangedHandler ArrayLengthChanged;

        public static Dictionary<string, List<DataPoint>> GetTestAnalysis(Dictionary<string, Action<List<int>>> Sortings)
        {
            if (Sortings == null)
                return null;
         
            var Data = new Dictionary<string, List<DataPoint>>();
            var ElapsedTimes = new Dictionary<string, List<double>>();
            Data.Clear();
            foreach (string key in Sortings.Keys)
            {
                Data.Add(key, new List<DataPoint>());
                ElapsedTimes.Add(key, new List<double>());
            }

            Random ArrayGenerator = new Random();
            var SortTimer = new Stopwatch();
            double TimeForAlgorithm;
            int Step = (MaxArrayLength - MinArrayLength) / CountOfIterations;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength += ArrayLength / 2)
            {
                ArrayLengthChanged?.Invoke(ArrayLength);

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
                        sorting.Value.Invoke(arraysList[iterator++]);
                        SortTimer.Stop();
                        TimeForAlgorithm = SortTimer.Elapsed.TotalMilliseconds;
                        if (TimeForAlgorithm > 0)
                            ElapsedTimes[sorting.Key].Add(TimeForAlgorithm);
                    }
                }

                foreach (var elapsedTime in ElapsedTimes)
                {
                    Data[elapsedTime.Key].Add(new DataPoint(ArrayLength, elapsedTime.Value.Average()));
                }
            }

            return Data;
        }
    }
}
