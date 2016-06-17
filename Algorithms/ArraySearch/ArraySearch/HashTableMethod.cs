using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySearch
{
    public static class HashTableMethod
    {
        public const int MaxHashTableCapacity = 100000;

        public static ValuesPair<ArrayValue<int>, ArrayValue<int>> FindPair(List<int> array, int key)
        {
            Dictionary<int, ArrayValue<int>> DiffTable = new Dictionary<int, ArrayValue<int>>(array.Count < MaxHashTableCapacity ? array.Count : MaxHashTableCapacity);
            for (int i = 0; i < array.Count; i++)
            {
                var arrayValue = new ArrayValue<int>(i, array[i]);
                int result = key - arrayValue.Value;
                if (!DiffTable.ContainsKey(result))
                    DiffTable.Add(result, arrayValue);
            }

            for (int i = 0; i < array.Count; i++)
            {
                var arrayValue = new ArrayValue<int>(i, array[i]);
                if (DiffTable.ContainsKey(arrayValue.Value))
                {
                    var first = arrayValue;
                    var second = DiffTable[arrayValue.Value];
                    return new ValuesPair<ArrayValue<int>, ArrayValue<int>>(first, second);
                }
            }

            return default(ValuesPair<ArrayValue<int>, ArrayValue<int>>);
        }
    }
}