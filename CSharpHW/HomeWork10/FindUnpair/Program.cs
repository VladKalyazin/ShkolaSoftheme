using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindUnpair
{
    class Program
    {
        public const int ArrayLength = 10001;

        public static void GenerateArray(int[] array)
        {
            var generator = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = i / 2;
            int randomValue = generator.Next(array.Length);
            array[array.Length - 1] = randomValue;
            array[generator.Next(array.Length)] = randomValue;
        }

        public static int FindUnpairValue(int[] array)
        {
            Dictionary<int, int> CountOfEachElem = new Dictionary<int, int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!CountOfEachElem.ContainsKey(array[i]))
                    CountOfEachElem.Add(array[i], 0);
                CountOfEachElem[array[i]]++;
            }

            foreach (var CountPair in CountOfEachElem)
            {
                if (CountPair.Value % 2 != 0)
                    return CountPair.Key;
            }

            return 0;
        }

        static void Main(string[] args)
        {
            int[] array = new int[ArrayLength];
            GenerateArray(array);
            Console.WriteLine(FindUnpairValue(array));

            Console.ReadKey();
        }
    }
}
