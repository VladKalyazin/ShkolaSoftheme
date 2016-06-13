using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    public static class InsertionSort
    {
        public static void Sort<T>(List<T> array)
            where T : IComparable<T>
        {
            Sort(array, 0, array.Count - 1);
        }

        public static void Sort<T>(List<T> array, int begin, int end)
            where T: IComparable<T>
        {
            for (int i = begin + 1; i <= end; i++)
            {
                int j = i;
                T buff = array[j];
                while ((j > 0) && (array[j - 1].CompareTo(buff) > 0))
                {
                    array[j] = array[j - 1];
                    --j;
                }
                array[j] = buff;
            }
        }

        private static void Swap<T>(List<T> array, int i, int j)
        {
            T buff = array[j];
            array[j] = array[i];
            array[i] = buff;
        }
    }
}
