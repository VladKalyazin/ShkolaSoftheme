using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    public static class MergeSort
    {
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
                    Merge(array, i, leftEnd, leftEnd + 1, rightEnd);
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

        private static void Merge(int[] array, int leftBegin, int leftEnd, int rightBegin, int rightEnd)
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
        private const int ArrayLength = 1000;

        static void Main(string[] args)
        {
            Random ArrayGenerator = new Random();
            int[] array = new int[ArrayLength];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = ArrayGenerator.Next(ArrayLength);
            }

            MergeSort.BottomUp(array);

            Console.ReadKey();
        }
    }
}
