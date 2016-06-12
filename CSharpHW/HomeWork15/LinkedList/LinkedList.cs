using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    public class LinkedList<T>
    {
        private class _Item<TItem>
        {
            public _Item<TItem> Next;
            public _Item<TItem> Previous;
            public TItem Value;
        }

        private int _Count = 0;

        public int Count
        {
            get
            {
                return _Count;
            }
        }

        private _Item<T> _Begin;
        private _Item<T> _End;

        public void Add(T obj)
        {
            var newItem = new _Item<T>();
            newItem.Value = obj;
            if (_End != null)
            {
                newItem.Previous = _End;
                _End.Next = newItem;
            }
            else
            {
                _Begin = newItem;
            }
            _End = newItem;
            _Count++;
        }

        public bool Delete(T obj)
        {
            _Item<T> pointer = _Begin;
            while (pointer != null)
            {
                if (pointer.Value.Equals(obj))
                {
                    pointer.Previous.Next = pointer.Next;
                    pointer.Next.Previous = pointer.Previous;
                    _Count--;
                    return true;
                }
                pointer = pointer.Next;
            }

            return false;
        }

        public bool Contains(T obj)
        {
            _Item<T> pointer = _Begin;
            while (pointer != null)
            {
                if (pointer.Value.Equals(obj))
                {
                    return true;
                }
                pointer = pointer.Next;
            }

            return false;
        }

        public T[] ToArray()
        {
            T[] result = new T[_Count];
            _Item<T> pointer = _Begin;
            for (int i = 0; i < _Count; i++)
            {
                result[i] = pointer.Value;
                pointer = pointer.Next;
            }

            return result;
        }

    }
}
