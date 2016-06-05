using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public static class MergeSort
    {
        public const int RecursionDeep = 10;

        public static void InsertionSort(int[] array)
        {
            _InsertionSort(array, 0, array.Length - 1);
        }

        public static void _InsertionSort(int[] array, int begin, int end)
        {
            for (int i = begin + 1; i <= end; i++)
            {
                int j = i - 1;
                while ((j >= 0) && (array[j] > array[j + 1]))
                {
                    Swap2(array, j, j + 1);
                    j--;
                }
            }
        }

        public static int[] TopDown(int[] array)
        {
            if (array.Length > 1)
            {
                int length1 = array.Length / 2;
                int length2 = array.Length - length1;
                int[] arr1 = new int[length1];
                int[] arr2 = new int[length2];
                Array.Copy(array, 0, arr1, 0, length1);
                Array.Copy(array, length1, arr2, 0, length2);
                return Merge(TopDown(arr1), TopDown(arr2));
            }
            return array;
        }

        public static void TopDown2(int[] array)
        {
            _TopDown2(array, 0, array.Length - 1);
        }

        private static void _TopDown2(int[] array, int begin, int end)
        {
            int length = end - begin + 1;
            if (length > 1)
            {
                int leftEnd = end - length / 2;
                _TopDown2(array, begin, leftEnd);
                _TopDown2(array, leftEnd + 1, end);
                Merge2(array, begin, leftEnd, leftEnd + 1, end);
            }
            else
            {
                Merge2(array, begin, begin, end, end);
            }
        }

        public static void TopDown3(int[] array)
        {
            _TopDown3(array, 0, array.Length - 1);
        }

        private static void _TopDown3(int[] array, int begin, int end)
        {
            int length = end - begin + 1;
            if (length > RecursionDeep)
            {
                int leftEnd = end - length / 2;
                _TopDown3(array, begin, leftEnd);
                _TopDown3(array, leftEnd + 1, end);
                Merge2(array, begin, leftEnd, leftEnd + 1, end);
            }
            else
            {
                _InsertionSort(array, begin, end);
            }
        }

        public static void BottomUp(int[] array)
        {
            int k = 0;
            int degreeOfTwo = GetDegreeOfTwo(k);
            while (degreeOfTwo < array.Length)
            {
                int i = 0;
                while (i < array.Length)
                {
                    int leftEnd = i + degreeOfTwo - 1;
                    int rightEnd = leftEnd + degreeOfTwo;
                    if (leftEnd > array.Length)
                        leftEnd = array.Length - 1;
                    if (rightEnd > array.Length)
                        rightEnd = array.Length - 1;
                    Merge2(array, i, leftEnd, leftEnd + 1, rightEnd);
                    i += 2 * degreeOfTwo;
                }

                k++;
                degreeOfTwo = GetDegreeOfTwo(k);
            }
        }

        private static int GetDegreeOfTwo(int pow)
        {
            int result = 1;
            for (int i = 1; i < pow; i++)
                result *= 2;
            return result;
        }

        private static void Swap(int[] array, int i, int j)
        {
            int buff = array[j];
            array[j] = array[i];
            array[i] = buff;
        }

        private static void Swap2(int[] array, int i, int j)
        {
            array[i] ^= array[j];
            array[j] ^= array[i];
            array[i] ^= array[j];
        }

        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int[] result = new int[arr1.Length + arr2.Length];
            int i = 0, j = 0;

            while (i < arr1.Length && j < arr2.Length)
            {
                result[i + j] = (arr1[i] < arr2[j]) ? arr1[i++] : arr2[j++];
            }

            while (i < arr1.Length)
                result[i + j] = arr1[i++];
            while (j < arr2.Length)
                result[i + j] = arr2[j++];

            return result;
        }

        private static void Merge2(int[] array, int leftBegin, int leftEnd, int rightBegin, int rightEnd)
        {
            int leftCopyIndex = 0;
            int leftLength = leftEnd - leftBegin + 1;
            int[] leftCopy = new int[leftLength];
            Array.Copy(array, leftBegin, leftCopy, 0, leftLength);
            
            while (leftBegin <= rightEnd)
            {
                if ((rightBegin > rightEnd) || ((leftCopyIndex < leftLength) && (leftCopy[leftCopyIndex] <= array[rightBegin])))
                {
                    array[leftBegin++] = leftCopy[leftCopyIndex++];
                }
                else
                {
                    array[leftBegin++] = array[rightBegin++];
                }
            }

        }
    }

    class Program
    {
        private const int MinArrayLength = 1000;
        private const int MaxArrayLength = 10000000;

        static void Main(string[] args)
        {
            Random ArrayGenerator = new Random();
            DateTime StartTime, FinishTime;

            for (int ArrayLength = MinArrayLength; ArrayLength < MaxArrayLength; ArrayLength *= 4)
            {
                Console.WriteLine($"Array length = {ArrayLength}");
                int[] array = new int[ArrayLength];
                int[] array2 = new int[ArrayLength];
                int[] array3 = new int[ArrayLength];
                int[] array4 = new int[ArrayLength];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = ArrayGenerator.Next(ArrayLength);
                }
                Array.Copy(array, 0, array2, 0, ArrayLength);
                Array.Copy(array, 0, array3, 0, ArrayLength);
                Array.Copy(array, 0, array4, 0, ArrayLength);

                if (ArrayLength < 10000)
                {
                    StartTime = DateTime.Now;
                    MergeSort.InsertionSort(array);
                    FinishTime = DateTime.Now;
                    Console.WriteLine("Time for Insertion sort (in ms):");
                    Console.WriteLine((FinishTime - StartTime).TotalMilliseconds);
                }

                StartTime = DateTime.Now;
                array2 = MergeSort.TopDown(array2);
                FinishTime = DateTime.Now;
                Console.WriteLine("Time for TopDown Merge sort (in ms):");
                Console.WriteLine((FinishTime - StartTime).TotalMilliseconds);

                StartTime = DateTime.Now;
                MergeSort.TopDown2(array3);
                FinishTime = DateTime.Now;
                Console.WriteLine("Time for TopDown Merge sort with O(n/2) additional memory(in ms):");
                Console.WriteLine((FinishTime - StartTime).TotalMilliseconds);

                StartTime = DateTime.Now;
                MergeSort.BottomUp(array4);
                FinishTime = DateTime.Now;
                Console.WriteLine("Time for BottomUp Merge sort (in ms):");
                Console.WriteLine((FinishTime - StartTime).TotalMilliseconds);

                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
