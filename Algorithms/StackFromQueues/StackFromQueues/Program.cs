using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueFromStacks
{
    public class QueueFromStack
    {
        private Stack Tail, Head;

        public QueueFromStack()
        {
            Tail = new Stack();
            Head = new Stack();
        }

        public void Enqueue(object obj)
        {
            Tail.Push(obj);
        }

        public object Dequeue()
        {
            if (Head.Count == 0)
            {
                while (Tail.Count > 0)
                    Head.Push(Tail.Pop());
            }
            return Head.Pop();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            QueueFromStack q = new QueueFromStack();
            for (int i = 0; i < 10; i++)
                q.Enqueue(i);

            for (int i = 0; i < 10; i++)
                Console.WriteLine(q.Dequeue());

            Console.ReadKey();


        }
    }
}
