using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    public struct ArrayValue<TValue>
    {
        public int Index { get; set; }
        public TValue Value { get; set; }

        public ArrayValue(int index, TValue value)
        {
            Index = index;
            Value = value;
        }

        public override string ToString()
        {
            return $"a[{Index}] = {Value}";
        }
    }

    public struct ValuesPair<TFirst, TSecond>
    {
        public TFirst FirstValue { get; set; }
        public TSecond SecondValue { get; set; }

        public ValuesPair(TFirst firstValue, TSecond secondValue)
        {
            FirstValue = firstValue;
            SecondValue = secondValue;
        }

        public override string ToString()
        {
            return $"First: {FirstValue}; Second: {SecondValue}";
        }
    }

}

