using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace ConsoleCalc
{

    class Program
    {
        static void Main(string[] args)
        {
            string expr = Console.ReadLine();
            try
            {
                Console.WriteLine(MathExpression.Solve(expr).ToString("F"));
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
            Console.ReadKey();
        }
    }
}
