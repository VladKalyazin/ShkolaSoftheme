using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace QueueFromStacks
{
    public interface IQueue
    {
        int Count { get; }

        void Enqueue(object obj);
        object Dequeue();
    }

    public class QueueFromStack : IQueue
    {
        private Stack Tail, Head;

        public int Count
        {
            get
            {
                return Tail.Count + Head.Count;
            }
        }

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
                if (Tail.Count == 0)
                    return null;
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
            int i = 0;
            for (i = 0; i < 10; i++)
                q.Enqueue(i);

            Console.WriteLine(q.Dequeue());
            Console.WriteLine(q.Dequeue());
            Console.WriteLine();

            for (i = 0; i < 10; i++)
                q.Enqueue(i);

            while (q.Count > 0)
                Console.WriteLine(q.Dequeue());

            Console.ReadKey();
        }
    }
}
