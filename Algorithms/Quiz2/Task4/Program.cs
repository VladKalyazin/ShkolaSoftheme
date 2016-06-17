using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static T GetElementByEnd<T>(LinkedList<T> list, int k)
        {
            int i = 0;
            var node = list.First;
            LinkedListNode<T> neededNode = null;
            while (node != null)
            {
                if (i == k)
                    neededNode = list.First;
                else if (i > k)
                    neededNode = neededNode.Next;
                node = node.Next;
                i++;
            }

            return neededNode.Value;
        }

        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 0; i < 10; i++)
                list.AddLast(i);

            Console.WriteLine(GetElementByEnd(list, 1));

            Console.ReadKey();
        }
    }
}
