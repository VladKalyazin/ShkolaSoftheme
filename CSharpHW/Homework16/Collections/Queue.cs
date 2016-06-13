using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    public class VladQueue<T>
    {
        private class _Item<U>
        {
            public _Item<U> PreviousItem { get; set; }

            public U Value { get; set; }
        }

        private _Item<T> _Begin;
        private _Item<T> _End;

        public void Enqueue(T obj)
        {
            var newItem = new _Item<T>();
            newItem.Value = obj;

            if (_Begin == null)
            {
                _Begin = newItem;
                _End = _Begin;
            }
            else
            {
                _End.PreviousItem = newItem;
                _End = newItem;
            }
        }

        public T Dequeue()
        {
            if (_Begin == null)
                throw new ArgumentNullException("Queue doesn't contain any item.");
            T value = _Begin.Value;
            _Begin = _Begin.PreviousItem;
            return value;
        }

        public T Peek() => _Begin.Value;

    }
}
