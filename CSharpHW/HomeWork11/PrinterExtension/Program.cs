using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Printer;

namespace PrinterExtension
{
    public static class PrinterExtension
    {
        public static void PrintArray(this Printer.Printer printer, string[] args)
        {
            foreach (var str in args)
                printer.Print(str);
        }

        public static void PrintArray(this Printer.ColourPrinter printer, string[] args, ConsoleColor color)
        {
            foreach (var str in args)
                printer.Print(str, color);
        }

        public static void PrintArray(this Printer.PhotoPrinter printer, object[] photos)
        {
            foreach (var photo in photos)
                printer.Print(photo);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
