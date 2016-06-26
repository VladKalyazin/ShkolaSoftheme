using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HomeWork25
{
    class Program
    {
        static void Main(string[] args)
        {
            //TaskArchiver.Archive("C:\\Users\\1user\\Documents\\softheme\\25_Multithreading");
            TaskArchiver.Extract("C:\\Users\\1user\\Documents\\softheme\\25_Multithreading");

            Console.ReadKey();
        }
    }
}
