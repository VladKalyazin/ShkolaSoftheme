using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Printer
{
    public class Printer
    {
        public virtual void Print(string arg)
        {
            Console.WriteLine(arg);
        }
    }

    public class ColourPrinter : Printer
    {
        public override void Print(string arg)
        {
            base.Print(arg);
        }

        public void Print(string arg, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            Print(arg);
        }
    }

    public class PhotoPrinter : Printer
    {
        public override void Print(string arg)
        {
            base.Print(arg);
        }

        public void Print(object photo)
        {
            // do something with photo
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
