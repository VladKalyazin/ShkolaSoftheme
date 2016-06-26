using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashSort
{
    public static class HashSort
    {
        private class _Item
        {
            public int Value { get; set; }
            public int Count { get; set; }
            public _Item Next { get; set; }
        }

        public static void Sort(List<int> array)
        {
            _Item[] hashTable = new _Item[array.Count];

            int minValue = array[0];
            int maxValue = array[0];
            int length = array.Count;
            for (int i = 1; i < length; i++)
            {
                int current = array[i];
                if (minValue > current)
                    minValue = current;
                if (maxValue < current)
                    maxValue = current;
            }

            for (int i = 0; i < length; i++)
            {
                int value = array[i];
                int index = (int)(((long)(value - minValue)) * length / (maxValue - minValue));
                if (index >= length)
                    index = length - 1;
                _Item pointer = hashTable[index];
                if (pointer == null)
                {
                    hashTable[index] = new _Item { Value = value, Count = 1, Next = null };
                }
                else
                {
                    if (pointer.Value == value)
                    {
                        pointer.Count++;
                    }
                    else
                    {
                        while (pointer.Next != null && pointer.Next.Value != value)
                        {
                            pointer = pointer.Next;
                        }

                        if (pointer.Next == null)
                        {
                            pointer.Next = new _Item { Value = value, Count = 1, Next = null };
                        }
                        else
                        {
                            pointer.Next.Count++;
                        }
                    }
                }
            }

            int arrayIterator = 0;

            for (int i = 0; i < hashTable.Length; i++)
            {
                _Item pointer = hashTable[i];
                while (pointer != null)
                {
                    for (int j = 0; j < pointer.Count; j++)
                    {
                        array[arrayIterator++] = pointer.Value;
                    }
                    pointer = pointer.Next;
                }
            }

        }

        public static void Sort_TPL(List<int> array)
        {
            _Item[] hashTable = new _Item[array.Count];

            int minValue = array[0];
            int maxValue = array[0];
            int length = array.Count;
            for (int i = 1; i < length; i++)
            {
                int current = array[i];
                if (minValue > current)
                    minValue = current;
                if (maxValue < current)
                    maxValue = current;
            }

            for (int i = 0; i < length; i++)
            {
                int value = array[i];
                int index = (int)(((long)(value - minValue)) * length / (maxValue - minValue));
                if (index >= length)
                    index = length - 1;
                _Item pointer = hashTable[index];
                if (pointer == null)
                {
                    hashTable[index] = new _Item { Value = value, Count = 1, Next = null };
                }
                else
                {
                    if (pointer.Value == value)
                    {
                        pointer.Count++;
                    }
                    else
                    {
                        while (pointer.Next != null && pointer.Next.Value != value)
                        {
                            pointer = pointer.Next;
                        }

                        if (pointer.Next == null)
                        {
                            pointer.Next = new _Item { Value = value, Count = 1, Next = null };
                        }
                        else
                        {
                            pointer.Next.Count++;
                        }
                    }
                }
            }

            int arrayIterator = 0;

            for (int i = 0; i < hashTable.Length; i++)
            {
                _Item pointer = hashTable[i];
                while (pointer != null)
                {
                    for (int j = 0; j < pointer.Count; j++)
                    {
                        array[arrayIterator++] = pointer.Value;
                    }
                    pointer = pointer.Next;
                }
            }

        }

    }
}