using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDescriptor
{
    public class ShapeDescriptor
    {
        private Point[] Points;

        public ShapeDescriptor(params Point[] points)
        {
            Points = points;
        }

        public int ShapeType()
        {
            return Points.Length;
        }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Point p = new Point();
            ShapeDescriptor sd = new ShapeDescriptor(p, p, p, p);
            Console.WriteLine(sd.ShapeType());

            Console.ReadKey();
        }
    }
}
