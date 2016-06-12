using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            VladQueue<int> queue = new VladQueue<int>();
            for (int i = 0; i < 10; i++)
                queue.Enqueue(i);

            for (int i = 0; i < 10; i++)
                Console.WriteLine(queue.Dequeue());

            Console.WriteLine();

            VladStack<int> stack = new VladStack<int>();
            for (int i = 0; i < 10; i++)
                stack.Push(i);

            for (int i = 0; i < 10; i++)
                Console.WriteLine(stack.Pop());

            Console.WriteLine();

            VladDictionary<string, int> dictionary = new VladDictionary<string, int>();
            dictionary.Add("key1", 1);
            dictionary.Add("key2", 2);
            dictionary.Add("key3", 3);
            dictionary.Add("key4", 4);
            dictionary.Add("key5", 5);

            dictionary["key1"] = 15;
            Console.WriteLine(dictionary["key1"]);
            Console.WriteLine(dictionary["key2"]);
            Console.WriteLine(dictionary["key3"]);
            Console.WriteLine(dictionary["key4"]);
            Console.WriteLine(dictionary["key5"]);
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
