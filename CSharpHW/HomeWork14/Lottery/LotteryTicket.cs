using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public class LotteryTicket
    {
        public const int CountOfNumbers = 6;
        public const int MinValue = 1;
        public const int MaxValue = 9;

        private List<int> _Numbers { get; set; } = new List<int>();

        public LotteryTicket()
        {
            Random generator = new Random();
            for (int i = 0; i < CountOfNumbers; i++)
                _Numbers.Add(generator.Next(1, 9));
        }

        public int this[int key]
        {
            get
            {
                if (key < 0 || key >= CountOfNumbers)
                    throw new IndexOutOfRangeException("Invalid index");
                return _Numbers[key];
            }
        }
    }
}
