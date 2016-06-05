using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarConstructor
{
    public class Car
    {
        public string Engine { get; set; }
        public int Transmission { get; set; }
        public string Color { get; set; }
    }

    public class Engine
    {
        public string value { get; set; }
    }

    public class Color
    {
        public string value { get; set; }
    }

    public class Transmission
    {
        public int value { get; set; }
    }

    public static class CarConstructor
    {
        public static Car Construct(Engine e, Color c, Transmission t) =>
            new Car { Engine = e.value, Color = c.value, Transmission = t.value };

        public static void Reconstruct(Car car, Engine e)
        {
            car.Engine = e.value;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            

        }
    }
}
