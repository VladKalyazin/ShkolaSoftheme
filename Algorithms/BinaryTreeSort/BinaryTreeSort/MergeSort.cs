using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeSort
{
    public static class MergeSort
    {
        public static void BottomUp<T>(List<T> array)
            where T : IComparable<T>
        {
            int k = 0;
            int degreeOfTwo = GetDegreeOfTwo(k);
            while (degreeOfTwo < array.Count)
            {
                int i = 0;
                while (i < array.Count)
                {
                    int leftEnd = i + degreeOfTwo - 1;
                    int rightEnd = leftEnd + degreeOfTwo;
                    if (leftEnd > array.Count)
                        leftEnd = array.Count - 1;
                    if (rightEnd > array.Count)
                        rightEnd = array.Count - 1;
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

        public static void TopDown<T>(List<T> array)
            where T : IComparable<T>
        {
            _TopDown(array, 0, array.Count - 1);
        }

        private static void _TopDown<T>(List<T> array, int begin, int end)
            where T : IComparable<T>
        {
            int length = end - begin + 1;
            if (length > 1)
            {
                int leftEnd = end - length / 2;
                _TopDown(array, begin, leftEnd);
                _TopDown(array, leftEnd + 1, end);
                Merge(array, begin, leftEnd, leftEnd + 1, end);
            }
            else
            {
                Merge(array, begin, begin, end, end);
            }
        }

        private static void Merge<T>(List<T> array, int leftBegin, int leftEnd, int rightBegin, int rightEnd)
            where T: IComparable<T>
        {
            int leftCopyIndex = 0;
            int leftLength = leftEnd - leftBegin + 1;
            List<T> leftCopy = new List<T>(leftLength);
            for (int i = leftBegin; i <= leftEnd; i++)
                leftCopy.Add(array[i]);

            while (leftBegin <= rightEnd)
            {
                if ((rightBegin > rightEnd) || ((leftCopyIndex < leftLength) && (leftCopy[leftCopyIndex].CompareTo(array[rightBegin]) <= 0)))
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
}
