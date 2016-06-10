using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    public static class QuickSort
    {
        private const int RecursionDeep = 30;

        private static Random _generator = new Random();

        public static void LomutoSort<T>(List<T> array)
            where T : IComparable<T>
        {
            _LomutoSort(array, 0, array.Count - 1);
        }

        private static void _LomutoSort<T>(List<T> array, int begin, int end)
            where T : IComparable<T>
        {
            if (begin >= end)
                return;
            int p = LomutoPartition(array, begin, end);
            _LomutoSort(array, begin, p - 1);
            _LomutoSort(array, p + 1, end);
        }

        public static void WithInsertionSort<T>(List<T> array)
            where T : IComparable<T>
        {
            _WithInsertionSort(array, 0, array.Count - 1);
        }

        private static void _WithInsertionSort<T>(List<T> array, int begin, int end)
            where T : IComparable<T>
        {
            if (end - begin <= RecursionDeep)
                InsertionSort.Sort(array, begin, end);
            int p = LomutoPartition(array, begin, end);
            _LomutoSort(array, begin, p - 1);
            _LomutoSort(array, p + 1, end);
        }

        private static int LomutoPartition<T>(List<T> array, int begin, int end)
            where T : IComparable<T>
        {
            int p = begin;
            T key = array[end];

            for (int i = begin; i <= end - 1; i++)
            {
                if (array[i].CompareTo(key) <= 0)
                    Swap(array, i, p++);
            }

            Swap(array, p, end);

            return p;
        }

        private static void Swap<T>(List<T> array, int i, int j)
        {
            T buff = array[j];
            array[j] = array[i];
            array[i] = buff;
        }
    }
}
