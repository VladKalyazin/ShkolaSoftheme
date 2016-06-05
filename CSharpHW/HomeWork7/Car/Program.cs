using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car
{
    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
    }

    public static class TuningAtelier
    {
        public static void TuneCar(Car c)
        {
            c.Color = "red";
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Car c = new Car();
            TuningAtelier.TuneCar(c);
            Console.WriteLine(c.Color);

            Console.ReadKey();
        }
    }
}
