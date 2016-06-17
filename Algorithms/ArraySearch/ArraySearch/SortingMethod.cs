using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    public static class SortingMethod
    {
        public static ValuesPair<ArrayValue<int>, ArrayValue<int>> FindPair(List<int> array, int key)
        {
            array.Sort();
            int i = 0;
            int j = array.Count - 1;
            while (i < j)
            {
                while (key - array[i] > array[j])
                {
                    if (i < array.Count - 1)
                        i++;
                    else
                        return default(ValuesPair<ArrayValue<int>, ArrayValue<int>>);
                }
                while (key - array[j] < array[i])
                {
                    if (j > 1)
                        j--;
                    else
                        return default(ValuesPair<ArrayValue<int>, ArrayValue<int>>);
                }
                if (array[i] + array[j] == key && i != j)
                {
                    var first = new ArrayValue<int>(i, array[i]);
                    var second = new ArrayValue<int>(j, array[j]);
                    return new ValuesPair<ArrayValue<int>, ArrayValue<int>>(first, second);
                }
            }

            return default(ValuesPair<ArrayValue<int>, ArrayValue<int>>);
        }
    }
}
