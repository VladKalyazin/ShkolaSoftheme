using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringHashCode
{
    class Program
    {
        public class RecurtionData
        {
            public const int MaxCounts = 10;

            public bool isDone = false;
            public int counter = 0;
        }

        public class StringFinder
        {
            public const int MaxStringLength = 5;
            public const char MinChar = 'a';
            public const char MaxChar = 'z';

            public Dictionary<int, string> HashCodes = new Dictionary<int, string>(10000000);

            public void Find(string input, RecurtionData data)
            {
                if (input.Length > MaxStringLength)
                    return;
                for (char c = 'a'; c < 'z'; c++)
                {
                    if (data.isDone)
                        return;
                    string s = input + c;
                    try
                    {
                        HashCodes.Add(s.GetHashCode(), s);
                        Find(s, data);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(s);
                        Console.WriteLine(HashCodes[s.GetHashCode()]);
                        Console.WriteLine();
                        data.counter++;
                        if (data.counter > RecurtionData.MaxCounts)
                            data.isDone = true;
                        return;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            var finder = new StringFinder();
            finder.Find("", new RecurtionData());

            Console.WriteLine("adaaa".GetHashCode());
            Console.WriteLine("acaaaa".GetHashCode());

            Console.ReadLine();
        }
    }
}
