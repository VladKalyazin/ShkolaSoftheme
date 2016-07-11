using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSort
{
    class Program
    {
        static void LibrarySort(List<int> array)
        {
            array.Sort();
        }

        static void Main(string[] args)
        {
            var sortings = new Dictionary<string, Action<List<int>>>();

            sortings.Add("Hash sort", HashSort.Sort);
            sortings.Add("Hash sort (TPL)", HashSort.Sort_TPL);
            //sortings.Add("Quick sort", QuickSort.LomutoSort);
            //sortings.Add("Heap sort", HeapSort.Sort);
            sortings.Add(".NET library sort", LibrarySort);

            // call static ctor
            List<int> startList = new List<int>() { 1, 2, 3 };
            foreach (var pair in sortings)
            {
                pair.Value.Invoke(startList);
            }

            Dictionary<string, List<Tuple<int, double>>> data;

            data = SortingsTester.GetTestAnalysis(sortings);

            /*try
            {
                data = SortingsTester.GetTestAnalysis(sortings);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                return;
            }*/

            foreach (var sortDataPair in data)
            {
                Console.WriteLine($"Time for {sortDataPair.Key} (in ms):");
                foreach (var sortData in sortDataPair.Value)
                {
                    Console.WriteLine($"Array length: {sortData.Item1.ToString().PadRight(8)}; Time: {sortData.Item2}");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
