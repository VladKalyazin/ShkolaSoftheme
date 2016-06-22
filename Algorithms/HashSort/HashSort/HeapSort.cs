using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSort
{
    public static class HeapSort
    {
        private static int _Length = 0;

        public static void Sort(List<int> array)
        {
            _Length = array.Count;

            for (int i = (_Length + 1) / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(array, i);
            }

            while (_Length > 1)
            {
                Swap(array, 0, _Length - 1);
                _Length--;
                MaxHeapify(array, 0);
            }

        }

        private static void MaxHeapify(List<int> array, int index)
        {
            bool isDone = false;
            while (!isDone)
            {
                int leftIndex = (index + 1) * 2 - 1;
                int rightIndex = (index + 1) * 2;

                if (leftIndex < _Length && array[leftIndex] > array[index])
                {
                    Swap(array, leftIndex, index);
                    index = leftIndex;
                } 
                else if (rightIndex < _Length && array[rightIndex] > array[index])
                {
                    Swap(array, rightIndex, index);
                    index = rightIndex;
                }
                else
                {
                    isDone = true;
                }
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
