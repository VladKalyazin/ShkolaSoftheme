using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayMethods
{
    public static class ArrayExtension
    {
        public static void _Add<T>(ref T[] array, T value)
        {
            T[] newArray = new T[array.Length + 1];
            int i;
            for (i = 0; i < array.Length; i++)
                newArray[i] = array[i];
            newArray[i] = value;
            array = newArray;
        }

        public static bool _Contains<T>(this T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                    return true;
            }

            return false;
        }

        public static T _GetByIndex<T>(this T[] array, int index) => array[index];

    }

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(array._GetByIndex(0));
            ArrayExtension._Add(ref array, 10);
            Console.WriteLine(array._Contains(10));

            Console.ReadKey();
        }
    }
}
