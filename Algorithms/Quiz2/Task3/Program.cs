using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static string CompressString(string input)
        {
            string result = String.Empty;
            char current = input[0];
            int counter = 1;
            for (int i = 1; i < input.Length; i++)
            {
                char c = input[i];
                if (c != current)
                {
                    result += current;
                    result += counter.ToString();
                    counter = 1;
                    current = c;
                }
                else
                {
                    counter++;
                }
            }
            if (counter > 0)
            {
                result += current;
                result += counter.ToString();
            }

            if (result.Length < input.Length)
                return result;
            return input;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(CompressString("aaaaabbbbcccc"));
            Console.WriteLine(CompressString("abc"));
            Console.WriteLine(CompressString("aaaaabc"));

            Console.ReadKey();
        }
    }
}
