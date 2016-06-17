using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    public static class BruteForce
    {
        public static ValuesPair<ArrayValue<int>, ArrayValue<int>> FindPair(List<int> array, int key)
        {
            for (int i = 0; i < array.Count; i++)
            {
                for (int j = i + 1; j < array.Count; j++)
                {
                    if (array[i] + array[j] == key)
                    {
                        var first = new ArrayValue<int>(i, array[i]);
                        var second = new ArrayValue<int>(j, array[j]);
                        return new ValuesPair<ArrayValue<int>, ArrayValue<int>>(first, second);
                    }
                }
            }

            return default(ValuesPair<ArrayValue<int>, ArrayValue<int>>);
        }
    }
}
