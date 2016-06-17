using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static bool Contains(int[] array, int value)
        {
            int l = 0;
            int u = array.Length - 1;
            while (l <= u)
            {
                int mid = (l + u) / 2;
                if (array[mid] > value)
                    u = mid - 1;
                else if (array[mid] < value)
                    l = mid + 1;
                else
                    return true;
            }

            return false;
        }

        static List<int> FindCommon(int[] array1, int[] array2)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < array1.Length; i++)
            {
                if (Contains(array2, array1[i]))
                    result.Add(array1[i]);
            }

            return result;
        }

        static List<int> FindCommon_v2(int[] array1, int[] array2)
        {
            List<int> result = new List<int>();
            int j = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                int firstValue = array1[i];
                while (firstValue > array2[j])
                    j++;
                int secondValue = array2[j];
                if (firstValue == secondValue)
                    result.Add(secondValue);
            }

            return result;
        }

        static void Main(string[] args)
        {
            int[] array1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] array2 = new int[] { 1, 3, 4, 5, 6, 9, 11, 12, 14 };
            List<int> result = FindCommon(array1, array2);
            List<int> result2 = FindCommon_v2(array1, array2);

            foreach (int value in result)
                Console.WriteLine(value);

            Console.WriteLine();

            foreach (int value in result2)
                Console.WriteLine(value);

            Console.ReadKey();

        }
    }
}
