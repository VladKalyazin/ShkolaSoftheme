using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    public static class QuickSort
    {
        private const int RecursionDeep = 15;

        private static Random _generator = new Random();

        public static void LomutoSort(List<int> array)
        {
            _LomutoSort(array, 0, array.Count - 1);
        }

        private static void _LomutoSort(List<int> array, int begin, int end)
        {
            if (begin >= end)
                return;
            int p = LomutoPartition(array, begin, end);
            _LomutoSort(array, begin, p - 1);
            _LomutoSort(array, p + 1, end);
        }

        public static void IntroSort(List<int> array)
        {
            _IntroSort(array, 0, array.Count - 1);
        }

        private static void _IntroSort(List<int> array, int begin, int end)
        {
            if (end - begin <= RecursionDeep)
                SortingBinaryTree.Sort(array, begin, end);
            int p = LomutoPartition(array, begin, end);
            _LomutoSort(array, begin, p - 1);
            _LomutoSort(array, p + 1, end);
        }

        private static int LomutoPartition(List<int> array, int begin, int end)
        {
            int p = begin;
            int key = array[end];

            for (int i = begin; i <= end - 1; i++)
            {
                if (array[i] <= key)
                    Swap(array, i, p++);
            }

            Swap(array, p, end);

            return p;
        }

        private static void Swap(List<int> array, int i, int j)
        {
            int buff = array[j];
            array[j] = array[i];
            array[i] = buff;
        }
    }
}
