using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork13
{
    public class ResourceHolderBase : IDisposable
    {
        protected object Resourses;

        public virtual void Dispose()
        {
            if (Resourses != null)
                Console.WriteLine("holder base data released (dispose)");
        }

        ~ResourceHolderBase()
        {
            if (Resourses != null)
                Console.WriteLine("holder base data released (dtor)");
        }
    }

    public class ResourceHolderDerived : ResourceHolderBase, IDisposable
    {
        public override void Dispose()
        {
            base.Dispose();
            if (Resourses != null)
                Console.WriteLine("holder derived data released (dispose)");
        }

        ~ResourceHolderDerived()
        {
            if (Resourses != null)
                Console.WriteLine("holder derived data released (dtor)");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
